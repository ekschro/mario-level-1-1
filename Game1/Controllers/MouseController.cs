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
        
        private Game1 myGame;
        ICommand right;
        ICommand left;
        ICommand down;
        ICommand up;
        public MouseController(Game1 game)
        {

            myGame = game;
            right = new RightCommand(game);
            left = new LeftCommand(game);
            down = new DownCommand(game);
            up = new UpCommand(game);

        }

        public void Update()
        {
            var mouseState = Mouse.GetState();

            if(Mario.CurrentXPosition > mouseState.X)
            {
                right.Execute();
            } else if (Mario.CurrentXPosition < mouseState.X)
            {
                left.Execute();
            }
            if (Mario.CurrentYPosition > mouseState.Y)
            {
                up.Execute();
            } else if (Mario.CurrentYPosition < mouseState.Y)
            {
                down.Execute();
            }
            

        }
    }
}
