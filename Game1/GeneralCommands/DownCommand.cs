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

        public DownCommand(Game1 game)
        {
            myGame = game;
            timer = 0;
        }

        public void Execute()
        {
            if (timer == 5) {
                myGame.marioSprite.DownCommandCalled();
                timer = 0;
            }
            else
            {
                timer++;
            }
                
            myGame.marioObject.DownHeld();
            myGame.marioObject.Update();
        }
    }
}