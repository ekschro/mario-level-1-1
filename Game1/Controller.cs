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

            if(!myGame.UpPressed)
                myGame.marioSprite.UpCommandCalled();

            myGame.UpPressed = true;

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
            if (!myGame.DownPressed)
                myGame.marioSprite.DownCommandCalled();

            myGame.DownPressed = true;
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
            if (!myGame.LeftPressed)
                myGame.marioSprite.LeftCommandCalled();

            myGame.LeftPressed = true;
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
            if (!myGame.RightPressed)
                myGame.marioSprite.RightCommandCalled();

            myGame.RightPressed = true;
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
            myGame.Block3Sprite.QuestionToUsed();
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
            myGame.Block4Sprite.BrickToEmpty();
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
            myGame.Block6Sprite.HiddenToUsed();
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
            myGame = new Game1();
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
            myGame.GoombaSprite.BeStomped();
        }
    }

    public class KoopaStompedCommand : ICommand
    {
        private Game1 myGame;

        public KoopaStompedCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.KoopaSprite.BeStomped();
        }
    }
}
    