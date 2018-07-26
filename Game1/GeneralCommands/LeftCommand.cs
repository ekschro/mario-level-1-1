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
        Game1 myGame;
        
        public LeftCommand(Game1 game)
        {
            
            controllerHandler = game.ControllerHandler;
            myGame = game;
        }

        public void Execute()
        {
            if (!(myGame.CurrentLevel.PlayerObject.TestMario.StateMachine.IsCrouching()))
            {
                controllerHandler.MovingRight = false;
                controllerHandler.MovingLeft = true;
            }
           

        }
    }
}