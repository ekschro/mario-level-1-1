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

    public class MouseController : IController
    {
        ICommand right;
        ICommand left;
        ICommand down;
        ICommand up;
        public MouseController(Game1 game)
        {
            right = new RightCommand(game);
            left = new LeftCommand(game);
            down = new DownCommand(game);
            up = new UpCommand(game);

        }

        public void Update()
        {
            var mouseState = Mouse.GetState();

           
        }
    }
}
