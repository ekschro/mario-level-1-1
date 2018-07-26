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
        private const int NumberOfButtons = 2,//4,
            EnterGame = 0,
            LevelSelect = 1/*,
            Level11 = 2,
            Level14 = 3*/;

        private Color[] buttonColor = new Color[NumberOfButtons];
        private Rectangle[] buttonRectangle = new Rectangle[NumberOfButtons];
        private KeyboardState keyBoardState, lastKeyBoardState;
        public TestButton(Game1 game)
        {
            myGame = game;
            buttonColor[0] = Color.White;
            buttonColor[1] = Color.Gray;
        }
        void TakeAction(int i)
        {
            switch (i)
            {
                case EnterGame:
                    myGame.LoadTransition();
                    break;
                case LevelSelect:
                    buttonColor[0] = Color.Transparent;
                    buttonColor[1] = Color.Transparent;
                    myGame.GameState = Game1.GameScreenState.LevelSelect;
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
                        buttonColor[LevelSelect] = Color.White;
                        buttonColor[EnterGame] = Color.Gray;
                        break;
                    case Keys.Up:
                        buttonColor[EnterGame] = Color.White;
                        buttonColor[LevelSelect] = Color.Gray;
                        break;
                    case Keys.Enter:
                        if (buttonColor[EnterGame] == Color.White)
                            TakeAction(EnterGame);
                        else //if (buttonColor[LevelSelect] == Color.White)
                            TakeAction(LevelSelect);
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
            Rectangle levelDestinationRectangle = new Rectangle(150, 170, TextureWarehouse.LevelSelectTexture.Width, TextureWarehouse.LevelSelectTexture.Height);
            Rectangle enterDestinationRectangle = new Rectangle(170, 150, TextureWarehouse.EnterTexture.Width, TextureWarehouse.EnterTexture.Height);
            

            myGame.SpriteBatch.Draw(TextureWarehouse.EnterTexture, enterDestinationRectangle, buttonColor[0]);
            myGame.SpriteBatch.Draw(TextureWarehouse.LevelSelectTexture, levelDestinationRectangle, buttonColor[1]);
           
            
        }
    }

}
