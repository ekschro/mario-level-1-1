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
        private List<Action> commandArray;
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

        public void MarioBlockCollisionDetect()
        {
            int playerX = (int)player.GetGameObjectLocation().X;
            int playerY = (int)player.GetGameObjectLocation().Y;
            Rectangle playerBox;

            if (Mario.MarioSprite.isCrouching())
                playerY = playerY + tileOffset;
            

            if (Mario.MarioSprite.isSmall() || Mario.MarioSprite.isCrouching())
                playerBox = new Rectangle(playerX, playerY, 16, 16);
            else
                playerBox = new Rectangle(playerX, playerY, 16, 32);

            blockArray = level1.BlockObjects.ToArray();

            //Consider array??
            bool standing = false;
            bool head = false;
            bool right = false;
            bool left = false;

            for (int i = 0; i < blockArray.Length; i++)
            {
                int blockX = (int)blockArray[i].GetGameObjectLocation().X;
                int blockY = (int)blockArray[i].GetGameObjectLocation().Y;

                Rectangle blockBox = new Rectangle(blockX, blockY, 16, 16);
                Rectangle intersect;

                if (playerBox.Intersects(blockBox))
                {
                    Rectangle.Intersect(ref playerBox, ref blockBox, out intersect);

                    if (intersect.Height < intersect.Width && playerY < blockY)
                    {
                        collision.BlockCollisionRespondTop(blockArray[i],intersect.Height,standing);
                        standing = true;
                    }
                    else if (intersect.Height < intersect.Width && playerY > blockY && !(blockArray[i] is HiddenBlock)) //Temp fix
                    {
                        collision.BlockCollisionRespondBottom(blockArray[i],intersect.Height,head);
                        head = true;
                    }
                    else if (intersect.Height < intersect.Width && playerY > blockY /*&& (blockArray[i] is HiddenBlock)*/ && Mario.MovingUp)
                    {
                        collision.BlockCollisionRespondBottom(blockArray[i],intersect.Height,head);
                        head = true;
                    }
                    else if (intersect.Height - 3 > intersect.Width && playerX < blockX)
                    {
                        collision.BlockCollisionRespondLeft(blockArray[i], intersect.Width,left);
                        left = true;
                    }
                    else if (intersect.Height - 3 > intersect.Width && playerX > blockX)
                    {
                        collision.BlockCollisionRespondRight(blockArray[i], intersect.Width,right);
                        right = true;
                    }
                }
            }
        }

        public void BlockEnemyCollisionDetect()
        {
            Rectangle playerBox;

            bool bottom = false;
            int size = 0; 
            for (int j = 0; j < enemyArray.Length;j++)
            {
                int enemyX = (int)enemyArray[j].GetGameObjectLocation().X;
                int enemyY = (int)enemyArray[j].GetGameObjectLocation().Y;
                playerBox = new Rectangle(enemyX, enemyY, 16, 16);

                blockArray = level1.BlockObjects.ToArray();
                
                for (int i = 0; i < blockArray.Length; i++)
                {
                    int blockX = (int)blockArray[i].GetGameObjectLocation().X;
                    int blockY = (int)blockArray[i].GetGameObjectLocation().Y;

                    Rectangle blockBox = new Rectangle(blockX, blockY, 16, 16);
                    Rectangle intersect;

                    if (playerBox.Intersects(blockBox))
                    {
                        Rectangle.Intersect(ref playerBox, ref blockBox, out intersect);
                        if (intersect.Height < intersect.Width && enemyY < blockY && enemyArray[j] is MarioFireBall)
                        {
                            MarioFireBall x = (MarioFireBall)enemyArray[j];
                            x.Update();
                        }
                        else if (intersect.Height > intersect.Width && enemyX < blockX && enemyArray[j] is MarioFireBall)
                        {
                            level1.EnemyObjects.RemoveAt(size);
                            size--;
                            
                        }
                        else if (intersect.Height > intersect.Width && enemyX > blockX && enemyArray[j] is MarioFireBall)
                        {
                            level1.EnemyObjects.RemoveAt(size);
                            size--;

                        } else if (intersect.Height < intersect.Width && enemyY < blockY)
                        {
                            collision.EnemyCollisionBlockRespondYDirection(enemyArray[j], intersect.Height, bottom);
                            bottom = true;
                        }
                        else if (intersect.Height > intersect.Width && enemyX < blockX)
                        {
                            Console.WriteLine("Collision!");
                            collision.EnemyCollisionBlockandEnemyRespondRight(enemyArray[j], intersect.Width);
                        }
                        else if (intersect.Height > intersect.Width && enemyX > blockX)
                        {
                            Console.WriteLine("Collision!!");
                            collision.EnemyCollisionBlockandEnemyRespondLeft(enemyArray[j], intersect.Width);
                        }
                    }
                }
                size++;
            }
        }
        public void EnemyEnemyCollisionDetect()
        {
            Rectangle playerBox;

            bool bottom = false;
            int size = 0;
            for (int j = 0; j < enemyArray.Length; j++)
            {
                int enemyX = (int)enemyArray[j].GetGameObjectLocation().X;
                int enemyY = (int)enemyArray[j].GetGameObjectLocation().Y;
                playerBox = new Rectangle(enemyX, enemyY, 16, 16);

                enemyArray = level1.EnemyObjects.ToArray();

                for (int i = 0; i < enemyArray.Length; i++)
                {
                    int enemyArrayX = (int)enemyArray[i].GetGameObjectLocation().X;
                    int enemyArrayY = (int)enemyArray[i].GetGameObjectLocation().Y;

                    Rectangle enemyBox = new Rectangle(enemyArrayX, enemyArrayY, 16, 16);
                    Rectangle intersect;

                    if (playerBox.Intersects(enemyBox))
                    {
                        Rectangle.Intersect(ref playerBox, ref enemyBox, out intersect);

                        if (intersect.Height > intersect.Width && enemyX < enemyArrayX)
                        {
                            collision.EnemyCollisionBlockandEnemyRespondRight(enemyArray[j], intersect.Width);
                            collision.EnemyCollisionBlockandEnemyRespondLeft(enemyArray[i], intersect.Width);
                            //collision.EnemyCollisionBlockandEnemyRespondXDirection(enemyArray[i], intersect.Width, true); ;
                        }
                        else if (intersect.Height > intersect.Width && enemyX > enemyArrayX)
                        {
                            collision.EnemyCollisionBlockandEnemyRespondLeft(enemyArray[j], intersect.Width);
                            collision.EnemyCollisionBlockandEnemyRespondRight(enemyArray[i], intersect.Width);
                            //collision.EnemyCollisionBlockandEnemyRespondXDirection(enemyArray[i], intersect.Width, true);
                        }
                        else if (intersect.Height < intersect.Width && enemyY < enemyArrayY)
                        {
                            //collision.EnemyCollisionRespondTop(enemyArray[i]);
                        }
                        else if (intersect.Height < intersect.Width && enemyY > enemyArrayY)
                        {
                            //collision.EnemyCollisionRespondBottom(enemyArray[i]);
                        }
                    }
                }
            }
        }
        public void MarioEnemyCollisionDetect()
        {
            int playerX = (int)player.GetGameObjectLocation().X;
            int playerY = (int)player.GetGameObjectLocation().Y;
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
                int enemyX = (int)enemyArray[i].GetGameObjectLocation().X;
                int enemyY = (int)enemyArray[i].GetGameObjectLocation().Y;

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

        public void MarioPickupCollisionDetect()
        {
            int playerX = (int)player.GetGameObjectLocation().X;
            int playerY = (int)player.GetGameObjectLocation().Y;
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
                int pickupX = (int)pickupArray[i].GetGameObjectLocation().X;
                int pickupY = (int)pickupArray[i].GetGameObjectLocation().Y;

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
            MarioBlockCollisionDetect();
            MarioEnemyCollisionDetect();
            MarioPickupCollisionDetect();
            BlockEnemyCollisionDetect();
            EnemyEnemyCollisionDetect();
            collision.Update();
        }
    }
}
