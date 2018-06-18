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

            upCommand = new UpCommand(myGame);
            downCommand = new DownCommand(myGame);
            leftCommand = new LeftCommand(myGame);
            rightCommand = new RightCommand(myGame);

            objectLevel = level;
        }

        public void BlockCollisionRespondTop(IPlayer player, IBlock block)
        {
            if (!(block is HiddenBlock))
                upCommand.Execute();
        }

        public void BlockCollisionRespondBottom(IPlayer player, IBlock block)
        {
            
            downCommand.Execute();

            if (Mario.marioSprite.isSmall() && block is BrickBlock)
            {
            }
            else
            {
                block.BottomCollision();
            }

            if (block is BrickBlock && !Mario.marioSprite.isSmall())
                objectLevel.BlockObjects.Remove(block);

        }

        public void BlockCollisionRespondRight(IPlayer player, IBlock block)
        {
            if(!(block is HiddenBlock))
                rightCommand.Execute();
        }

        public void BlockCollisionRespondLeft(IPlayer player, IBlock block)
        {
            if (!(block is HiddenBlock))
                leftCommand.Execute();
        }

        public void EnemyCollisionRespondTop(IPlayer player, IEnemy enemy)
        {
            enemy.BeStomped();
            objectLevel.EnemyObjects.Remove(enemy);
        }

        public void EnemyCollisionRespondBottom(IPlayer player, IEnemy enemy)
        {
            if (objectLevel.PlayerObject.IsStar)
            {
                enemy.BeStomped();
                objectLevel.EnemyObjects.Remove(enemy);
            } else if (invulnerability)
            {

            }
            else if (Mario.marioSprite.isFire())
            {
                Mario.marioSprite.BigMarioCommandCalled();
                invulnerability = true;
            }
            else if (!Mario.marioSprite.isSmall())
            {
                Mario.marioSprite.SmallMarioCommandCalled();
                invulnerability = true;
            }
            else
            {
                Mario.marioSprite.DeadMarioCommandCalled();
            }
            
        }

        public void EnemyCollisionRespondLeft(IPlayer player, IEnemy enemy)
        {
            if (objectLevel.PlayerObject.IsStar)
            {
                enemy.BeStomped();
                objectLevel.EnemyObjects.Remove(enemy);
            }
            else if (invulnerability)
            {

            }
            else if (Mario.marioSprite.isFire())
            {
                Mario.marioSprite.BigMarioCommandCalled();
                invulnerability = true;
            }
            else if (!Mario.marioSprite.isSmall())
            {
                Mario.marioSprite.SmallMarioCommandCalled();
                invulnerability = true;
            }
            else
            {
                Mario.marioSprite.DeadMarioCommandCalled();
            }
        }

        public void EnemyCollisionRespondRight(IPlayer player, IEnemy enemy)
        {
            if (objectLevel.PlayerObject.IsStar)
            {
                enemy.BeStomped();
                objectLevel.EnemyObjects.Remove(enemy);
            }
            else if (invulnerability)
            {

            }
            else if (Mario.marioSprite.isFire())
            {
                Mario.marioSprite.BigMarioCommandCalled();
                invulnerability = true;
            }
            else if (!Mario.marioSprite.isSmall())
            {
                Mario.marioSprite.SmallMarioCommandCalled();
                invulnerability = true;
            }
            else
            {
                Mario.marioSprite.DeadMarioCommandCalled();
            }
        }

        public void PickupCollisionRespondTop(IPlayer player, IPickup pickup)
        {
            pickup.Picked();
           
            if (pickup is Fireflower)
            {
                Mario.marioSprite.FireMarioCommandCalled();
            }
            else if (pickup is GreenMushroom)
            {
                //Mario.marioSprite.BigMarioCommandCalled();
            }
            else if (pickup is RedMushroom)
            {
                if (!Mario.marioSprite.isFire())
                    Mario.marioSprite.BigMarioCommandCalled();
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

        public void PickupCollisionRespondBottom(IPlayer player, IPickup pickup)
        {
            pickup.Picked();
         
            if (pickup is Fireflower)
            {
                Mario.marioSprite.FireMarioCommandCalled();
            }
            else if (pickup is GreenMushroom)
            {
                //Mario.marioSprite.BigMarioCommandCalled();
            }
            else if (pickup is RedMushroom)
            {
                if (!Mario.marioSprite.isFire())
                Mario.marioSprite.BigMarioCommandCalled();
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

        public void PickupCollisionRespondLeft(IPlayer player, IPickup pickup)
        {
            pickup.Picked();
            

            if (pickup is Fireflower)
            {
                Mario.marioSprite.FireMarioCommandCalled();
            }
            else if (pickup is GreenMushroom)
            {
                //Mario.marioSprite.BigMarioCommandCalled();
            }
            else if (pickup is RedMushroom)
            {
                if (!Mario.marioSprite.isFire())
                    Mario.marioSprite.BigMarioCommandCalled();
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

        public void PickupCollisionRespondRight(IPlayer player, IPickup pickup)
        {
            pickup.Picked();
            

            if (pickup is Fireflower)
            {
                Mario.marioSprite.FireMarioCommandCalled();
            }
            else if (pickup is GreenMushroom)
            {
                //Mario.marioSprite.BigMarioCommandCalled();
            }
            else if (pickup is RedMushroom)
            {
                if (!Mario.marioSprite.isFire())
                    Mario.marioSprite.BigMarioCommandCalled();
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
