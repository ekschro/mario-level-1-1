using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class NoCommand : ICommand
    {
        public NoCommand()
        {

        }

        public void Execute()
        {
            Console.WriteLine("HElloooo");
            Mario.MovingDown = false;
            Mario.MovingUp = false;
            Mario.MovingRight = false;
            Mario.MovingLeft = false;
        }
    }
}
