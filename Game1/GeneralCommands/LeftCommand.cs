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

    public class LeftCommand : ICommand
    {
        private Game1 myGame;
        private int timer;
        
        public LeftCommand(Game1 game)
        {
            myGame = game;
            timer = 0;
            
        }

        public void Execute()
        {

            if (timer == 5)
            {
                Mario.marioSprite.LeftCommandCalled();
                timer = 0;
            }else
            {
                timer++;
            }



            Mario.up = false;
            Mario.down = false;
            Mario.right = false;
            Mario.left = true;
            Mario.currentXPosition = Mario.currentXPosition - 1;
        }
    }
}