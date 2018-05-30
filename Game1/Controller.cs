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
    public interface IController
    {
        void Update();

    }

    
    public interface ICommand
    {
        void Execute();
    }

    public class KeyboardController : IController
    {
        public int timer = 0;
        private Dictionary<Keys, ICommand> controllerMappings;
        public KeyboardController(Game1 game)
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            controllerMappings.Add(Keys.Q, new ExitGameCommand(game));
            controllerMappings.Add(Keys.W, new UpCommand(game));
            controllerMappings.Add(Keys.S, new DownCommand(game));
            controllerMappings.Add(Keys.A, new LeftCommand(game));
            controllerMappings.Add(Keys.D, new RightCommand(game));
            controllerMappings.Add(Keys.Up, new UpCommand(game));
            controllerMappings.Add(Keys.Down, new DownCommand(game));
            controllerMappings.Add(Keys.Left, new LeftCommand(game));
            controllerMappings.Add(Keys.Right, new RightCommand(game));
            controllerMappings.Add(Keys.Y, new SmallMarioCommand(game));
            controllerMappings.Add(Keys.U, new BigMarioCommand(game));
            controllerMappings.Add(Keys.I, new FireMarioCommand(game));
            controllerMappings.Add(Keys.O, new DeadMarioCommand(game));
            controllerMappings.Add(Keys.Z, new QuestionToUsedCommand(game));
            controllerMappings.Add(Keys.X, new BrickDisappearCommand(game));
            controllerMappings.Add(Keys.C, new HiddenToUsedCommand(game));
            controllerMappings.Add(Keys.R, new ResetCommand(game));

        }

        public void Update()
        {

            
                Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
                foreach (Keys key in pressedKeys)
                {
                    if (controllerMappings.ContainsKey(key))
                        controllerMappings[key].Execute();
                }
                
           
        }

    }

    public class ExitGameCommand : ICommand
    {
        private Game1 myGame;

        public ExitGameCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Exit();
        }
    }

    public class UpCommand : ICommand
    {
        private Game1 myGame;

        public UpCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite.UpCommandCalled();
        }
    }

    public class DownCommand : ICommand
    {
        private Game1 myGame;

        public DownCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite.DownCommandCalled();
        }
    }

    public class LeftCommand : ICommand
    {
        private Game1 myGame;

        public LeftCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite.LeftCommandCalled();
        }
    }

    public class RightCommand : ICommand
    {
        private Game1 myGame;

        public RightCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite.RightCommandCalled();
        }
    }

    public class SmallMarioCommand : ICommand
    {
        private Game1 myGame;

        public SmallMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite.SmallMarioCommandCalled();
        }
    }

    public class BigMarioCommand : ICommand
    {
        private Game1 myGame;

        public BigMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite.BigMarioCommandCalled();
        }
    }

    public class FireMarioCommand : ICommand
    {
        private Game1 myGame;

        public FireMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite.FireMarioCommandCalled();
        }
    }

    public class DeadMarioCommand : ICommand
    {
        private Game1 myGame;

        public DeadMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite.DeadMarioCommandCalled();
        }
    }

    public class QuestionToUsedCommand : ICommand
    {
        private Game1 myGame;

        public QuestionToUsedCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            
        }
    }

    public class BrickDisappearCommand : ICommand
    {
        private Game1 myGame;

        public BrickDisappearCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {

        }
    }

    public class HiddenToUsedCommand : ICommand
    {
        private Game1 myGame;

        public HiddenToUsedCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {

        }
    }

    public class ResetCommand : ICommand
    {
        private Game1 myGame;

        public ResetCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.
        }
    }

    public class GoombaStompedCommand : ICommand
    {
        private Game1 myGame;

        public GoombaStompedCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.;
        }
    }
}
    