﻿using Microsoft.Xna.Framework;
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
        private CollisionUtilityClass utility = new CollisionUtilityClass();

        private Rectangle GetMarioRectangle(ref int playerX, ref int playerY)
        {
            if (player.TestMario.StateMachine.IsCrouching()||player.TestMario is TestSmallMario)
                playerY += utility.MainHeight;

            if (player.TestMario.StateMachine is TestSmallMarioStateMachine || player.TestMario.StateMachine.IsCrouching())
                return new Rectangle(playerX, playerY, utility.MainWidth, utility.MainHeight);
            else
                return new Rectangle(playerX, playerY, utility.MainWidth, utility.BiggerHeight);
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

            Rectangle blockBox = block.BlockRectangle();

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

            Rectangle enemyBox = new Rectangle(enemyX, enemyY, utility.MainWidth, utility.MainHeight);
            Rectangle intersect;

            if (enemy is Koopa)
            {
                enemyBox = new Rectangle(enemyX, enemyY + utility.Eight, utility.MainWidth, utility.MainHeight);
            }
            else
            {
                enemyBox = new Rectangle(enemyX, enemyY, utility.MainWidth, utility.MainHeight);
            }

            if (playerBox.Intersects(enemyBox))
            {
                Rectangle.Intersect(ref playerBox, ref enemyBox, out intersect);

                if (intersect.Height*utility.EnemyCollisionFudge > intersect.Width && playerX < enemyX)
                {
                    collisionRes.EnemyCollisionRespondLeft(enemy);
                }
                else if (intersect.Height*utility.EnemyCollisionFudge > intersect.Width && playerX > enemyX)
                {
                    collisionRes.EnemyCollisionRespondRight(enemy);
                }
                else if (intersect.Height < intersect.Width && playerY < enemyY)
                {
                    collisionRes.EnemyCollisionRespondTop(enemy);
                }
                else if (intersect.Height < intersect.Width && playerY > enemyY - utility.Four)
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

            Rectangle pickupBox = new Rectangle(pickupX, pickupY, utility.MainWidth, utility.MainHeight);

            if (playerBox.Intersects(pickupBox))
            {
                collisionRes.PickupCollisionRespond(pickup);
            }
        }
    }
}
