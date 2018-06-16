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
        public List<IBlock> blocks;
        private IBlock[] blockArray;
        private List<IEnemy> enemies;
        private IEnemy[] enemyArray;
        private List<IPickup> pickups;
        private IPickup[] pickupArray;
        private CollisionRespond collision;
        private Game1 mygame;
        List<IBlock> ICollision.BlockObjects { get => blocks; set => blocks = value; }
        List<IEnemy> ICollision.EnemyObjects { get => enemies; set => enemies = value; }
        List<IPickup> ICollision.PickupObjects { get => pickups; set => pickups = value; }

        public CollisionDetect(Game1 game, ILevel Level1)
        {
            mygame = game;

            level1 = Level1;
            player = level1.GetPlayerObject();
            blocks = level1.GetBlockObjects();
            enemies = level1.GetEnemyObjects();
            pickups = level1.GetPickupObjects();

            collision = new CollisionRespond(mygame);
        }

        public void BlockCollisionDetect()
        {
            int playerX = (int)player.GameObjectLocation().X;
            int playerY = (int)player.GameObjectLocation().Y;
            Rectangle playerBox;

            if (Mario.marioSprite.isSmall())
                playerBox = new Rectangle(playerX, playerY, 16, 16);
            else
                playerBox = new Rectangle(playerX, playerY, 16, 32);

            blockArray = blocks.ToArray();

            for (int i = 0; i < blockArray.Length; i++)
            {
                int blockX = (int)blockArray[i].GameObjectLocation().X;
                int blockY = (int)blockArray[i].GameObjectLocation().Y;

                Rectangle blockBox = new Rectangle(blockX, blockY, 16, 16);
                Rectangle intersect;

                if (playerBox.Intersects(blockBox))
                {
                    Rectangle.Intersect(ref playerBox, ref blockBox, out intersect);

                    if (intersect.Height > intersect.Width && playerX < blockX)
                    {
                        collision.BlockCollisionRespondLeft(player, blockArray[i]);
                    }
                    else if (intersect.Height > intersect.Width && playerX > blockX)
                    {
                        collision.BlockCollisionRespondRight(player, blockArray[i]);
                    }
                    else if (intersect.Height < intersect.Width && playerY < blockY)
                    {
                        collision.BlockCollisionRespondTop(player, blockArray[i]);
                    }
                    else if (intersect.Height < intersect.Width && playerY > blockY)
                    {
                        collision.BlockCollisionRespondBottom(player, blockArray[i], this);
                    }
                }
            }
        }

        public void EnemyCollisionDetect()
        {
            int playerX = (int)player.GameObjectLocation().X;
            int playerY = (int)player.GameObjectLocation().Y;
            Rectangle playerBox;

            if (Mario.marioSprite.isSmall()) 
                playerBox = new Rectangle(playerX, playerY, 16, 16);
            else
                playerBox = new Rectangle(playerX, playerY, 16, 32);

            enemyArray = enemies.ToArray();

            for (int i = 0; i < enemyArray.Length; i++)
            {
                int enemyX = (int)enemyArray[i].GameObjectLocation().X;
                int enemyY = (int)enemyArray[i].GameObjectLocation().Y;

                Rectangle enemyBox = new Rectangle(enemyX, enemyY, 16, 16);
                Rectangle intersect;

                if (playerBox.Intersects(enemyBox))
                {
                    Rectangle.Intersect(ref playerBox, ref enemyBox, out intersect);

                    if (intersect.Height > intersect.Width && playerX < enemyX)
                    {
                        collision.EnemyCollisionRespondLeft(player,enemyArray[i], this);
                    }
                    else if (intersect.Height > intersect.Width && playerX > enemyX)
                    {
                        collision.EnemyCollisionRespondRight(player, enemyArray[i], this);
                    }
                    else if (intersect.Height < intersect.Width && playerY < enemyY)
                    {
                        collision.EnemyCollisionRespondTop(player, enemyArray[i], this);
                    }
                    else if (intersect.Height < intersect.Width && playerY > enemyY)
                    {
                        collision.EnemyCollisionRespondBottom(player, enemyArray[i], this);
                    }
                }
            }
        }

        public void PickupBlockCollisionDetect()
        {
            int playerX = (int)player.GameObjectLocation().X;
            int playerY = (int)player.GameObjectLocation().Y;
            Rectangle playerBox;

            if (Mario.marioSprite.isSmall())
                playerBox = new Rectangle(playerX, playerY, 16, 16);
            else
                playerBox = new Rectangle(playerX, playerY, 16, 32);

            pickupArray = pickups.ToArray();

            for (int i = 0; i < pickupArray.Length; i++)
            {
                int pickupX = (int)pickupArray[i].GameObjectLocation().X;
                int pickupY = (int)pickupArray[i].GameObjectLocation().Y;

                Rectangle pickupBox = new Rectangle(pickupX, pickupY, 16, 16);
                Rectangle intersect;

                if (playerBox.Intersects(pickupBox))
                {
                    Rectangle.Intersect(ref playerBox, ref pickupBox, out intersect);

                    if (intersect.Height > intersect.Width && playerX < pickupX)
                    {
                        collision.PickupCollisionRespondLeft(player, pickupArray[i], this);
                    }
                    else if (intersect.Height > intersect.Width && playerX > pickupX)
                    {
                        collision.PickupCollisionRespondRight(player, pickupArray[i], this);
                    }
                    else if (intersect.Height < intersect.Width && playerY < pickupY)
                    {
                        collision.PickupCollisionRespondTop(player, pickupArray[i], this);
                    }
                    else if (intersect.Height < intersect.Width && playerY > pickupY)
                    {
                        collision.PickupCollisionRespondBottom(player, pickupArray[i], this);
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
