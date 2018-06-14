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
    public class MouseToggleCommand : ICommand
    {
        private Game1 myGame;
        private IList<IController> temporaryControllerList;

        public MouseToggleCommand(Game1 game)
        {
            myGame = game;
            temporaryControllerList = new List<IController>();
        }

        public void Execute()
        {

            if (myGame.controllerList.Contains(myGame.mouseController))
            {
                myGame.controllerList.Remove(myGame.mouseController);
            } else
            {
                myGame.controllerList.Add(myGame.mouseController);
            }
        }
    }
}