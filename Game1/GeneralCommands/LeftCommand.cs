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
        //private Game1 myGame;
        private int timer;
        
        public LeftCommand()
        {
            //myGame = game;
            timer = 0;
            
        }

        public void Execute()
        {

            if (timer == 5)
            {
                Mario.MarioSprite.LeftCommandCalled();
                timer = 0;
            }else
            {
                timer++;
            }



            
            Mario.MovingRight = false;
            Mario.MovingLeft = true;
            Mario.NewXPos();
        }
    }
}