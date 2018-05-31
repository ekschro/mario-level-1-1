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

        private Game1 myGame;

        public KeyboardController(Game1 game)
        {
            myGame = game;
            controllerMappings = new Dictionary<Keys, ICommand>();
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
            controllerMappings.Add(Keys.Z, new QuestionToUsedCommand(myGame));
            controllerMappings.Add(Keys.X, new BrickDisappearCommand(myGame));
            controllerMappings.Add(Keys.C, new HiddenToUsedCommand(myGame));
            controllerMappings.Add(Keys.R, new ResetCommand(myGame));
            controllerMappings.Add(Keys.K, new GoombaStompedCommand(myGame));
            controllerMappings.Add(Keys.L, new KoopaStompedCommand(myGame));

        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key))
                    controllerMappings[key].Execute();
            }

            if (!pressedKeys.Contains(Keys.W) && !pressedKeys.Contains(Keys.S))
            {
                myGame.UpPressed = false;
                myGame.DownPressed = false;
            }

            if (!pressedKeys.Contains(Keys.Up) && !pressedKeys.Contains(Keys.Down))
            {
                myGame.UpPressed = false;
                myGame.DownPressed = false;
            }

            if (!pressedKeys.Contains<Keys>(Keys.A) && !pressedKeys.Contains<Keys>(Keys.D))
            {
                myGame.LeftPressed = false;
                myGame.RightPressed = false;
            }

            if (!pressedKeys.Contains<Keys>(Keys.Left) && !pressedKeys.Contains<Keys>(Keys.Right))
            {
                myGame.LeftPressed = false;
                myGame.RightPressed = false;
            }
        }
    }
}
