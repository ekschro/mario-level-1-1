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
        private Mario marioObject;
        public UpCommand(Game1 game, Mario mario)
        {
            myGame = game;
            timer = 0;
            marioObject = mario;
        }

        public void Execute()
        {
            if (timer == 5)
            {
                marioObject.marioSprite.UpCommandCalled();
                timer = 0;
            }
            else
            {
                timer++;
            }
                   
            
            marioObject.UpHeld();
            marioObject.Update();
        }
    }
}