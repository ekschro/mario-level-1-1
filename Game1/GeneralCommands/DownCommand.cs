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
    public class DownCommand : ICommand
    {
        private int timer;
        //private Game1 myGame;
        

        public DownCommand()
        {
            //myGame = game;
            timer = 0;
           
        }

        public void Execute()
        {
            if (timer == 5) {
                Mario.playerSprite.DownCommandCalled();
                timer = 0;
            }
            else
            {
                timer++;
            }

            
            Mario.CurrentYPosition = Mario.CurrentYPosition + 1;
        }
    }
}