﻿using System;
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

            objectLevel = level;
        }

        public void BlockCollisionRespondTop(IBlock block,int height,bool standing)
        {
            if (!(block is HiddenBlock) && !standing)
                Mario.CurrentYPosition -= height;
            Mario.CanJump = true;
            Mario.Falling = false;
        }

        public void BlockCollisionRespondBottom(IBlock block,int height,bool head)
        {
            if (!head)
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
                objectLevel.BlockObjects.Add(new UsedBlock(myGame, block.GetGameObjectLocation()));
            }
            else if (block is QuestionPowerUpBlock)
            {
                objectLevel.BlockObjects.Remove(block);
                objectLevel.BlockObjects.Add(new UsedBlock(myGame, block.GetGameObjectLocation()));
                if (Mario.MarioSprite.isSmall())
                    objectLevel.PickupObjects.Add(new RedMushroom(myGame, block.GetGameObjectLocation()));
                else
                    objectLevel.PickupObjects.Add(new Fireflower(myGame, block.GetGameObjectLocation()));
            }
            else if (block is QuestionCoinBlock)
            {
                objectLevel.BlockObjects.Remove(block);
                objectLevel.BlockObjects.Add(new UsedBlock(myGame, block.GetGameObjectLocation()));
                objectLevel.PickupObjects.Add(new Coin(myGame, block.GetGameObjectLocation()));
            }

        }

        public void BlockCollisionRespondRight(IBlock block,int width,bool right)
        {
            if (!(block is HiddenBlock) && !right)
                Mario.CurrentXPosition += width;
        }

        public void BlockCollisionRespondLeft(IBlock block,int width,bool left)
        {
            if (!(block is HiddenBlock) && !left)
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
            enemy.BeFlipped(); 
        }

        public void EnemyCollisionBlockRespondYDirection(IEnemy enemy, int height,bool bottom)
        {
            // enemy.ReachGround();
            if (!bottom)
            {
                var x = enemy.GetGameObjectLocation().X;
                var y = enemy.GetGameObjectLocation().Y - height;
                enemy.SetGameObjectLocation(new Vector2(x, y));
            }
        }
        public void EnemyCollisionBlockRespondFalling(IEnemy enemy)
        {
            enemy.Falling();
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
