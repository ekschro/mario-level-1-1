﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class ButtonForLevelSelect
    {
        private Game1 myGame;
        private const int NumberOfButtons = 3,
            Level11 = 0,
            Level14 = 1,
            Enter = 2;

        private Color[] buttonColor = new Color[NumberOfButtons];
        private Rectangle[] buttonRectangle = new Rectangle[NumberOfButtons];
        private KeyboardState keyBoardState, lastKeyBoardState;
        private int i;
        public ButtonForLevelSelect(Game1 game)
        {
            myGame = game;
            buttonColor[0] = Color.Gray;
            buttonColor[1] = Color.White;
            buttonColor[2] = Color.White;
        }
        void TakeAction(int i)
        {
            switch (i)
            {
                case Level11:
                    myGame.LoadTransition();
                    break;
                case Level14:
                    break;
                default:
                    break;
            }
        }
        public void KeyboardControl()
        {
            lastKeyBoardState = keyBoardState;
            keyBoardState = Keyboard.GetState();
            Keys[] pressedKeys = keyBoardState.GetPressedKeys();
            foreach (Keys k in pressedKeys)
            {

                switch (k)
                {
                    case Keys.Right:
                        buttonColor[Level14] = Color.Gray;
                        buttonColor[Level11] = Color.White;
                        break;
                    case Keys.Left:
                        buttonColor[Level11] = Color.Gray;
                        buttonColor[Level14] = Color.White;
                        break;
                    case Keys.Down:
                        buttonColor[Enter] = Color.Gray;
                        break;
                    case Keys.Enter:
                        if (buttonColor[Level11] == Color.Gray && buttonColor[Enter]==Color.Gray)
                            TakeAction(Level11);
                        else if (buttonColor[Level14] == Color.Gray && buttonColor[Enter] == Color.Gray)
                            TakeAction(Level14);
                        break;
                    default:
                        break;
                }
            }
        }
        public void Update()
        {
            KeyboardControl();
        }
        public void Draw()
        {
            Rectangle level11Rectangle = new Rectangle(50, 50, TextureWarehouse.level11.Width / 3, TextureWarehouse.level11.Height / 3);
            Rectangle enterRectangle = new Rectangle(myGame.Window.ClientBounds.Width / 2-TextureWarehouse.enterTexture.Width/2, 150, TextureWarehouse.enterTexture.Width, TextureWarehouse.enterTexture.Height);

            myGame.SpriteBatch.Draw(TextureWarehouse.level11, level11Rectangle, buttonColor[0]);
            myGame.SpriteBatch.Draw(TextureWarehouse.enterTexture, enterRectangle, buttonColor[2]);

        }
    }

}
