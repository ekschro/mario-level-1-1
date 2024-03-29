﻿using System;
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
        private MarioCollisionDetectionLogic marioLogic;
        private CollisionUtilityClass utility = new CollisionUtilityClass();
        private Game1 mygame;

        public CollisionDetect(Game1 game, ILevel PlatformerLevel)
        {
            mygame = game;
            level1 = PlatformerLevel;
            player = PlatformerLevel.PlayerObject;

            collision = new CollisionRespond(mygame, level1);
            marioLogic = new MarioCollisionDetectionLogic(PlatformerLevel,collision);
        }

        public void MarioBlockCollisionDetect()
        {
            blockArray = level1.BlockObjects.ToArray();
            enemyArray = level1.EnemyObjects.ToArray();
            bool standing = false;
            bool head = false;
            bool right = false;
            bool left = false;

            for (int i = 0; i < blockArray.Length; i++)
            {
                marioLogic.MarioBlockCollisionCheck(blockArray[i], head, standing, right, left);
            }
        }

        public void MarioEnemyCollisionDetect()
        {
            enemyArray = level1.EnemyObjects.ToArray();

            for (int i = 0; i < enemyArray.Length; i++)
            {
                marioLogic.MarioEnemyCollisionCheck(enemyArray[i]);
            }
        }

        public void MarioPickupCollisionDetect()
        {
            pickupArray = level1.PickupObjects.ToArray();

            for (int i = 0; i < pickupArray.Length; i++)
            {
                marioLogic.MarioPickupCollisionCheck(pickupArray[i]);
            }
        }

        public void BlockEnemyCollisionDetect()
        {
            Rectangle enemyBox;

            bool bottom = false;
            int size = utility.Size; 
            for (int j = 0; j < enemyArray.Length;j++)
            {
                int enemyX = (int)enemyArray[j].GameObjectLocation.X;
                int enemyY = (int)enemyArray[j].GameObjectLocation.Y;

                if (enemyArray[j] is Koopa && !enemyArray[j].IsStomped)
                {
                    enemyBox = new Rectangle(enemyX, enemyY + 8, utility.MainWidth, utility.MainHeight);
                }
                else if (enemyArray[j] is Koopa && enemyArray[j].IsStomped)
                {
                    enemyBox = new Rectangle(enemyX, enemyY + utility.Two, utility.MainWidth, utility.MainHeight);
                }
                else if (enemyArray[j] is MarioFireBall)
                {
                    enemyBox = new Rectangle(enemyX, enemyY, utility.SmallWidth, utility.SmallHeight);
                }
                else if (enemyArray[j] is Bowser)
                {
                    enemyBox = new Rectangle(enemyX, enemyY, utility.BowserSize, utility.BowserSize);
                }
                else
                {
                    enemyBox = new Rectangle(enemyX, enemyY, utility.MainWidth, utility.MainWidth);
                }
                bool fireEnemy = false;
                if (enemyArray[j] is FireEnemy)
                {
                    fireEnemy = true;
                }
                blockArray = level1.BlockObjects.ToArray();
                
                for (int i = 0; i < blockArray.Length && !fireEnemy; i++)
                {
                    int blockX = (int)blockArray[i].GameObjectLocation.X;
                    int blockY = (int)blockArray[i].GameObjectLocation.Y;

                    Rectangle intersect;
                    Rectangle blockBox = blockArray[i].BlockRectangle();

                    if (enemyBox.Intersects(blockBox))
                    {
                        Rectangle.Intersect(ref enemyBox, ref blockBox, out intersect);
                        if (intersect.Height < intersect.Width && enemyY < blockY)
                        {
                            collision.EnemyCollisionBlockRespondYDirection(enemyArray[j], intersect.Height, bottom);
                            bottom = true;
                        }
                        else if (intersect.Height > intersect.Width && enemyX < blockX)
                        {
                            collision.EnemyCollisionBlockRespondRight(enemyArray[j], enemyArray[j]);
                        }
                        else if (intersect.Height > intersect.Width && enemyX > blockX)
                        {
                            collision.EnemyCollisionBlockRespondLeft(enemyArray[j], enemyArray[j]);
                        }
                    }
                }
                size++;
            }
        }

        public void BlockPickupCollisionDetect()
        {
            Rectangle pickupBox;
            int size = utility.Size;
            for (int j = 0; j < pickupArray.Length; j++)
            {
                int pickupX = (int)pickupArray[j].GameObjectLocation.X;
                int pickupY = (int)pickupArray[j].GameObjectLocation.Y;

                pickupBox = new Rectangle(pickupX, pickupY, utility.MainWidth, utility.MainHeight);

                blockArray = level1.BlockObjects.ToArray();

                for (int i = 0; i < blockArray.Length; i++)
                {
                    int blockX = (int)blockArray[i].GameObjectLocation.X;
                    int blockY = (int)blockArray[i].GameObjectLocation.Y;
                    
                    Rectangle blockBox = blockArray[i].BlockRectangle();

                    Rectangle intersect;

                    if (pickupBox.Intersects(blockBox))
                    {
                        Rectangle.Intersect(ref pickupBox, ref blockBox, out intersect);
   
                        if (intersect.Height < intersect.Width && pickupY < blockY)
                        {
                            collision.PickupCollisionBlockRespondBottom(pickupArray[j], intersect.Height);
                        }
                        else if (intersect.Height > intersect.Width && pickupX < blockX)
                        {
                            collision.PickupCollisionBlockRespondRight(pickupArray[j], intersect.Width);
                        }
                        else if (intersect.Height > intersect.Width && pickupX > blockX)
                        {
                            collision.PickupCollisionBlockRespondLeft(pickupArray[j], intersect.Width);
                        }
                    }
                }
                size++;
            }
        }

        public void EnemyEnemyCollisionDetect()
        {
            Rectangle playerBox;
            
            for (int j = 0; j < enemyArray.Length; j++)
            {
                int enemyX = (int)enemyArray[j].GameObjectLocation.X;
                int enemyY = (int)enemyArray[j].GameObjectLocation.Y;
                playerBox = new Rectangle(enemyX, enemyY, utility.MainWidth, utility.MainHeight);

                enemyArray = level1.EnemyObjects.ToArray();

                 
                for (int i = j + 1; i < enemyArray.Length; i++)
                {
                    int enemyArrayX = (int)enemyArray[i].GameObjectLocation.X;
                    int enemyArrayY = (int)enemyArray[i].GameObjectLocation.Y;
                    Rectangle enemyBox = new Rectangle(enemyArrayX, enemyArrayY, utility.MainWidth, utility.MainHeight);
                    if (enemyArray[i] is Bowser)
                        enemyBox = new Rectangle(enemyX, enemyY, utility.BowserSize, utility.BowserSize);
                    Rectangle intersect;

                    if (playerBox.Intersects(enemyBox))
                    {
                        Rectangle.Intersect(ref playerBox, ref enemyBox, out intersect);

                        if (intersect.Height > intersect.Width && enemyX < enemyArrayX)
                        {
                            collision.EnemyCollisionEnemyRespondRight(enemyArray[j], enemyArray[i], intersect.Width);
                            collision.EnemyCollisionEnemyRespondLeft(enemyArray[i], enemyArray[j], intersect.Width);
                            
                        }
                        else if (intersect.Height > intersect.Width && enemyX > enemyArrayX)
                        {
                            collision.EnemyCollisionEnemyRespondLeft(enemyArray[j], enemyArray[i], intersect.Width);
                            collision.EnemyCollisionEnemyRespondRight(enemyArray[i], enemyArray[j], intersect.Width);
                            
                        }
                        else if (intersect.Height < intersect.Width && enemyY < enemyArrayY)
                        {
                           
                        }
                        else if (intersect.Height < intersect.Width && enemyY > enemyArrayY)
                        {
                            
                        }
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
            BlockPickupCollisionDetect();
            collision.Update();

            if (player.CurrentYPos > utility.YMax)
            {
                player.TestMario = new TestDeadMario(mygame,  (Mario)player);
                mygame.PersistentData.PlayerState = 1;
            }
        }
    }
}
