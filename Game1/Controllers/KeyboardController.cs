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

    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        //private List<Keys> recentKeys;
        private Game1 myGame;
        

        
        public KeyboardController(Game1 game)
        {
            
            myGame = game;
            controllerMappings = new Dictionary<Keys, ICommand>();
            //recentKeys = new List<Keys>();
            controllerMappings.Add(Keys.Q, new ExitGameCommand(myGame));
            controllerMappings.Add(Keys.W, new UpCommand());
            controllerMappings.Add(Keys.S, new DownCommand());
            controllerMappings.Add(Keys.A, new LeftCommand());
            controllerMappings.Add(Keys.D, new RightCommand());
            controllerMappings.Add(Keys.Up, new UpCommand());
            controllerMappings.Add(Keys.Down, new DownCommand());
            controllerMappings.Add(Keys.Left, new LeftCommand());
            controllerMappings.Add(Keys.Right, new RightCommand());
            controllerMappings.Add(Keys.Y, new SmallMarioCommand());
            controllerMappings.Add(Keys.U, new BigMarioCommand());
            controllerMappings.Add(Keys.I, new FireMarioCommand());
            controllerMappings.Add(Keys.O, new DeadMarioCommand(myGame));
            controllerMappings.Add(Keys.R, new ResetCommand(myGame));
            controllerMappings.Add(Keys.M, new MouseToggleCommand(myGame));
            
    }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                for (int i = 0; i < 50; i++)
                {
                    if (i == 0 && controllerMappings.ContainsKey(key))
                    {
                        controllerMappings[key].Execute();
                    }
                }

            }
            
        }
    }
}

