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

    public class GamePadController : IController
    {
        private Dictionary<Buttons, ICommand> controllerMappings;
        private List<Buttons> recentKeys;
        private Game1 myGame;
        

        
        public GamePadController(Game1 game)
        {
            
            myGame = game;
            controllerMappings = new Dictionary<Buttons, ICommand>();
            recentKeys = new List<Buttons>();
            controllerMappings.Add(Buttons.Start, new ExitGameCommand(myGame));

            controllerMappings.Add(Buttons.LeftThumbstickUp, new UpCommand(myGame));
            controllerMappings.Add(Buttons.DPadUp, new UpCommand(myGame));

            controllerMappings.Add(Buttons.LeftThumbstickDown, new DownCommand(myGame));
            controllerMappings.Add(Buttons.DPadDown, new DownCommand(myGame));

            controllerMappings.Add(Buttons.LeftThumbstickLeft, new LeftCommand(myGame));
            controllerMappings.Add(Buttons.DPadLeft, new LeftCommand(myGame));

            controllerMappings.Add(Buttons.LeftThumbstickRight, new RightCommand(myGame));
            controllerMappings.Add(Buttons.DPadRight, new RightCommand(myGame));

            controllerMappings.Add(Buttons.Back, new ResetCommand(myGame));
            
    }

        public void Update()
        {
            Buttons[] pressedButtons = GetPressedButtons();

            foreach (Buttons button in pressedButtons)
            {
                for (int i = 0; i < 50; i++)
                {
                    if (i == 0 && controllerMappings.ContainsKey(button))
                    {
                        controllerMappings[button].Execute();
                    }
                }

            }
            
        }

        private Buttons[] GetPressedButtons()
        {
                Buttons[] PressedButtons = new Buttons[10];
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
                    PressedButtons[0] = Buttons.Start;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                PressedButtons[1] = Buttons.Back;

            if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
                PressedButtons[2] = Buttons.DPadUp;

            if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
                PressedButtons[4] = Buttons.DPadDown;


            if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
                PressedButtons[6] = Buttons.DPadLeft;

            
            if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
                PressedButtons[8] = Buttons.DPadRight;


            return PressedButtons;
        }
    }
}
