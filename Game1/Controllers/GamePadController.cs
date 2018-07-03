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

    public class GamePadController : IController
    {
        private Dictionary<Buttons, ICommand> controllerMappings;
        //private List<Buttons> recentKeys;
        private Game1 myGame;

        private const float xSensitivity = 0.2f;

        private const float ySensitivity = 0.6f;

        public GamePadController(Game1 game)
        {
            myGame = game;

            controllerMappings = new Dictionary<Buttons, ICommand>();

            controllerMappings.Add(Buttons.Start, new ExitGameCommand(myGame));
            controllerMappings.Add(Buttons.Back, new ResetCommand(myGame));

            controllerMappings.Add(Buttons.LeftThumbstickDown, new DownCommand(myGame));
            controllerMappings.Add(Buttons.DPadDown, new DownCommand(myGame));

            controllerMappings.Add(Buttons.LeftThumbstickLeft, new LeftCommand(myGame));
            controllerMappings.Add(Buttons.DPadLeft, new LeftCommand(myGame));

            controllerMappings.Add(Buttons.LeftThumbstickRight, new RightCommand(myGame));
            controllerMappings.Add(Buttons.DPadRight, new RightCommand(myGame));
            
            controllerMappings.Add(Buttons.A, new UpCommand(myGame));
            controllerMappings.Add(Buttons.B, new FireballCommand(myGame));
            
    }

        public void Update()
        {
            Buttons[] pressedButtons = GetPressedButtons();

            foreach (Buttons button in pressedButtons)
            {
                if (controllerMappings.ContainsKey(button))
                { 
                    controllerMappings[button].Execute();
                }
            }
        }

        private Buttons[] GetPressedButtons()
        {
            Buttons[] PressedButtons = new Buttons[12];
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
                    PressedButtons[0] = Buttons.Start;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                PressedButtons[1] = Buttons.Back;

            if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
                PressedButtons[2] = Buttons.DPadUp;
            if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
                PressedButtons[3] = Buttons.DPadDown;
            if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
                PressedButtons[4] = Buttons.DPadLeft;
            if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
                PressedButtons[5] = Buttons.DPadRight;

            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
                PressedButtons[6] = Buttons.A;
            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
                PressedButtons[7] = Buttons.B;

            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > xSensitivity)
                PressedButtons[8] = Buttons.LeftThumbstickRight;
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < -xSensitivity)
                PressedButtons[9] = Buttons.LeftThumbstickLeft;
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > ySensitivity)
                PressedButtons[10] = Buttons.LeftThumbstickUp;
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < -ySensitivity)
                PressedButtons[11] = Buttons.LeftThumbstickDown;



            return PressedButtons;
        }
    }
}

