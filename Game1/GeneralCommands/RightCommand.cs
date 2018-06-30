using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Game1
{
    public class RightCommand : ICommand
    {
        private Game1 myGame;
        private IPlayer player;
        private int timer;
        
        public RightCommand(Game1 game)
        {
            myGame = game;
            player = game.CurrentLevel.PlayerObject;
            timer = 0;
        }

        public void Execute()
        {
            if (timer == 5)
            {
                player.MarioSprite.RightCommandCalled();
                timer = 0;
            } else
            {
                timer++;
            }
            
            player.MovingRight = true;
            player.MovingLeft = false;
        }
    }
}