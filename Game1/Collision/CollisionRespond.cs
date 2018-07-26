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

        //private int invulnerabilityFrames;
        private int invulnerabilityTimer;

        private ILevel objectLevel;
        private IPlayer player;
        private IControllerHandler controllerHandler;
        private CollisionUtilityClass utility;
        private bool play_end_theme = true;
        
        public CollisionRespond(Game1 game, ILevel level)
        {
            utility = new CollisionUtilityClass();
            myGame = game;
            controllerHandler = game.ControllerHandler;
            objectLevel = level;
            this.player = level.PlayerObject;

            invulnerabilityTimer = 0;
           
        }

        public void BlockCollisionRespondTop(IBlock block,int height,bool standing)
        {
            if (block is TopWarpPipeBlock && controllerHandler.MovingDown)
            {
                SoundWarehouse.pipe.Play();
                player.CurrentXPos = block.GameObjectLocation.X + 8;
                player.TestMario.Pipe(true, false);
            }
            else
            {
                if (!(block is HiddenGreenMushroomBlock) && !standing)
                    player.CurrentYPos -= height;
                player.CanJump = true;
                player.Falling = false;
                ((Mario)player).KilledNum = 0;
                if (player.TestMario.StateMachine.IsJumping())
                {
                    player.TestMario.StateMachine.ChangeState();
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

            if (player.TestMario.StateMachine is TestSmallMarioStateMachine && block is BrickBlock)
            {
                SoundWarehouse.bump.Play();
                ((BrickBlock)block).Bounce();
            }

            if (block is BrickBlock && !(player.TestMario.StateMachine is TestSmallMarioStateMachine))
            {
                SoundWarehouse.breakblock.Play();
                objectLevel.PersistentData.BlockDestroyPoints(block.GameObjectLocation);
                objectLevel.BlockObjects.Remove(block);
                
            }
            else if (block is QuestionPowerUpBlock)
            {
                SoundWarehouse.powerup_appears.Play();
                objectLevel.BlockObjects.Remove(block);
                objectLevel.BlockObjects.Add(new UsedBlock(myGame, block.GameObjectLocation));
                if (player.TestMario.StateMachine is TestSmallMarioStateMachine)
                    objectLevel.PickupObjects.Add(new RedMushroom(myGame, block.GameObjectLocation));
                else
                    objectLevel.PickupObjects.Add(new Fireflower(myGame, block.GameObjectLocation));
            }
            else if (block is QuestionCoinBlock)
            {
                SoundWarehouse.coin.Play();
                objectLevel.PersistentData.CoinCollectedPoints(block.GameObjectLocation);
                objectLevel.BlockObjects.Remove(block);
                objectLevel.BlockObjects.Add(new UsedBlock(myGame, block.GameObjectLocation));
                objectLevel.TemporaryObjects.Add(new Coin(myGame, block.GameObjectLocation));
                
            }
            else if (block is BrickBlockWithStar)
            {
                SoundWarehouse.powerup_appears.Play();
                objectLevel.BlockObjects.Remove(block);
                objectLevel.BlockObjects.Add(new UsedBlock(myGame, block.GameObjectLocation));
                objectLevel.PickupObjects.Add(new Star(myGame, block.GameObjectLocation));
            }
            else if (block is HiddenGreenMushroomBlock)
            {
                SoundWarehouse.oneup.Play();
                objectLevel.BlockObjects.Remove(block);
                objectLevel.BlockObjects.Add(new UsedBlock(myGame, block.GameObjectLocation));
                objectLevel.PickupObjects.Add(new GreenMushroom(myGame, block.GameObjectLocation));
            }
            else if (block is BrickBlockWithManyCoins)
            {
                if (((BrickBlockWithManyCoins)block).CoinsLeft > 1)
                {
                    SoundWarehouse.coin.Play();
                    objectLevel.PersistentData.CoinCollectedPoints(block.GameObjectLocation);
                    objectLevel.TemporaryObjects.Add(new Coin(myGame, block.GameObjectLocation));
                    ((BrickBlockWithManyCoins)block).CoinsLeft--;
                    ((BrickBlockWithManyCoins)block).Bounce();
                }
                else
                {
                    objectLevel.TemporaryObjects.Add(new Coin(myGame, block.GameObjectLocation));
                    objectLevel.PersistentData.CoinCollectedPoints(block.GameObjectLocation);
                    objectLevel.BlockObjects.Remove(block);
                    objectLevel.BlockObjects.Add(new UsedBlock(myGame, block.GameObjectLocation));
                }
            }

            if (!(block is UsedBlock))
            {
                int i = 0;
                IEnemy[] flippyBoyes = new IEnemy[10];
                foreach (IEnemy enemy in objectLevel.EnemyObjects)
                {
                    if (enemy.CurrentXPos > block.CurrentXPos - 15 && enemy.CurrentXPos < block.CurrentXPos + 15)
                    {
                        if(enemy.CurrentYPos < block.CurrentYPos && enemy.CurrentYPos > block.CurrentYPos - (16 + 15))
                        {
                            CreateFlippedEnemy(enemy);
                            flippyBoyes[i] = enemy;
                            i++;
                        }
                    }
                }
                foreach (IEnemy boyo in flippyBoyes)
                    objectLevel.EnemyObjects.Remove(boyo);
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

                if (play_end_theme)
                {
                    MediaPlayer.Play(SoundWarehouse.level_complete_theme);
                    play_end_theme = false;
                }

                FlagBlock temp = (FlagBlock)objectLevel.BlockObjects.Find(x => x is FlagBlock);
                temp.Activate((int)(114 - (player.CurrentYPos - temp.GameObjectLocation.Y)));
                player.TestMario.Flag();
                myGame.AllowControllerResponse = false;
                myGame.TimerStop = true;
                ((PlatformerLevel)objectLevel).NextLevel = true;
                objectLevel.PersistentData.KoopaFireOrStarPoints(block.GameObjectLocation);             //CHANGE THIS LATER
            }
            else if (block is PipeOnSideBlock && controllerHandler.MovingRight)
            {
                SoundWarehouse.pipe.Play();
                player.TestMario.Pipe(true, true);
            }
            else if (!(block is HiddenGreenMushroomBlock) && !left)
            {
                player.CurrentXPos -= width;
            }
        }

        public void EnemyCollisionRespondTop(IEnemy enemy)
        {
            if (enemy is FireEnemy || enemy is Bowser || enemy is BowserFireBall)
            {
                MarioHit();
            }
            else
            {
                enemy.BeStomped();
                SoundWarehouse.stomp.Play();
                ((Mario)player).KilledNum += 1;
                //objectLevel.PersistentData.EnemyStompedPoints(((Mario)player).KilledNum, enemy.GetGameObjectLocation());

                if (enemy is Goomba)
                {
                    objectLevel.TemporaryObjects.Add(new FlattenedGoomba(myGame, enemy.GameObjectLocation));
                    objectLevel.EnemyObjects.Remove(enemy);
                    objectLevel.PersistentData.EnemyStompedPoints(((Mario)player).KilledNum, enemy.GameObjectLocation);
                }
                else if (enemy is Koopa)
                {
                    objectLevel.EnemyObjects.Remove(enemy);
                    objectLevel.EnemyObjects.Add(new KoopaShell(myGame, enemy.GameObjectLocation));
                    objectLevel.PersistentData.EnemyStompedPoints(((Mario)player).KilledNum, enemy.GameObjectLocation);
                }
                if (enemy is MarioFireBall)
                {

                }
                else
                {
                    player.Bounce = true;
                }
            }
            
        }

        public void EnemyCollisionRespondBottom(IEnemy enemy)
        {
            if (player.IsStar)
            {
                objectLevel.EnemyObjects.Remove(enemy);
            }
            MarioHit();
        }

        public void EnemyCollisionRespondLeft(IEnemy enemy)
        {
            if (enemy is KoopaShell)
            {
                if (!((KoopaShell)enemy).IsMoving)
                {
                    if (!enemy.StateMachine.Direction)
                    {
                        enemy.ChangeDirection(true);
                    }
                    SoundWarehouse.stomp.Play();
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
                SoundWarehouse.stomp.Play();
                CreateFlippedEnemy(enemy);
            }
            else if (enemy is MarioFireBall)
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
                    if (enemy.StateMachine.Direction)
                    {
                        enemy.ChangeDirection(true);
                    }
                    enemy.BeStomped();
                    SoundWarehouse.stomp.Play();
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
                SoundWarehouse.stomp.Play();
                CreateFlippedEnemy(enemy);
            }
            else if (enemy is MarioFireBall)
            {

            }
            else
                MarioHit();
        }

        public void EnemyCollisionBlockRespondLeft(IEnemy enemy, IEnemy otherEnemy, int width)
        {
            if( !(enemy is Bowser))
                enemy.ChangeDirection(true);

            if (enemy is MarioFireBall)
            {
                objectLevel.EnemyObjects.Remove(enemy);
            }
            else if (otherEnemy is MarioFireBall)
            {
                objectLevel.EnemyObjects.Remove(otherEnemy);
            }
        }

        public void EnemyCollisionEnemyRespondLeft(IEnemy enemy, IEnemy otherEnemy, int width)
        {
            if (enemy.Dead== false && !(enemy is KoopaShell))
            {
                var x = enemy.GameObjectLocation.X + width;
                var y = enemy.GameObjectLocation.Y;
                enemy.SetGameObjectLocation(new Vector2(x, y));
                enemy.ChangeDirection(true);
            }

            if (enemy is MarioFireBall && !(otherEnemy is FireEnemy))
            {
                SoundWarehouse.stomp.Play();
                CreateFlippedEnemy(otherEnemy);
                objectLevel.EnemyObjects.Remove(enemy);
                objectLevel.EnemyObjects.Remove(otherEnemy);
            }
            else if (otherEnemy is MarioFireBall && !(enemy is FireEnemy))
            {
                SoundWarehouse.stomp.Play();
                CreateFlippedEnemy(enemy);
                objectLevel.EnemyObjects.Remove(enemy);
                objectLevel.EnemyObjects.Remove(otherEnemy);
            }
            else if (otherEnemy is KoopaShell)
            {
                ((KoopaShell)otherEnemy).KilledNum += 1;
                myGame.PersistentData.KoopaShell((KoopaShell)otherEnemy, enemy.GameObjectLocation);
                objectLevel.EnemyObjects.Remove(enemy);
            }
        }

        public void EnemyCollisionBlockRespondRight(IEnemy enemy, IEnemy otherEnemy)
        {
            if (enemy is Bowser)
            { }
            else
                enemy.ChangeDirection(true);

            if (enemy is MarioFireBall)
            {
                objectLevel.EnemyObjects.Remove(enemy);
            }
            else if (otherEnemy is MarioFireBall)
            {
                objectLevel.EnemyObjects.Remove(otherEnemy);
            }
        }

        public void EnemyCollisionEnemyRespondRight(IEnemy enemy, IEnemy otherEnemy, int width)
        {
            if (!(enemy is BowserFireBall || otherEnemy is BowserFireBall))
            {
                if (enemy.Dead== false && !(enemy is KoopaShell))
                {
                    var x = enemy.GameObjectLocation.X - width;
                    var y = enemy.GameObjectLocation.Y;
                    enemy.SetGameObjectLocation(new Vector2(x, y));
                    enemy.ChangeDirection(true);
                }

                if (enemy is MarioFireBall && !(otherEnemy is FireEnemy) && !(otherEnemy is Bowser))
                {
                    SoundWarehouse.stomp.Play();
                    CreateFlippedEnemy(otherEnemy);
                    objectLevel.EnemyObjects.Remove(enemy);
                    objectLevel.EnemyObjects.Remove(otherEnemy);
                }
                else if (otherEnemy is MarioFireBall && !(enemy is FireEnemy) && !(enemy is Bowser))
                {
                    SoundWarehouse.stomp.Play();
                    CreateFlippedEnemy(enemy);
                    objectLevel.EnemyObjects.Remove(enemy);
                    objectLevel.EnemyObjects.Remove(otherEnemy);
                }
                else if (otherEnemy is KoopaShell)
                {
                    ((KoopaShell)otherEnemy).KilledNum += 1;
                    myGame.PersistentData.KoopaShell((KoopaShell)otherEnemy, enemy.GameObjectLocation);
                    objectLevel.EnemyObjects.Remove(enemy);
                }
                else if ((enemy is Bowser && otherEnemy is MarioFireBall))
                {
                    ((Bowser)enemy).SetBowserLife(-1);
                    CreateFlippedEnemy(enemy);
                    if (((Bowser)enemy).BowserLife == 0)
                    {
                        objectLevel.EnemyObjects.Remove(enemy);
                        objectLevel.EnemyObjects.Remove(otherEnemy);
                    }

                }
                else if ((otherEnemy is Bowser && enemy is MarioFireBall))
                {
                    ((Bowser)otherEnemy).SetBowserLife(-1);
                    CreateFlippedEnemy(enemy);
                    if (((Bowser)otherEnemy).BowserLife == 0)
                    {
                        objectLevel.EnemyObjects.Remove(enemy);
                        objectLevel.EnemyObjects.Remove(otherEnemy);
                    }

                }
            }
        }

        public void EnemyCollisionBlockRespondYDirection(IEnemy enemy, int height,bool bottom)
        { 
            if (!bottom && enemy.Dead==false ||enemy is KoopaShell)
            {
                var x = enemy.GameObjectLocation.X;
                var y = enemy.GameObjectLocation.Y - height;
                enemy.SetGameObjectLocation(new Vector2(x, y));
            }
            enemy.IsFalling = false;
        }

        public void PickupCollisionRespond(IPickup pickup)
        {
            
            if (pickup is Fireflower)
            {
                player.TestMario = new TestFireMario(myGame, new Vector2(player.CurrentXPos, player.CurrentYPos), (Mario)player);
                objectLevel.PersistentData.PowerUpCollectPoints(pickup.GameObjectLocation);
                SoundWarehouse.powerup.Play();
            }
            else if (pickup is GreenMushroom)
            {
                objectLevel.PersistentData.OneUpLives(pickup.GameObjectLocation);
            }
            else if (pickup is RedMushroom)
            {
                if (!(player.TestMario is TestFireMario))
                    player.TestMario = new TestBigMario(myGame, new Vector2(player.CurrentXPos, player.CurrentYPos), (Mario)player);
                objectLevel.PersistentData.PowerUpCollectPoints(pickup.GameObjectLocation);
                SoundWarehouse.powerup.Play();
            }
            else if (pickup is CoinPickup)
            {
                SoundWarehouse.coin.Play();
                objectLevel.PersistentData.CoinCollectedPoints(pickup.GameObjectLocation);
            }
            else if (pickup is Star)
            {
                objectLevel.PersistentData.PowerUpCollectPoints(pickup.GameObjectLocation);
                SoundWarehouse.powerup.Play();
                MediaPlayer.Play(SoundWarehouse.star_theme);
                objectLevel.PlayerObject.IsStar = true;
                invulnerabilityTimer = 1000;
                player.Invulnerability = true;
            }
            else if (pickup is AxePickup)
            {
                ((BossLevel)objectLevel).EndSequence = true;
                ((Mario)player).Stop();
            }

            objectLevel.PickupObjects.Remove(pickup);
        }

        public void PickupCollisionBlockRespondBottom(IPickup pickup, int height)
        {
            float x = pickup.GameObjectLocation.X;
            float y = pickup.GameObjectLocation.Y;
            pickup.SetGameObjectLocation(new Vector2(x,y-height));
            pickup.IsFalling = false;
        }

        public void PickupCollisionBlockRespondLeft(IPickup pickup, int width)
        {
            float x = pickup.GameObjectLocation.X;
            float y = pickup.GameObjectLocation.Y;
            pickup.SetGameObjectLocation(new Vector2(x + width, y));
            pickup.Collide();
        }

        public void PickupCollisionBlockRespondRight(IPickup pickup, int width)
        {
            float x = pickup.GameObjectLocation.X;
            float y = pickup.GameObjectLocation.Y;
            pickup.SetGameObjectLocation(new Vector2(x - width, y));
            pickup.Collide();
        }

        private void MarioHit()
        {
            if (!player.Invulnerability)
            {
                SoundWarehouse.pipe.Play();
                invulnerabilityTimer = utility.InvulnerabilityFrames;
                player.TestMario.Downgrade();
                player.Invulnerability = true;
            }
        }

        public void Update()
        {
            if (player.Invulnerability)
            {
                invulnerabilityTimer--;
            }
            if (invulnerabilityTimer == 0)
            {
                player.Invulnerability = false;
                objectLevel.PlayerObject.IsStar = false;
            }
        }

        private void CreateFlippedEnemy(IEnemy enemy)
        {
            if (enemy is Goomba)
            {
                objectLevel.TemporaryObjects.Add(new FlippedGoomba(myGame, new Vector2(enemy.CurrentXPos, enemy.CurrentYPos)));
                objectLevel.PersistentData.EnemyStompedPoints(1, enemy.GameObjectLocation);
            }
            else if (enemy is Koopa)
            {
                objectLevel.TemporaryObjects.Add(new FlippedKoopa(myGame, new Vector2(enemy.CurrentXPos, enemy.CurrentYPos)));
                objectLevel.PersistentData.KoopaFireOrStarPoints(enemy.GameObjectLocation);
            }
            else if (enemy is Bowser)
            {
                objectLevel.TemporaryObjects.Add(new FlippedBowser(myGame, new Vector2(enemy.CurrentXPos, enemy.CurrentYPos)));

            }
        }
    }
}
