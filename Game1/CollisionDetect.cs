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
        private IBlock[] blockArray;
        private IEnemy[] enemyArray;
        private IPickup[] pickupArray;
        private CollisionRespond collision;
        private Game1 mygame;
        private int tileOffset = 16;


        public CollisionDetect(Game1 game, ILevel Level1)
        {
            mygame = game;

            level1 = Level1;
            player = Level1.PlayerObject;

            collision = new CollisionRespond(mygame, level1);
        }

        public void BlockCollisionDetect()
        {
            int playerX = (int)player.GameObjectLocation().X;
            int playerY = (int)player.GameObjectLocation().Y;
            Rectangle playerBox;

            if (Mario.MarioSprite.isCrouching())
                playerY = playerY + tileOffset;
            

            if (Mario.MarioSprite.isSmall() || Mario.MarioSprite.isCrouching())
                playerBox = new Rectangle(playerX, playerY, 16, 16);
            else
                playerBox = new Rectangle(playerX, playerY, 16, 32);

            blockArray = level1.BlockObjects.ToArray();

            for (int i = 0; i < blockArray.Length; i++)
            {
                int blockX = (int)blockArray[i].GameObjectLocation().X;
                int blockY = (int)blockArray[i].GameObjectLocation().Y;

                Rectangle blockBox = new Rectangle(blockX, blockY, 16, 16);
                Rectangle intersect;

                if (playerBox.Intersects(blockBox))
                {
                    Rectangle.Intersect(ref playerBox, ref blockBox, out intersect);

                    if (intersect.Height < intersect.Width && playerY < blockY)
                    {
                        collision.BlockCollisionRespondTop(blockArray[i],intersect.Height);
                    }
                    else if (intersect.Height < intersect.Width && playerY > blockY && !(blockArray[i] is HiddenBlock)) //Temp fix
                    {
                        collision.BlockCollisionRespondBottom(blockArray[i],intersect.Height);
                    }
                    else if (intersect.Height < intersect.Width && playerY > blockY && !(blockArray[i] is HiddenBlock) && Mario.MovingUp)
                    {
                        collision.BlockCollisionRespondBottom(blockArray[i],intersect.Height);
                    }
                    else if (intersect.Height - 3 > intersect.Width && playerX < blockX)
                    {
                        Console.Write("Height: ");
                        Console.WriteLine(intersect.Height - 3 );
                        Console.Write("Width: ");
                        Console.WriteLine(intersect.Width);
                        collision.BlockCollisionRespondLeft(blockArray[i], intersect.Width);
                    }
                    else if (intersect.Height -3 > intersect.Width && playerX > blockX)
                    {
                        collision.BlockCollisionRespondRight(blockArray[i], intersect.Width);
                    }

                }
            }
        }

        public void BlockEnemyCollisionDetect()
        {
            int playerX = (int)player.GameObjectLocation().X;
            int playerY = (int)player.GameObjectLocation().Y;
            Rectangle playerBox;

            for (int j = 0; j < enemyArray.Length;j++)
            {
                int enemyX = (int)enemyArray[j].GameObjectLocation().X;
                int enemyY = (int)enemyArray[j].GameObjectLocation().Y;
                playerBox = new Rectangle(enemyX, enemyY, 16, 16);

                blockArray = level1.BlockObjects.ToArray();

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
                            collision.EnemyCollisionBlockRespondXDirection(enemyArray[j]);
                        }
                        else if (intersect.Height > intersect.Width && playerX > blockX)
                        {
                            collision.EnemyCollisionBlockRespondXDirection(enemyArray[j]);
                        }
                        else if (intersect.Height < intersect.Width && playerY < blockY)
                        {
                            //collision.BlockCollisionRespondTop(blockArray[i]);
                        }
                        else if (intersect.Height < intersect.Width && playerY > blockY + 14 && (blockArray[i] is HiddenBlock) && Mario.MovingUp)
                        {
                            //collision.BlockCollisionRespondBottom(blockArray[i]);
                        }

                    }
                }
            }
        }

        public void EnemyCollisionDetect()
        {
            int playerX = (int)player.GameObjectLocation().X;
            int playerY = (int)player.GameObjectLocation().Y;
            Rectangle playerBox;

            if (Mario.MarioSprite.isCrouching())
                playerY = playerY + tileOffset;

            if (Mario.MarioSprite.isSmall())
                playerBox = new Rectangle(playerX, playerY, 16, 16);
            else
                playerBox = new Rectangle(playerX, playerY, 16, 32);

            enemyArray = level1.EnemyObjects.ToArray();

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
                        collision.EnemyCollisionRespondLeft( enemyArray[i]);
                    }
                    else if (intersect.Height > intersect.Width && playerX > enemyX)
                    {
                        collision.EnemyCollisionRespondRight( enemyArray[i]);
                    }
                    else if (intersect.Height < intersect.Width && playerY < enemyY)
                    {
                        collision.EnemyCollisionRespondTop( enemyArray[i]);
                    }
                    else if (intersect.Height < intersect.Width && playerY > enemyY)
                    {
                        collision.EnemyCollisionRespondBottom( enemyArray[i]);
                    }
                }
            }
        }

        public void PickupBlockCollisionDetect()
        {
            int playerX = (int)player.GameObjectLocation().X;
            int playerY = (int)player.GameObjectLocation().Y;
            Rectangle playerBox;

            if (Mario.MarioSprite.isCrouching())
                playerY = playerY + tileOffset;

            if (Mario.MarioSprite.isSmall())
                playerBox = new Rectangle(playerX, playerY, 16, 16);
            else
                playerBox = new Rectangle(playerX, playerY, 16, 32);

            pickupArray = level1.PickupObjects.ToArray();

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
                        collision.PickupCollisionRespondLeft( pickupArray[i]);
                    }
                    else if (intersect.Height > intersect.Width && playerX > pickupX)
                    {
                        collision.PickupCollisionRespondRight(pickupArray[i]);
                    }
                    else if (intersect.Height < intersect.Width && playerY < pickupY)
                    {
                        collision.PickupCollisionRespondTop(pickupArray[i]);
                    }
                    else if (intersect.Height < intersect.Width && playerY > pickupY)
                    {
                        collision.PickupCollisionRespondBottom(pickupArray[i]);
                    }
                }
            }
        }

        public void Update()
        {
            BlockCollisionDetect();
            EnemyCollisionDetect();
            PickupBlockCollisionDetect();
            BlockEnemyCollisionDetect();
            collision.Update();
        }
    }
}
