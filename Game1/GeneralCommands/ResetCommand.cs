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
    public class ResetCommand : ICommand
    {
        private Game1 myGame;
        private IControllerHandler controllerHandler;

        public ResetCommand(Game1 game)
        {
            myGame = game;
            controllerHandler = game.controllerHandler;
        }

        public void Execute()
        {
            myGame.GameReset();
            myGame.HudCounter = 0;
            controllerHandler.MovingDown = false;
            controllerHandler.MovingUp = false;
            controllerHandler.MovingRight = false;
            controllerHandler.MovingLeft = false;
        }
    }
}