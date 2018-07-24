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
       
        private IControllerHandler controllerHandler;
        
        public LeftCommand(Game1 game)
        {
            
            controllerHandler = game.controllerHandler; 
        }

        public void Execute()
        {
            controllerHandler.MovingLeft = true;
            controllerHandler.MovingRight = false;
        }
    }
}