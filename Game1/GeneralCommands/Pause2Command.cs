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
    public class Pause2Command : ICommand
    {
        private Game1 myGame;
        private IControllerHandler controllerHandler;

        public Pause2Command(Game1 game)
        {
            myGame = game;
            controllerHandler = game.ControllerHandler;
        }

        public void Execute()
        {
            if (myGame.Pause)
            {
                myGame.Pause = false;
            } else
            {
                myGame.Pause = true;
            }
        }
    }
}