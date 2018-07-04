using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    class CollisionRespond
    {
        private Game1 myGame;

        private int invulnerabilityFrames = 100;
        private int invulnerabilityTimer;

        private ILevel objectLevel;
        private IPlayer player;
        private IControllerHandler controllerHandler;

        public CollisionRespond(Game1 game, ILevel level)
        {
            myGame = game;
            controllerHandler = game.controllerHandler;
            objectLevel = level;
            this.player = level.PlayerObject;

            invulnerabilityTimer = 100;
        }

        public void BlockCollisionRespondTop(IBlock block,int height,bool standing)
        {
            if (!(block is HiddenGreenMushroomBlock) && !standing)
                player.CurrentYPos -= height;
            player.CanJump = true;
            player.Falling = false;
            if (player.MarioSprite is MarioBigJumpingRight)
            {
                player.MarioSprite = new MarioBigIdleRight(myGame,player);
            }
            else if (player.MarioSprite is MarioBigJumpingLeft)
            {
                player.MarioSprite = new MarioBigIdleLeft(myGame,player);
            }
            else if (player.MarioSprite is MarioSmallJumpingRight)
            {
                player.MarioSprite = new MarioSmallIdleRight(myGame,player);
            }
            else if (player.MarioSprite is MarioSmallJumpingLeft)
            {
                player.MarioSprite = new MarioSmallIdleLeft(myGame,player);
            }
            else if (player.MarioSprite is MarioFireJumpingRight)
            {
                player.MarioSprite = new MarioFireIdleRight(myGame,player);
            }
            else if (player.MarioSprite is MarioFireJumpingLeft)
            {
                player.MarioSprite = new MarioFireIdleLeft(myGame,player);
            }
        }

        public void BlockCollisionRespondBottom(IBlock block,int height,bool head)
        {
            if (!head)
            {
                player.CurrentYPos += height;
                player.Bump = true;
            }
                

            if (player.MarioSprite.isSmall() && block is BrickBlock)
            {
                ((BrickBlock)block).Bounce();
            }

            if (block is BrickBlock && !player.MarioSprite.isSmall())
                objectLevel.BlockObjects.Remove(block);
            else if (block is QuestionPowerUpBlock)
            {
                objectLevel.BlockObjects.Remove(block);
                objectLevel.BlockObjects.Add(new UsedBlock(myGame, block.GetGameObjectLocation()));
                if (player.MarioSprite.isSmall())
                    objectLevel.PickupObjects.Add(new RedMushroom(myGame, block.GetGameObjectLocation()));
                else
                    objectLevel.PickupObjects.Add(new Fireflower(myGame, block.GetGameObjectLocation()));
            }
            else if (block is QuestionCoinBlock)
            {
                objectLevel.BlockObjects.Remove(block);
                objectLevel.BlockObjects.Add(new UsedBlock(myGame, block.GetGameObjectLocation()));
                objectLevel.TemporaryObjects.Add(new Coin(myGame, block.GetGameObjectLocation()));
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
                }
                else
                {
                    objectLevel.TemporaryObjects.Add(new Coin(myGame, block.GetGameObjectLocation()));
                    objectLevel.BlockObjects.Remove(block);
                    objectLevel.BlockObjects.Add(new UsedBlock(myGame, block.GetGameObjectLocation()));
                }
            }

            player.CanJump = false;
            player.Falling = true;
            player.Jumping = false;

        }

        public void BlockCollisionRespondRight(IBlock block,int width,bool right)
        {
            if (!(block is HiddenGreenMushroomBlock) && !right)
                player.CurrentXPos += width;
        }

        public void BlockCollisionRespondLeft(IBlock block,int width,bool left)
        {
            if (!(block is HiddenGreenMushroomBlock) && !left)
                player.CurrentXPos -= width;
        }

        public void EnemyCollisionRespondTop(IEnemy enemy)
        {
            enemy.BeStomped();
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
            if (objectLevel.PlayerObject.IsStar)
            {
                if (enemy is Goomba)
                    objectLevel.TemporaryObjects.Add(new FlippedGoomba(myGame, new Vector2(enemy.CurrentXPos, enemy.CurrentYPos)));
                else if (enemy is Koopa)
                    objectLevel.TemporaryObjects.Add(new FlippedKoopa(myGame, new Vector2(enemy.CurrentXPos, enemy.CurrentYPos)));
            }
                MarioHit();
            
        }

        public void EnemyCollisionRespondLeft(IEnemy enemy)
        {
            if (enemy is KoopaShell)
            {
                if (!((KoopaShell)enemy).isMoving)
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
            else if (objectLevel.PlayerObject.IsStar)
            {
                objectLevel.EnemyObjects.Remove(enemy);
                if (enemy is Goomba)
                    objectLevel.TemporaryObjects.Add(new FlippedGoomba(myGame, new Vector2(enemy.CurrentXPos, enemy.CurrentYPos)));
                else if (enemy is Koopa)
                    objectLevel.TemporaryObjects.Add(new FlippedKoopa(myGame, new Vector2(enemy.CurrentXPos, enemy.CurrentYPos)));
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
                if (!((KoopaShell)enemy).isMoving)
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
            else if (objectLevel.PlayerObject.IsStar)
            {
                objectLevel.EnemyObjects.Remove(enemy);
                if (enemy is Goomba)
                    objectLevel.TemporaryObjects.Add(new FlippedGoomba(myGame, new Vector2(enemy.CurrentXPos, enemy.CurrentYPos)));
                else if (enemy is Koopa)
                    objectLevel.TemporaryObjects.Add(new FlippedKoopa(myGame, new Vector2(enemy.CurrentXPos, enemy.CurrentYPos)));
            }
            else if (enemy is MarioFireBall)
            {

            }
            else
                MarioHit();
        }


        public void EnemyCollisionBlockandEnemyRespondLeft(IEnemy enemy, IEnemy otherEnemy, int width)
        {

            if (enemy.GetDead() == false || enemy is KoopaShell)
            {
                var x = enemy.GetGameObjectLocation().X + width;
                var y = enemy.GetGameObjectLocation().Y;
                enemy.SetGameObjectLocation(new Vector2(x, y));
            }
            if (enemy is MarioFireBall || otherEnemy is MarioFireBall|| otherEnemy is KoopaShell)
                objectLevel.EnemyObjects.Remove(enemy);

            enemy.ChangeDirection();
        }
        public void EnemyCollisionBlockandEnemyRespondRight(IEnemy enemy, IEnemy otherEnemy, int width)
        {

            if (enemy.GetDead() == false || enemy is KoopaShell)
            {
                var x = enemy.GetGameObjectLocation().X - width;
                var y = enemy.GetGameObjectLocation().Y;
                enemy.SetGameObjectLocation(new Vector2(x, y));
            }
            if (enemy is MarioFireBall || otherEnemy is MarioFireBall || otherEnemy is KoopaShell)
                objectLevel.EnemyObjects.Remove(enemy);

            enemy.ChangeDirection();
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
            pickup.Picked();
           
            if (pickup is Fireflower)
            {
                player.MarioSprite.FireMarioCommandCalled();
            }
            else if (pickup is GreenMushroom)
            {
            }
            else if (pickup is RedMushroom)
            {
                if (!player.MarioSprite.isFire())
                    player.MarioSprite.BigMarioCommandCalled();
            }
            else if (pickup is Coin)
            {

            }
            else if (pickup is EmptyPickup)
            {

            }
            else if (pickup is Star)
            {
                objectLevel.PlayerObject.IsStar = true;
                invulnerabilityTimer = 1000;
                player.Invulnerability = true;
            }

            objectLevel.PickupObjects.Remove(pickup);
        }

        public void PickupCollisionRespondBottom(IPickup pickup)
        {
            pickup.Picked();
         
            if (pickup is Fireflower)
            {
                player.MarioSprite.FireMarioCommandCalled();
            }
            else if (pickup is GreenMushroom)
            {
                //player.marioSprite.BigMarioCommandCalled();
            }
            else if (pickup is RedMushroom)
            {
                if (!player.MarioSprite.isFire())
                player.MarioSprite.BigMarioCommandCalled();
            }
            else if (pickup is Coin)
            {

            }
            else if (pickup is EmptyPickup)
            {

            }
            else if (pickup is Star)
            {
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
            pickup.Picked();
            
            if (pickup is Fireflower)
            {
                player.MarioSprite.FireMarioCommandCalled();
            }
            else if (pickup is GreenMushroom)
            {
                //player.marioSprite.BigMarioCommandCalled();
            }
            else if (pickup is RedMushroom)
            {
                if (!player.MarioSprite.isFire())
                    player.MarioSprite.BigMarioCommandCalled();
            }
            else if (pickup is Coin)
            {

            }
            else if (pickup is EmptyPickup)
            {

            }
            else if (pickup is Star)
            {
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

        public void PickupCollisionRespondRight(IPickup pickup)
        {
            pickup.Picked();
            

            if (pickup is Fireflower)
            {
                player.MarioSprite.FireMarioCommandCalled();
            }
            else if (pickup is GreenMushroom)
            {
                //player.marioSprite.BigMarioCommandCalled();
            }
            else if (pickup is RedMushroom)
            {
                if (!player.MarioSprite.isFire())
                    player.MarioSprite.BigMarioCommandCalled();
            }
            else if (pickup is Coin)
            {
                
            }
            else if (pickup is EmptyPickup)
            {
                
            }
            else if (pickup is Star)
            {
                objectLevel.PlayerObject.IsStar = true;
                invulnerabilityTimer = 1000;
                player.Invulnerability = true;
            }

            objectLevel.PickupObjects.Remove(pickup);
        }

        private void MarioHit()
        {
            if (player.Invulnerability)
            {

            }
            else if (player.MarioSprite.isFire())
            {
                player.MarioSprite.BigMarioCommandCalled();
                player.Invulnerability = true;
            }
            else if (!player.MarioSprite.isSmall())
            {
                player.MarioSprite.SmallMarioCommandCalled();
                player.Invulnerability = true;
            }
            else
            {
                player.MarioSprite.DeadMarioCommandCalled();
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
                invulnerabilityTimer = invulnerabilityFrames;
                player.Invulnerability = false;
                objectLevel.PlayerObject.IsStar = false;
            }
        }
    }
}
