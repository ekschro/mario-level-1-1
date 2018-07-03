using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class NoCommand : ICommand
    {
        private IControllerHandler controllerHandler;

        public NoCommand(Game1 game)
        {
            controllerHandler = game.controllerHandler;
        }

        public void Execute()
        {
            controllerHandler.MovingDown = false;
            controllerHandler.MovingUp = false;
            controllerHandler.MovingRight = false;
            controllerHandler.MovingLeft = false;
        }
    }
}
