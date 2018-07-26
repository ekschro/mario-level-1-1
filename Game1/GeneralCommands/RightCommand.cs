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
    public class RightCommand : ICommand
    {
       
        private IControllerHandler controllerHandler;
        private Game1 myGame;
        
        public RightCommand(Game1 game)
        {
           
            controllerHandler = game.controllerHandler;
            myGame = game;
        }

        public void Execute()
        {
            if (!myGame.CurrentLevel.PlayerObject.TestMario.StateMachine.IsCrouching())
            {
                controllerHandler.MovingRight = true;
                controllerHandler.MovingLeft = false;
            }
        }
    }
}