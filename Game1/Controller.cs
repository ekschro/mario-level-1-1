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
            controllerMappings.Add(Keys.W, new NonMovingNonAnimatedCommand(game));
            controllerMappings.Add(Keys.E, new NonMovingAnimatedCommand(game));
            controllerMappings.Add(Keys.R, new MovingNonAnimatedCommand(game));
            controllerMappings.Add(Keys.T, new MovingAnimatedCommand(game));
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

    public class NonMovingNonAnimatedCommand : ICommand
    {
        private Game1 myGame;

        public NonMovingNonAnimatedCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (!(myGame.luigiSprite is NonMovingNonAnimated))
                myGame.luigiSprite = new NonMovingNonAnimated(myGame);
        }
        
    }

    public class NonMovingAnimatedCommand : ICommand
    {
        private Game1 myGame;

        public NonMovingAnimatedCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (!(myGame.luigiSprite is NonMovingAnimated))
                myGame.luigiSprite = new NonMovingAnimated(myGame);
        }
        
    }

    public class MovingNonAnimatedCommand : ICommand
    {
        private Game1 myGame;

        public MovingNonAnimatedCommand(Game1 game)
        {
            myGame = game;
        }
        

        public void Execute()
        {
            if (!(myGame.luigiSprite is MovingNonAnimated))
                myGame.luigiSprite = new MovingNonAnimated(myGame);
        }
    }

    public class MovingAnimatedCommand : ICommand
    {
        private Game1 myGame;

        public MovingAnimatedCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (!(myGame.luigiSprite is MovingAnimated))
                myGame.luigiSprite = new MovingAnimated(myGame);
        }
    }
}
