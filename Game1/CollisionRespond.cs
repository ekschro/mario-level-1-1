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

        public CollisionRespond(Game1 game)
        {
            myGame = game;

            upCommand = new UpCommand(myGame);
            downCommand = new DownCommand(myGame);
            leftCommand = new LeftCommand(myGame);
            rightCommand = new RightCommand(myGame);
        }

        public void BlockCollisionRespondTop(IPlayer player, IBlock block)
        {
            upCommand.Execute();
        }

        public void BlockCollisionRespondBottom(IPlayer player, IBlock block, ICollision collisionDetector)
        {
            if(!(block is EmptyBlock))
                downCommand.Execute();

            if (Mario.marioSprite.isSmall() && block is BrickBlock)
            {
            }
            else
            {
                block.BottomCollision();
            }

            if (block is BrickBlock && !Mario.marioSprite.isSmall())
                collisionDetector.BlockObjects.Remove(block);

        }

        public void BlockCollisionRespondRight(IPlayer player, IBlock block)
        {
            rightCommand.Execute();
        }

        public void BlockCollisionRespondLeft(IPlayer player, IBlock block)
        {
            leftCommand.Execute();
        }

        public void EnemyCollisionRespondTop(IPlayer player, IEnemy enemy, ICollision collisionDetector)
        {
            enemy.BeStomped();
            collisionDetector.EnemyObjects.Remove(enemy);
        }

        public void EnemyCollisionRespondBottom(IPlayer player, IEnemy enemy, ICollision collisionDetector)
        {
            if (player.IsStar)
            {
                enemy.BeStomped();
                collisionDetector.EnemyObjects.Remove(enemy);
            }
            else if (Mario.marioSprite.isFire())
            {
                Mario.marioSprite.BigMarioCommandCalled();
            }
            else if (!Mario.marioSprite.isSmall())
            {
                Mario.marioSprite.SmallMarioCommandCalled();
            }
            else
            {
                Mario.marioSprite.DeadMarioCommandCalled();
            }
            
        }

        public void EnemyCollisionRespondLeft(IPlayer player, IEnemy enemy, ICollision collisionDetector)
        {
            if (player.IsStar)
            {
                enemy.BeStomped();
                collisionDetector.EnemyObjects.Remove(enemy);
            }
            else if (Mario.marioSprite.isFire())
            {
                Mario.marioSprite.BigMarioCommandCalled();
            }
            else if (!Mario.marioSprite.isSmall())
            {
                Mario.marioSprite.SmallMarioCommandCalled();
            }
            else
            {
                Mario.marioSprite.DeadMarioCommandCalled();
            }
        }

        public void EnemyCollisionRespondRight(IPlayer player, IEnemy enemy, ICollision collisionDetector)
        {
            if (player.IsStar)
            {
                enemy.BeStomped();
                collisionDetector.EnemyObjects.Remove(enemy);
            }
            else if (Mario.marioSprite.isFire())
            {
                Mario.marioSprite.BigMarioCommandCalled();
            }
            else if (!Mario.marioSprite.isSmall())
            {
                Mario.marioSprite.SmallMarioCommandCalled();
            }
            else
            {
                Mario.marioSprite.DeadMarioCommandCalled();
            }
        }

        public void PickupCollisionRespondTop(IPlayer player, IPickup pickup, ICollision collisionDetector)
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
                player.IsStar = true;
                player = new StarMario(player, myGame);
            }

            collisionDetector.PickupObjects.Remove(pickup);
        }

        public void PickupCollisionRespondBottom(IPlayer player, IPickup pickup, ICollision collisionDetector)
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
                player.IsStar = true;
                player = new StarMario(player, myGame);
            }

            collisionDetector.PickupObjects.Remove(pickup);
        }

        public void PickupCollisionRespondLeft(IPlayer player, IPickup pickup, ICollision collisionDetector)
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
                player.IsStar = true;
                player = new StarMario(player, myGame);
            }

            collisionDetector.PickupObjects.Remove(pickup);
        }

        public void PickupCollisionRespondRight(IPlayer player, IPickup pickup, ICollision collisionDetector)
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
                player.IsStar = true;
                player = new StarMario(player, myGame);
            }

            collisionDetector.PickupObjects.Remove(pickup);
        }

        public void Update()
        {

        }
    }
}
