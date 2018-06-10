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
    public class UpCommand : ICommand
    {
        private Game1 myGame;
        private int timer;
        
        public UpCommand(Game1 game)
        {
            myGame = game;
            timer = 0;
            
        }

        public void Execute()
        {
            if (timer == 5)
            {
                Mario.marioSprite.UpCommandCalled();
                timer = 0;
            }
            else
            {
                timer++;
            }


            Mario.up = true;
            Mario.down = false;
            Mario.right = false;
            Mario.left = false;
            Mario.currentYPosition = Mario.currentYPosition - 1;
        }
    }
}