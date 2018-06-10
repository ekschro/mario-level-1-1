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
        private Game1 myGame;
        private Mario marioObject;

        public DownCommand(Game1 game, Mario mario)
        {
            myGame = game;
            timer = 0;
            marioObject = mario;
        }

        public void Execute()
        {
            if (timer == 5) {
                marioObject.marioSprite.DownCommandCalled();
                timer = 0;
            }
            else
            {
                timer++;
            }
                
            marioObject.DownHeld();
            marioObject.Update();
        }
    }
}