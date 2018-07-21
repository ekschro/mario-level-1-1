using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class TestButton
    {
        private Game1 myGame;
        private const int NumberOfButtons = 2,
            EnterGame = 0,
            LevelSelect = 1;
        private Color[] buttonColor = new Color[NumberOfButtons];
        private Rectangle[] buttonRectangle = new Rectangle[NumberOfButtons];
        private KeyboardState keyBoardState, lastKeyBoardState;
        public TestButton(Game1 game)
        {
            myGame = game;
            buttonColor[0] = Color.Gray;
            buttonColor[1] = Color.White;
        }
        void TakeAction(int i)
        {
            switch (i)
            {
                case EnterGame:
                    myGame.GameState = Game1.GameScreenState.Transition;
                    break;
                case LevelSelect:
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
                    case Keys.Down:
                        buttonColor[LevelSelect] = Color.Gray;
                        buttonColor[EnterGame] = Color.White;
                        break;
                    case Keys.Up:
                        buttonColor[EnterGame] = Color.Gray;
                        buttonColor[LevelSelect] = Color.White;
                        break;
                    case Keys.Enter:
                        if (buttonColor[EnterGame] == Color.Gray)
                            TakeAction(EnterGame);
                        else
                            TakeAction(LevelSelect);
                        break;
                    default:
                        buttonColor[EnterGame] = Color.Gray;
                        buttonColor[LevelSelect] = Color.White;
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
            Rectangle levelDestinationRectangle = new Rectangle(150, 170, TextureWarehouse.levelSelectTexture.Width, TextureWarehouse.levelSelectTexture.Height);
            Rectangle enterDestinationRectangle = new Rectangle(170, 150, TextureWarehouse.enterTexture.Width, TextureWarehouse.enterTexture.Height);

            myGame.SpriteBatch.Draw(TextureWarehouse.enterTexture, enterDestinationRectangle, buttonColor[0]);
            myGame.SpriteBatch.Draw(TextureWarehouse.levelSelectTexture, levelDestinationRectangle, buttonColor[1]);
            
        }
    }

}
