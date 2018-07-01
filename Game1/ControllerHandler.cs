using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class ControllerHandler : IControllerHandler
    {
        private bool movingDown;
        private bool movingUp;
        private bool movingRight;
        private bool movingLeft;

        public bool MovingDown { get => movingDown; set => movingDown = value; }
        public bool MovingUp { get => movingUp; set => movingUp = value; }
        public bool MovingRight { get => movingRight; set => movingRight = value; }
        public bool MovingLeft { get => movingLeft; set => movingLeft = value; }

        public ControllerHandler()
        {
        }
    }
}
