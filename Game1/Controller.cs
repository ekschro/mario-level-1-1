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

    //The ICommand Interace pattern is much more readable
    public interface ICommand
    {
        void Execute();
    }

    public class KeyboardController : IController
    {
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

    /*

    public class GamePadController : IController
    {
        private Dictionary<Buttons, ICommand> controllerMappings;
        public GamePadController(Game1 game)
        {
            controllerMappings = new Dictionary<Buttons, ICommand>();

            controllerMappings.Add(Buttons.Start, new ExitGameCommand(game));
            controllerMappings.Add(Buttons.A, new NonMovingNonAnimatedCommand(game));
            controllerMappings.Add(Buttons.B, new NonMovingAnimatedCommand(game));
            controllerMappings.Add(Buttons.X, new MovingNonAnimatedCommand(game));
            controllerMappings.Add(Buttons.Y, new MovingAnimatedCommand(game));

        }

        public void Update()
        {
            Buttons[] pressedButtons = GetControllerButtons();
            foreach (Buttons button in pressedButtons)
            {
                if(controllerMappings.ContainsKey(button))
                    controllerMappings[button].Execute();
            }
        }

        private Buttons[] GetControllerButtons()
        {
            Buttons[] PressedButtons = new Buttons[5];

            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
                PressedButtons[0] = Buttons.A;
            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
                PressedButtons[1] = Buttons.B;
            if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed)
                PressedButtons[2] = Buttons.X;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed)
                PressedButtons[3] = Buttons.Y;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
                PressedButtons[4] = Buttons.Start;
            return PressedButtons;
        }
    }

    */

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

        }
    }
}
    