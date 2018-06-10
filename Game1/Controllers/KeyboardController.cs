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

    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private List<Keys> recentKeys;
        private Game1 myGame;
        private int timer;
        
        public KeyboardController(Game1 game)
        {
            timer = 0;
            myGame = game;
            controllerMappings = new Dictionary<Keys, ICommand>();
            recentKeys = new List<Keys>();
            controllerMappings.Add(Keys.Q, new ExitGameCommand(myGame));
            controllerMappings.Add(Keys.W, new UpCommand(myGame));
            controllerMappings.Add(Keys.S, new DownCommand(myGame));
            controllerMappings.Add(Keys.A, new LeftCommand(myGame));
            controllerMappings.Add(Keys.D, new RightCommand(myGame));
            controllerMappings.Add(Keys.Up, new UpCommand(myGame));
            controllerMappings.Add(Keys.Down, new DownCommand(myGame));
            controllerMappings.Add(Keys.Left, new LeftCommand(myGame));
            controllerMappings.Add(Keys.Right, new RightCommand(myGame));
            controllerMappings.Add(Keys.Y, new SmallMarioCommand(myGame));
            controllerMappings.Add(Keys.U, new BigMarioCommand(myGame));
            controllerMappings.Add(Keys.I, new FireMarioCommand(myGame));
            controllerMappings.Add(Keys.O, new DeadMarioCommand(myGame));
            controllerMappings.Add(Keys.R, new ResetCommand(myGame));
            
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

