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

        ICommand upCommand;
        ICommand downCommand;
        ICommand leftCommand;
        ICommand rightCommand;

        private int invulnerabilityFrames = 100;
        private int invulnerabilityTimer = 100;
        private bool invulnerability = false;

        private ILevel objectLevel;

        public CollisionRespond(Game1 game, ILevel level)
        {
            myGame = game;

            upCommand = new UpCommand();
            downCommand = new DownCommand();
            leftCommand = new LeftCommand();
            rightCommand = new RightCommand();

            objectLevel = level;
        }

        public void BlockCollisionRespondTop(IBlock block,int height)
        {
            if (!(block is HiddenBlock))
                Mario.CurrentYPosition -= height;
        }

        public void BlockCollisionRespondBottom(IBlock block,int height)
        {
            Mario.CurrentYPosition += height;

            if (Mario.MarioSprite.isSmall() && block is BrickBlock)
            {
            }
            else
            {
                block.BottomCollision();
            }

            if (block is BrickBlock && !Mario.MarioSprite.isSmall())
                objectLevel.BlockObjects.Remove(block);
            else if (block is HiddenBlock)
            {
                objectLevel.BlockObjects.Remove(block);
                objectLevel.BlockObjects.Add(new UsedBlock(myGame, block.GameObjectLocation()));
            } else if (block is QuestionBlock)
            {
                objectLevel.BlockObjects.Remove(block);
                objectLevel.BlockObjects.Add(new UsedBlock(myGame, block.GameObjectLocation()));
            }

        }

        public void BlockCollisionRespondRight(IBlock block,int width)
        {
            if (!(block is HiddenBlock))
                Mario.CurrentXPosition += width;
        }

        public void BlockCollisionRespondLeft(IBlock block,int width)
        {
            if (!(block is HiddenBlock))
                Mario.CurrentXPosition -= width;
        }

        public void EnemyCollisionRespondTop(IEnemy enemy)
        {
            enemy.BeStomped();
            if (enemy is Goomba)
            { objectLevel.EnemyObjects.Remove(enemy); }
        }

        public void EnemyCollisionRespondBottom(IEnemy enemy)
        {
            if (objectLevel.PlayerObject.IsStar)
            {
                enemy.BeStomped();
                objectLevel.EnemyObjects.Remove(enemy);
            } else if (invulnerability)
            {

            }
            else if (Mario.MarioSprite.isFire())
            {
                Mario.MarioSprite.BigMarioCommandCalled();
                invulnerability = true;
            }
            else if (!Mario.MarioSprite.isSmall())
            {
                Mario.MarioSprite.SmallMarioCommandCalled();
                invulnerability = true;
            }
            else
            {
                Mario.MarioSprite.DeadMarioCommandCalled();
            }
            
        }

        public void EnemyCollisionRespondLeft(IEnemy enemy)
        {
            if (objectLevel.PlayerObject.IsStar)
            {
                enemy.BeStomped();
                objectLevel.EnemyObjects.Remove(enemy);
            }
            else if (invulnerability)
            {

            }
            else if (Mario.MarioSprite.isFire())
            {
                Mario.MarioSprite.BigMarioCommandCalled();
                invulnerability = true;
            }
            else if (!Mario.MarioSprite.isSmall())
            {
                Mario.MarioSprite.SmallMarioCommandCalled();
                invulnerability = true;
            }
            else
            {
                Mario.MarioSprite.DeadMarioCommandCalled();
            }
        }

        public void EnemyCollisionRespondRight(IEnemy enemy)
        {
            if (objectLevel.PlayerObject.IsStar)
            {
                enemy.BeStomped();
                objectLevel.EnemyObjects.Remove(enemy);
            }
            else if (invulnerability)
            {

            }
            else if (Mario.MarioSprite.isFire())
            {
                Mario.MarioSprite.BigMarioCommandCalled();
                invulnerability = true;
            }
            else if (!Mario.MarioSprite.isSmall())
            {
                Mario.MarioSprite.SmallMarioCommandCalled();
                invulnerability = true;
            }
            else
            {
                Mario.MarioSprite.DeadMarioCommandCalled();
            }
        }
        public void EnemyCollisionBlockRespondXDirection(IEnemy enemy)
        {
            enemy.BeFlipped(); ;
        }

        public void PickupCollisionRespondTop(IPickup pickup)
        {
            pickup.Picked();
           
            if (pickup is Fireflower)
            {
                Mario.MarioSprite.FireMarioCommandCalled();
            }
            else if (pickup is GreenMushroom)
            {
                //Mario.marioSprite.BigMarioCommandCalled();
            }
            else if (pickup is RedMushroom)
            {
                if (!Mario.MarioSprite.isFire())
                    Mario.MarioSprite.BigMarioCommandCalled();
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
                invulnerability = true;
            }

            objectLevel.PickupObjects.Remove(pickup);
        }

        public void PickupCollisionRespondBottom(IPickup pickup)
        {
            pickup.Picked();
         
            if (pickup is Fireflower)
            {
                Mario.MarioSprite.FireMarioCommandCalled();
            }
            else if (pickup is GreenMushroom)
            {
                //Mario.marioSprite.BigMarioCommandCalled();
            }
            else if (pickup is RedMushroom)
            {
                if (!Mario.MarioSprite.isFire())
                Mario.MarioSprite.BigMarioCommandCalled();
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
                invulnerability = true;
            }

            objectLevel.PickupObjects.Remove(pickup);
        }

        public void PickupCollisionRespondLeft(IPickup pickup)
        {
            pickup.Picked();
            
            if (pickup is Fireflower)
            {
                Mario.MarioSprite.FireMarioCommandCalled();
            }
            else if (pickup is GreenMushroom)
            {
                //Mario.marioSprite.BigMarioCommandCalled();
            }
            else if (pickup is RedMushroom)
            {
                if (!Mario.MarioSprite.isFire())
                    Mario.MarioSprite.BigMarioCommandCalled();
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
                invulnerability = true;
            }

            objectLevel.PickupObjects.Remove(pickup);
        }

        public void PickupCollisionRespondRight(IPickup pickup)
        {
            pickup.Picked();
            

            if (pickup is Fireflower)
            {
                Mario.MarioSprite.FireMarioCommandCalled();
            }
            else if (pickup is GreenMushroom)
            {
                //Mario.marioSprite.BigMarioCommandCalled();
            }
            else if (pickup is RedMushroom)
            {
                if (!Mario.MarioSprite.isFire())
                    Mario.MarioSprite.BigMarioCommandCalled();
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
                invulnerability = true;
            }

            objectLevel.PickupObjects.Remove(pickup);
        }

        public void Update()
        {
            if (invulnerability)
            {
                invulnerabilityTimer--;
            }
            if (invulnerabilityTimer == 0)
            {
                invulnerabilityTimer = invulnerabilityFrames;
                invulnerability = false;
                objectLevel.PlayerObject.IsStar = false;
            }
        }
    }
}
