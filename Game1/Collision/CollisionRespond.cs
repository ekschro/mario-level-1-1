using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace Game1
{
    class CollisionRespond
    {
        private Game1 myGame;

        //private int invulnerabilityFrames = 100;
        private int invulnerabilityFrames;
        private int invulnerabilityTimer;

        private ILevel objectLevel;
        private IPlayer player;
        private IControllerHandler controllerHandler;
        private CollisionUtilityClass utility;

        public CollisionRespond(Game1 game, ILevel level)
        {
            utility = new CollisionUtilityClass();
            myGame = game;
            controllerHandler = game.controllerHandler;
            objectLevel = level;
            this.player = level.PlayerObject;

            invulnerabilityTimer = 0;
            invulnerabilityFrames = utility.InvulnerabilityRespondFrames;
        }

        public void BlockCollisionRespondTop(IBlock block,int height,bool standing)
        {
            if (block is TopWarpPipeBlock && controllerHandler.MovingDown)
            {
                player.CurrentXPos = block.CurrentXPos + 24;
                ((PlatformerLevel)objectLevel).WarpToSecret();
            }
            else
            {
                if (!(block is HiddenGreenMushroomBlock) && !standing)
                    player.CurrentYPos -= height;
                player.CanJump = true;
                player.Falling = false;
                ((Mario)player).KilledNum = 0;
                if (player.TestMario.GetStateMachine.IsJumping())
                {
                    player.TestMario.GetStateMachine.ChangeState();
                }
            }
        }

        public void BlockCollisionRespondBottom(IBlock block,int height,bool head)
        {
            if (!head)
            {
                player.CurrentYPos += height;
                player.Bump = true;
            }

            if (player.TestMario.GetStateMachine is TestSmallMarioStateMachine && block is BrickBlock)
            {
                SoundWarehouse.bump.Play();
                ((BrickBlock)block).Bounce();
            }

            if (block is BrickBlock && !(player.TestMario.GetStateMachine is TestSmallMarioStateMachine))
            {
                SoundWarehouse.breakblock.Play();
                objectLevel.BlockObjects.Remove(block);
                objectLevel.PersistentData.BlockDestroyPoints();
            }
            else if (block is QuestionPowerUpBlock)
            {
                SoundWarehouse.powerup_appears.Play();
                objectLevel.BlockObjects.Remove(block);
                objectLevel.BlockObjects.Add(new UsedBlock(myGame, block.GetGameObjectLocation()));
                if (player.TestMario.GetStateMachine is TestSmallMarioStateMachine)
                    objectLevel.PickupObjects.Add(new RedMushroom(myGame, block.GetGameObjectLocation()));
                else
                    objectLevel.PickupObjects.Add(new Fireflower(myGame, block.GetGameObjectLocation()));
            }
            else if (block is QuestionCoinBlock)
            {
                SoundWarehouse.coin.Play();
                objectLevel.BlockObjects.Remove(block);
                objectLevel.BlockObjects.Add(new UsedBlock(myGame, block.GetGameObjectLocation()));
                objectLevel.TemporaryObjects.Add(new Coin(myGame, block.GetGameObjectLocation()));
                objectLevel.PersistentData.CoinCollectedPoints();
            }
            else if (block is BrickBlockWithStar)
            {
                objectLevel.BlockObjects.Remove(block);
                objectLevel.BlockObjects.Add(new UsedBlock(myGame, block.GetGameObjectLocation()));
                objectLevel.PickupObjects.Add(new Star(myGame, block.GetGameObjectLocation()));
            }
            else if (block is HiddenGreenMushroomBlock)
            {
                objectLevel.BlockObjects.Remove(block);
                objectLevel.BlockObjects.Add(new UsedBlock(myGame, block.GetGameObjectLocation()));
                objectLevel.PickupObjects.Add(new GreenMushroom(myGame, block.GetGameObjectLocation()));
            }
            else if (block is BrickBlockWithManyCoins)
            {
                if (((BrickBlockWithManyCoins)block).CoinsLeft > 1)
                {
                    objectLevel.TemporaryObjects.Add(new Coin(myGame, block.GetGameObjectLocation()));
                    ((BrickBlockWithManyCoins)block).CoinsLeft--;
                    ((BrickBlockWithManyCoins)block).Bounce();
                    objectLevel.PersistentData.CoinCollectedPoints();
                }
                else
                {
                    objectLevel.TemporaryObjects.Add(new Coin(myGame, block.GetGameObjectLocation()));
                    objectLevel.BlockObjects.Remove(block);
                    objectLevel.BlockObjects.Add(new UsedBlock(myGame, block.GetGameObjectLocation()));
                    objectLevel.PersistentData.CoinCollectedPoints();
                }
            }

            player.CanJump = false;
            player.Falling = true;
            player.Jumping = false;

        }

        public void BlockCollisionRespondRight(IBlock block,int width,bool right)
        {
            if (!(block is HiddenGreenMushroomBlock || block is FlagpoleBlock) && !right)
                player.CurrentXPos += width;
        }

        public void BlockCollisionRespondLeft(IBlock block,int width,bool left)
        {
            if (block is FlagpoleBlock)
            {
                FlagBlock temp = (FlagBlock)objectLevel.BlockObjects.Find(x => x is FlagBlock);
                temp.Activate((int)(player.CurrentYPos - temp.GetGameObjectLocation().Y));
                player.TestMario.Flag();
                objectLevel.PersistentData.KoopaFireOrStarPoints();             //CHANGE THIS LATER
            }
            else if (block is PipeOnSideBlock && controllerHandler.MovingRight)
            {
                ((PlatformerLevel)objectLevel).WarpFromSecret();
            }
            else if (!(block is HiddenGreenMushroomBlock) && !left)
            {
                player.CurrentXPos -= width;
            }
            if (block is PipeOnSideBlock && controllerHandler.MovingRight)
                ((PlatformerLevel)objectLevel).WarpFromSecret();
        }

        public void EnemyCollisionRespondTop(IEnemy enemy)
        {
            enemy.BeStomped();
            ((Mario)player).KilledNum += 1;
            objectLevel.PersistentData.EnemyStompedPoints(((Mario)player).KilledNum);

            if (enemy is Goomba)
            {
                objectLevel.TemporaryObjects.Add(new FlattenedGoomba(myGame, enemy.GetGameObjectLocation()));
                objectLevel.EnemyObjects.Remove(enemy);
            }
            else if (enemy is Koopa)
            {
                objectLevel.EnemyObjects.Remove(enemy);
                objectLevel.EnemyObjects.Add(new KoopaShell(myGame, enemy.GetGameObjectLocation()));
            }
            if (enemy is MarioFireBall)
            {
                
            } else
            {
                player.Bounce = true;
            }
            
        }

        public void EnemyCollisionRespondBottom(IEnemy enemy)
        {
            if (player.IsStar)
            {
                objectLevel.EnemyObjects.Remove(enemy);
                if (enemy is Goomba)
                {
                    objectLevel.TemporaryObjects.Add(new FlippedGoomba(myGame, new Vector2(enemy.CurrentXPos, enemy.CurrentYPos)));
                    objectLevel.PersistentData.EnemyStompedPoints(1);
                }
                else if (enemy is Koopa)
                {
                    objectLevel.TemporaryObjects.Add(new FlippedKoopa(myGame, new Vector2(enemy.CurrentXPos, enemy.CurrentYPos)));
                    objectLevel.PersistentData.KoopaFireOrStarPoints();
                }
            }
            MarioHit();
            
        }

        public void EnemyCollisionRespondLeft(IEnemy enemy)
        {
            if (enemy is KoopaShell)
            {
                if (!((KoopaShell)enemy).IsMoving)
                {
                    if (!enemy.GetStateMachine.GetDirection())
                    {
                        enemy.ChangeDirection();
                    }
                    enemy.BeStomped();
                    enemy.CurrentXPos = enemy.CurrentXPos + 5;
                }
                else
                {
                    MarioHit();
                }
            }
            else if (player.IsStar)
            {
                objectLevel.EnemyObjects.Remove(enemy);
                if (enemy is Goomba)
                {
                    objectLevel.TemporaryObjects.Add(new FlippedGoomba(myGame, new Vector2(enemy.CurrentXPos, enemy.CurrentYPos)));
                    objectLevel.PersistentData.EnemyStompedPoints(1);
                }
                else if (enemy is Koopa)
                {
                    objectLevel.TemporaryObjects.Add(new FlippedKoopa(myGame, new Vector2(enemy.CurrentXPos, enemy.CurrentYPos)));
                    objectLevel.PersistentData.KoopaFireOrStarPoints();
                }
            } else if (enemy is MarioFireBall)
            {

            }
            else
                MarioHit();
        }

        public void EnemyCollisionRespondRight(IEnemy enemy)
        {
            if (enemy is KoopaShell)
            {
                if (!((KoopaShell)enemy).IsMoving)
                {
                    if (enemy.GetStateMachine.GetDirection())
                    {
                        enemy.ChangeDirection();
                    }
                    enemy.BeStomped();
                    enemy.CurrentXPos = enemy.CurrentXPos - 5;
                }
                else
                {
                    MarioHit();
                }
            }
            else if (player.IsStar)
            {
                objectLevel.EnemyObjects.Remove(enemy);
                if (enemy is Goomba)
                {
                    objectLevel.TemporaryObjects.Add(new FlippedGoomba(myGame, new Vector2(enemy.CurrentXPos, enemy.CurrentYPos)));
                    objectLevel.PersistentData.EnemyStompedPoints(1);
                }
                else if (enemy is Koopa)
                {
                    objectLevel.TemporaryObjects.Add(new FlippedKoopa(myGame, new Vector2(enemy.CurrentXPos, enemy.CurrentYPos)));
                    objectLevel.PersistentData.KoopaFireOrStarPoints();
                }
            }
            else if (enemy is MarioFireBall)
            {

            }
            else
                MarioHit();
        }

        public void EnemyCollisionBlockandEnemyRespondLeft(IEnemy enemy, IEnemy otherEnemy, int width)
        {

            if (enemy.GetDead() == false && !(enemy is KoopaShell))
            {
                var x = enemy.GetGameObjectLocation().X + width;
                var y = enemy.GetGameObjectLocation().Y;
                enemy.SetGameObjectLocation(new Vector2(x, y));
                enemy.ChangeDirection();
            }
            if (enemy is MarioFireBall || otherEnemy is MarioFireBall)
            {
                if (enemy is Goomba || otherEnemy is Goomba)
                {
                    myGame.persistentData.EnemyStompedPoints(1);
                }
                else if (enemy is Koopa || otherEnemy is Koopa)
                {
                    myGame.persistentData.KoopaFireOrStarPoints();
                }
                objectLevel.EnemyObjects.Remove(enemy);
            }   
            else if (otherEnemy is KoopaShell)
            {
                objectLevel.EnemyObjects.Remove(enemy);
                ((KoopaShell)otherEnemy).KilledNum += 1;
                myGame.persistentData.KoopaShell((KoopaShell)otherEnemy);
            }

            //enemy.ChangeDirection();
        }
        public void EnemyCollisionBlockandEnemyRespondRight(IEnemy enemy, IEnemy otherEnemy, int width)
        {
            if (enemy.GetDead() == false && !(enemy is KoopaShell))
            {
                var x = enemy.GetGameObjectLocation().X - width;
                var y = enemy.GetGameObjectLocation().Y;
                enemy.SetGameObjectLocation(new Vector2(x, y));
                enemy.ChangeDirection();
            }
            if (enemy is MarioFireBall || otherEnemy is MarioFireBall)
            {
                if (enemy is Goomba || otherEnemy is Goomba)
                {
                    myGame.persistentData.EnemyStompedPoints(1);
                }
                else if (enemy is Koopa || otherEnemy is Koopa)
                {
                    myGame.persistentData.KoopaFireOrStarPoints();
                }
                objectLevel.EnemyObjects.Remove(enemy);
            }
            else if (otherEnemy is KoopaShell)
            {
                objectLevel.EnemyObjects.Remove(enemy);
                ((KoopaShell)otherEnemy).KilledNum += 1;
                myGame.persistentData.KoopaShell((KoopaShell)otherEnemy);
            }

            //enemy.ChangeDirection();
        }

        public void EnemyCollisionBlockRespondYDirection(IEnemy enemy, int height,bool bottom)
        { 
            if (!bottom && enemy.GetDead()==false ||enemy is KoopaShell)
            {
                var x = enemy.GetGameObjectLocation().X;
                var y = enemy.GetGameObjectLocation().Y - height;
                enemy.SetGameObjectLocation(new Vector2(x, y));
            }
            enemy.IsFalling = false;


            if (enemy is MarioFireBall)
            {
                enemy.IsFalling = false;
                MarioFireBall temp = (MarioFireBall)enemy;
                if (temp.MovingUp)
                {
                    temp.MovingUp = false;
                } else
                {
                    temp.MovingUp = true;
                }
            }
        }

        public void PickupCollisionRespondTop(IPickup pickup)
        {
            objectLevel.PersistentData.PowerUpCollectPoints();

            if (pickup is Fireflower)
            {
                player.TestMario = new TestFireMario(myGame, new Vector2(player.CurrentXPos, player.CurrentYPos), (Mario)player);
            }
            else if (pickup is GreenMushroom)
            {
                objectLevel.PersistentData.OneUpLives();
            }
            else if (pickup is RedMushroom)
            {
                if (!(player.TestMario is TestFireMario))
                    player.TestMario = new TestBigMario(myGame, new Vector2(player.CurrentXPos, player.CurrentYPos), (Mario)player);
            }
            else if (pickup is CoinPickup)
            {
                objectLevel.PersistentData.CoinCollectedPoints();
            }
            else if (pickup is Star)
            {
                MediaPlayer.Play(SoundWarehouse.star_theme);
                objectLevel.PlayerObject.IsStar = true;
                invulnerabilityTimer = 1000;
                player.Invulnerability = true;
            }

            objectLevel.PickupObjects.Remove(pickup);
        }

        public void PickupCollisionRespondBottom(IPickup pickup)
        {
            objectLevel.PersistentData.PowerUpCollectPoints();

            if (pickup is Fireflower)
            {
                player.TestMario = new TestFireMario(myGame, new Vector2(player.CurrentXPos, player.CurrentYPos), (Mario)player);
            }
            else if (pickup is GreenMushroom)
            {
                objectLevel.PersistentData.OneUpLives();
            }
            else if (pickup is RedMushroom)
            {
                if (!(player.TestMario is TestFireMario))
                {
                    player.TestMario = new TestBigMario(myGame, new Vector2(player.CurrentXPos, player.CurrentYPos), (Mario)player);
                }
               
            }
            else if (pickup is CoinPickup)
            {
                objectLevel.PersistentData.CoinCollectedPoints();
            }
            else if (pickup is Star)
            {
                MediaPlayer.Play(SoundWarehouse.star_theme);
                objectLevel.PlayerObject.IsStar = true;
                invulnerabilityTimer = 1000;
                player.Invulnerability = true;
            }

            objectLevel.PickupObjects.Remove(pickup);
        }

        public void PickupCollisionBlockRespondBottom(IPickup pickup, int height, bool bottom)
        {
            float x = pickup.GetGameObjectLocation().X;
            float y = pickup.GetGameObjectLocation().Y;
            pickup.SetGameObjectLocation(new Vector2(x,y-height));
            pickup.IsFalling = false;
        }

        public void PickupCollisionRespondLeft(IPickup pickup)
        {
            objectLevel.PersistentData.PowerUpCollectPoints();

            if (pickup is Fireflower)
            {
                player.TestMario = new TestFireMario(myGame, new Vector2(player.CurrentXPos, player.CurrentYPos), (Mario)player);
            }
            else if (pickup is GreenMushroom)
            {
                objectLevel.PersistentData.OneUpLives();
            }
            else if (pickup is RedMushroom)
            {
                if (!(player.TestMario is TestFireMario))
                    player.TestMario = new TestBigMario(myGame, new Vector2(player.CurrentXPos, player.CurrentYPos), (Mario)player);
            }
            else if (pickup is CoinPickup)
            {
                objectLevel.PersistentData.CoinCollectedPoints();
            }
            else if (pickup is Star)
            {
                MediaPlayer.Play(SoundWarehouse.star_theme);
                objectLevel.PlayerObject.IsStar = true;
                invulnerabilityTimer = 1000;
                player.Invulnerability = true;
            }

            objectLevel.PickupObjects.Remove(pickup);
        }

        public void PickupCollisionRespondRight(IPickup pickup)
        {
            objectLevel.PersistentData.PowerUpCollectPoints();


            if (pickup is Fireflower)
            {
                player.TestMario = new TestFireMario(myGame, new Vector2(player.CurrentXPos, player.CurrentYPos), (Mario)player);
            }
            else if (pickup is GreenMushroom)
            {
                objectLevel.PersistentData.OneUpLives();
            }
            else if (pickup is RedMushroom)
            {
                if (!(player.TestMario is TestFireMario))
                    player.TestMario = new TestBigMario(myGame, new Vector2(player.CurrentXPos, player.CurrentYPos), (Mario)player);
            }
            else if (pickup is CoinPickup)
            {
                objectLevel.PersistentData.CoinCollectedPoints();
            }
            else if (pickup is Star)
            {
                MediaPlayer.Play(SoundWarehouse.star_theme);
                objectLevel.PlayerObject.IsStar = true;
                invulnerabilityTimer = 1000;
                player.Invulnerability = true;
            }

            objectLevel.PickupObjects.Remove(pickup);
        }

        public void PickupCollisionBlockRespondLeft(IPickup pickup, int width)
        {
            float x = pickup.GetGameObjectLocation().X;
            float y = pickup.GetGameObjectLocation().Y;
            pickup.SetGameObjectLocation(new Vector2(x + width, y));
            pickup.Collide();
        }

        public void PickupCollisionBlockRespondRight(IPickup pickup, int width)
        {
            float x = pickup.GetGameObjectLocation().X;
            float y = pickup.GetGameObjectLocation().Y;
            pickup.SetGameObjectLocation(new Vector2(x - width, y));
            pickup.Collide();
        }

        private void MarioHit()
        {
            if (!player.Invulnerability)
            {
                player.TestMario.Downgrade();
                player.Invulnerability = true;
            }
            /*if (player.TestMario is TestFireMario)
            {
                player.TestMario = new TestBigMario(myGame, new Vector2(player.CurrentXPos, player.CurrentYPos), (Mario)player);
            }
            else if (!(player.TestMario is TestSmallMario))
            {
                player.TestMario = new TestSmallMario(myGame, new Vector2(player.CurrentXPos, player.CurrentYPos), (Mario)player);
                player.Invulnerability = true;
            }
            else
            {
                player.TestMario = new TestDeadMario(myGame, new Vector2(player.CurrentXPos, player.CurrentYPos), (Mario)player);
            }
            */
        }

        public void Update()
        {
            if (player.Invulnerability)
            {
                invulnerabilityTimer--;
            }
            if (invulnerabilityTimer == 0)
            {
                invulnerabilityTimer = invulnerabilityFrames;
                player.Invulnerability = false;
                objectLevel.PlayerObject.IsStar = false;
            }
        }
    }
}
