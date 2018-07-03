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
        private ICommand none;
        
        public KeyboardController(Game1 game)
        {
            none = new NoCommand(game);
            controllerMappings = new Dictionary<Keys, ICommand>();
            //recentKeys = new List<Keys>();

            controllerMappings.Add(Keys.Q, new ExitGameCommand(game));
            controllerMappings.Add(Keys.Z, new UpCommand(game));
            controllerMappings.Add(Keys.S, new DownCommand(game));
            controllerMappings.Add(Keys.A, new LeftCommand(game));
            controllerMappings.Add(Keys.D, new RightCommand(game));
            controllerMappings.Add(Keys.Up, new UpCommand(game));
            controllerMappings.Add(Keys.Down, new DownCommand(game));
            controllerMappings.Add(Keys.Left, new LeftCommand(game));
            controllerMappings.Add(Keys.Right, new RightCommand(game));
            //controllerMappings.Add(Keys.Y, new SmallMarioCommand(game));
            //controllerMappings.Add(Keys.U, new BigMarioCommand(game));
            //controllerMappings.Add(Keys.I, new FireMarioCommand(game));
            //controllerMappings.Add(Keys.O, new DeadMarioCommand(game));
            controllerMappings.Add(Keys.R, new ResetCommand(game));
            controllerMappings.Add(Keys.M, new MouseToggleCommand(game));
            controllerMappings.Add(Keys.X, new FireballCommand(game));
    }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            none.Execute();

            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key))
                {
                    controllerMappings[key].Execute();
                    //recentKeys.Add(key);
                }
                //else if (recentKeys.Contains(key))
                //    recentKeys.Remove(key);
            }
        }
    }
}

