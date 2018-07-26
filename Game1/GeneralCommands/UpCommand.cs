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
        private IControllerHandler controllerHandler;
        
        public UpCommand(Game1 game)
        {
            controllerHandler = game.ControllerHandler;
        }

        public void Execute()
        {
            controllerHandler.MovingUp = true;
        }
    }
}