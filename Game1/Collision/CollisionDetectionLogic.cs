using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class MarioCollisionDetectionLogic
    {
        private IPlayer player;
        private CollisionRespond collisionRes;
        private IControllerHandler controllerHandler;

        private Rectangle GetMarioRectangle(ref int playerX, ref int playerY)
        {
            if (player.TestMario.GetStateMachine.IsCrouching())
                playerY += 16;

            if (player.TestMario.GetStateMachine is TestSmallMarioStateMachine || player.TestMario.GetStateMachine.IsCrouching())
                return new Rectangle(playerX, playerY, 16, 16);
            else
                return new Rectangle(playerX, playerY, 16, 32);
        }

        public MarioCollisionDetectionLogic(Game1 game,ILevel level,CollisionRespond res)
        {
            player = level.PlayerObject;
            collisionRes = res;
            controllerHandler = new ControllerHandler();
        }

        public void MarioBlockCollisionCheck(IBlock block, bool head, bool standing, bool right, bool left)
        {
            var playerY = (int)player.GetGameObjectLocation().Y;
            var playerX = (int)player.GetGameObjectLocation().X;

            Rectangle playerBox = GetMarioRectangle(ref playerX, ref playerY);

            int blockX = (int)block.GetGameObjectLocation().X;
            int blockY = (int)block.GetGameObjectLocation().Y;

            Rectangle blockBox;

            if (!(block is StoneBlock))
                blockBox = block.BlockRectangle();
            else
            {
                StoneBlock sblock = (StoneBlock)block;
                blockBox = new Rectangle(blockX, blockY, (int)sblock.BlockSize.X, (int)sblock.BlockSize.Y);
            }

            Rectangle intersect;

            if (playerBox.Intersects(blockBox))
            {
                Rectangle.Intersect(ref playerBox, ref blockBox, out intersect);

                if (intersect.Height < intersect.Width && playerY < blockY && !(block is HiddenGreenMushroomBlock))
                {
                    collisionRes.BlockCollisionRespondTop(block, intersect.Height, standing);
                    standing = true;
                }
                else if (intersect.Height < intersect.Width && playerY > blockY) //Temp fix
                {
                    collisionRes.BlockCollisionRespondBottom(block, intersect.Height, head);
                    head = true;
                }
                //An unhandled exception of type 'System.NullReferenceException' occurred in Game1.exe   Object reference not set to an instance of an object.    ControllerHandler == null
                else if (intersect.Height < intersect.Width && playerY > blockY && controllerHandler.MovingUp)
                {
                    collisionRes.BlockCollisionRespondBottom(block, intersect.Height, head);
                    head = true;
                }
                else if (intersect.Height - 3 > intersect.Width && playerX < blockX && !(block is HiddenGreenMushroomBlock))
                {
                    collisionRes.BlockCollisionRespondLeft(block, intersect.Width, left);
                    left = true;
                }
                else if (intersect.Height - 3 > intersect.Width && playerX > blockX && !(block is HiddenGreenMushroomBlock))
                {
                    collisionRes.BlockCollisionRespondRight(block, intersect.Width, right);
                    right = true;
                }
            }
        }

        public void MarioEnemyCollisionCheck(IEnemy enemy)
        {
            var playerY = (int)player.GetGameObjectLocation().Y;
            var playerX = (int)player.GetGameObjectLocation().X;

            Rectangle playerBox = GetMarioRectangle(ref playerX, ref playerY);

            int enemyX = (int)enemy.GetGameObjectLocation().X;
            int enemyY = (int)enemy.GetGameObjectLocation().Y;

            Rectangle enemyBox = new Rectangle(enemyX, enemyY, 16, 16);
            Rectangle intersect;

            if (enemy is Koopa)
            {
                enemyBox = new Rectangle(enemyX, enemyY + 8, 16, 16);
            }
            else
            {
                enemyBox = new Rectangle(enemyX, enemyY, 16, 16);
            }

            if (playerBox.Intersects(enemyBox))
            {
                Rectangle.Intersect(ref playerBox, ref enemyBox, out intersect);

                if (intersect.Height > intersect.Width && playerX < enemyX)
                {
                    collisionRes.EnemyCollisionRespondLeft(enemy);
                }
                else if (intersect.Height > intersect.Width && playerX > enemyX)
                {
                    collisionRes.EnemyCollisionRespondRight(enemy);
                }
                else if (intersect.Height < intersect.Width && playerY < enemyY)
                {
                    collisionRes.EnemyCollisionRespondTop(enemy);
                }
                else if (intersect.Height < intersect.Width && playerY > enemyY - 4)
                {
                    collisionRes.EnemyCollisionRespondBottom(enemy);
                }
            }
        }

        public void MarioPickupCollisionCheck(IPickup pickup)
        {
            var playerY = (int)player.GetGameObjectLocation().Y;
            var playerX = (int)player.GetGameObjectLocation().X;

            Rectangle playerBox = GetMarioRectangle(ref playerX, ref playerY);

            int pickupX = (int)pickup.GetGameObjectLocation().X;
            int pickupY = (int)pickup.GetGameObjectLocation().Y;

            Rectangle pickupBox = new Rectangle(pickupX, pickupY, 16, 16);
            Rectangle intersect;

            if (playerBox.Intersects(pickupBox))
            {
                Rectangle.Intersect(ref playerBox, ref pickupBox, out intersect);

                if (intersect.Height > intersect.Width && playerX < pickupX)
                {
                    collisionRes.PickupCollisionRespondLeft(pickup);
                }
                else if (intersect.Height > intersect.Width && playerX > pickupX)
                {
                    collisionRes.PickupCollisionRespondRight(pickup);
                }
                else if (intersect.Height < intersect.Width && playerY < pickupY)
                {
                    collisionRes.PickupCollisionRespondTop(pickup);
                }
                else if (intersect.Height < intersect.Width && playerY > pickupY)
                {
                    collisionRes.PickupCollisionRespondBottom(pickup);
                }
            }
        }
    }
}
