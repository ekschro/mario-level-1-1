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
        private Game1 mygame;

        ICommand upCommand;
        ICommand downCommand;
        ICommand leftCommand;
        ICommand rightCommand;

        public CollisionRespond(Game1 game)
        {
            mygame = game;

            upCommand = new UpCommand(mygame);
            downCommand = new DownCommand(mygame);
            leftCommand = new LeftCommand(mygame);
            rightCommand = new RightCommand(mygame);
        }

        public void BlockCollisionRespondTop(IPlayer player, IBlock block)
        {
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

        }

        public void BlockCollisionRespondRight(IPlayer player, IBlock block)
        {
            rightCommand.Execute();
        }

        public void BlockCollisionRespondLeft(IPlayer player, IBlock block)
        {
            leftCommand.Execute();
        }

        public void EnemyCollisionRespondTop(IPlayer player, IEnemy enemy)
        {
            enemy.BeStomped();
        }

        public void EnemyCollisionRespondBottom(IPlayer player, IEnemy enemy)
        {
            if (player.IsStar())
            {
                enemy.BeStomped();
            }
            else if (!Mario.marioSprite.isSmall() || Mario.marioSprite.isFire())
            {
                Mario.marioSprite.SmallMarioCommandCalled();
            }
            else
            {
                Mario.marioSprite.DeadMarioCommandCalled();
            }
            
        }

        public void EnemyCollisionRespondLeft(IPlayer player, IEnemy enemy)
        {
            if (player.IsStar())
            {
                enemy.BeStomped();
            }
            else if (!Mario.marioSprite.isSmall() || Mario.marioSprite.isFire())
            {
                Mario.marioSprite.SmallMarioCommandCalled();
            }
            else
            {
                Mario.marioSprite.DeadMarioCommandCalled();
            }
        }

        public void EnemyCollisionRespondRight(IPlayer player, IEnemy enemy)
        {
            if (player.IsStar())
            {
                enemy.BeStomped();
            }
            else if (!Mario.marioSprite.isSmall() || Mario.marioSprite.isFire())
            {
                Mario.marioSprite.SmallMarioCommandCalled();
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
                player = new StarMario(player, mygame);
            }
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
                player = new StarMario(player, mygame);
            }
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
                player = new StarMario(player, mygame);
            }
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
                player = new StarMario(player, mygame);
            }
        }

        public void Update()
        {

        }
    }
}
