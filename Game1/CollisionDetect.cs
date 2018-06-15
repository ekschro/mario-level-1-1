using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class CollisionDetect : ICollision
    {
        private ILevel level1;
        private IPlayer player;
        private List<IBlock> blocks;
        private List<IEnemy> enemies;
        private List<IPickup> pickups;
        private CollisionRespond collision;

        public CollisionDetect(ILevel Level1)
        {
            level1 = Level1;
            player = level1.GetPlayerObject();
            blocks = level1.GetBlockObjects();
            enemies = level1.GetEnemyObjects();
            pickups = level1.GetPickupObjects();

            collision = new CollisionRespond();
        }

        public void BlockCollisionDetect()
        {
            int playerX = (int)player.GameObjectLocation().X;
            int playerY = (int)player.GameObjectLocation().Y;

            Rectangle playerBox = new Rectangle(playerX, playerY, 16, 16);

            foreach (IGameObject block in blocks)
            {
                int blockX = (int)block.GameObjectLocation().X;
                int blockY = (int)block.GameObjectLocation().Y;

                Rectangle blockBox = new Rectangle(blockX, blockY, 16, 16);
                Rectangle intersect;

                if (playerBox.Intersects(blockBox))
                {
                    Rectangle.Intersect(ref playerBox, ref blockBox, out intersect);

                    if (intersect.Height > intersect.Width && playerX < blockX)
                    {
                        collision.BlockCollisionRespondLeft(player,block);
                    }
                    else if (intersect.Height > intersect.Width && playerX > blockX)
                    {
                        collision.BlockCollisionRespondRight(player,block);
                    }
                    else if (intersect.Height < intersect.Width && playerY < blockY)
                    {
                        collision.BlockCollisionRespondTop(player,block);
                    }
                    else if (intersect.Height < intersect.Width && playerY > blockY)
                    {
                        collision.BlockCollisionRespondBottom(player,block);
                    }
                }
            }
        }

        public void EnemyCollisionDetect()
        {
            int playerX = (int)player.GameObjectLocation().X;
            int playerY = (int)player.GameObjectLocation().Y;

            Rectangle playerBox = new Rectangle(playerX, playerY, 16, 16);

            foreach (IGameObject enemy in enemies)
            {
                int enemyX = (int)enemy.GameObjectLocation().X;
                int enemyY = (int)enemy.GameObjectLocation().Y;

                Rectangle enemyBox = new Rectangle(enemyX, enemyY, 16, 16);
                Rectangle intersect;

                if (playerBox.Intersects(enemyBox))
                {
                    Rectangle.Intersect(ref playerBox, ref enemyBox, out intersect);

                    if (intersect.Height > intersect.Width && playerX < enemyX)
                    {
                        collision.BlockCollisionRespondLeft(player,enemy);
                    }
                    else if (intersect.Height > intersect.Width && playerX > enemyX)
                    {
                        collision.BlockCollisionRespondRight(player, enemy);
                    }
                    else if (intersect.Height < intersect.Width && playerY < enemyY)
                    {
                        collision.BlockCollisionRespondTop(player, enemy);
                    }
                    else if (intersect.Height < intersect.Width && playerY > enemyY)
                    {
                        collision.BlockCollisionRespondBottom(player, enemy);
                    }
                }
            }
        }

        public void PickupBlockCollisionDetect()
        {
            int playerX = (int)player.GameObjectLocation().X;
            int playerY = (int)player.GameObjectLocation().Y;

            Rectangle playerBox = new Rectangle(playerX, playerY, 16, 16);

            foreach (IGameObject pickup in pickups)
            {
                int pickupX = (int)pickup.GameObjectLocation().X;
                int pickupY = (int)pickup.GameObjectLocation().Y;

                Rectangle pickupBox = new Rectangle(pickupX, pickupY, 16, 16);
                Rectangle intersect;

                if (playerBox.Intersects(pickupBox))
                {
                    Rectangle.Intersect(ref playerBox, ref pickupBox, out intersect);

                    if (intersect.Height > intersect.Width && playerX < pickupX)
                    {
                        collision.PickupCollisionRespondLeft(player, pickup);
                    }
                    else if (intersect.Height > intersect.Width && playerX > pickupX)
                    {
                        collision.PickupCollisionRespondRight(player, pickup);
                    }
                    else if (intersect.Height < intersect.Width && playerY < pickupY)
                    {
                        collision.PickupCollisionRespondTop(player, pickup);
                    }
                    else if (intersect.Height < intersect.Width && playerY > pickupY)
                    {
                        collision.PickupCollisionRespondBottom(player, pickup);
                    }
                }
            }
        }

        public void Update()
        {
            BlockCollisionDetect();
            EnemyCollisionDetect();
            PickupBlockCollisionDetect();
        }
    }
}
