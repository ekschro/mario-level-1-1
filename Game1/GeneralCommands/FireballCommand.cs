﻿using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Game1
{
    public class FireballCommand : ICommand
    {
        private IControllerHandler controllerHandler;

        public FireballCommand(Game1 game)
        {
            controllerHandler = game.ControllerHandler;
        }

        public void Execute()
        {
            controllerHandler.FireBallHeld = true;
        }
    }
}
 