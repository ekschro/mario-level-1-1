using System;
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
        private const int NumberOfButtons = 5,
            Level11 = 0,
            Level14 = 1,
            LevelNormal = 2,
            LevelDark = 3,
            Enter = 4;

        private Color[] buttonColor = new Color[NumberOfButtons];
        
        private KeyboardState keyBoardState, lastKeyBoardState;
        private bool chooseLevel;
        private bool chooseMode;
        public ButtonForLevelSelect(Game1 game)
        {
            myGame = game;
            buttonColor[0] = Color.White;
            buttonColor[1] = Color.Gray;
            buttonColor[2] = Color.Gray;
            buttonColor[3] = Color.Gray;
            buttonColor[4] = Color.White;
            chooseLevel = true;
        }
        void TakeAction(int i)
        {
            switch (i)
            {
                case Level11:
                    myGame.LoadTransition();
                    break;
                case Level14:
                    myGame.NextLevel();
                    myGame.LoadTransition();
                    break;
                case LevelDark:
                    
                    myGame.DarkStage();
                    myGame.LoadTransition();
                    break;
                case LevelNormal:
                    myGame.LoadTransition();
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
                        if (chooseLevel==true)
                        {
                            buttonColor[Level11] = Color.Gray;
                            buttonColor[Level14] = Color.White;
                        }
                        else
                        {
                            buttonColor[LevelDark] = Color.White;
                            buttonColor[LevelNormal] = Color.Gray;
                        }
                        break;
                    case Keys.Left:
                        if (chooseLevel == true)
                        {
                            buttonColor[Level11] = Color.White;
                            buttonColor[Level14] = Color.Gray;
                        }
                        else
                        {
                            buttonColor[LevelNormal] = Color.White;
                            buttonColor[LevelDark] = Color.Gray;
                        }
                        break;
                    case Keys.Down:
                        if (chooseLevel && buttonColor[LevelDark] == Color.Gray && buttonColor[LevelDark] == Color.Gray)
                        {
                            buttonColor[LevelNormal] = Color.White;
                            chooseLevel = false;
                            chooseMode = true;
                        }
                        else if (chooseLevel)
                        {
                            chooseLevel = false;
                            chooseMode = true;
                        }

                        break;
                    case Keys.Up:
                        if (chooseLevel == false)
                        {
                            chooseLevel = true;
                        }
                        break;
                    case Keys.Enter:
                        if (buttonColor[Level11] == Color.White && buttonColor[LevelNormal] == Color.White)
                            TakeAction(Level11);
                        else if (buttonColor[Level11] == Color.White && buttonColor[LevelDark] == Color.White)
                            TakeAction(LevelDark);
                        else if (buttonColor[Level14] == Color.White && buttonColor[LevelNormal] == Color.White)
                            TakeAction(Level14);
                        else if (buttonColor[Level14] == Color.White && buttonColor[LevelDark] == Color.White)
                        {
                            TakeAction(Level14);
                            TakeAction(LevelDark);
                        }
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
            Rectangle level11Rectangle = new Rectangle(myGame.Window.ClientBounds.Width / 2-150, 50, TextureWarehouse.level11.Width / 3, TextureWarehouse.level11.Height / 3);
            Rectangle level14Rectangle = new Rectangle(myGame.Window.ClientBounds.Width / 2+50, 50, TextureWarehouse.level14.Width / 3, TextureWarehouse.level14.Height / 3);
            Rectangle enterRectangle = new Rectangle(myGame.Window.ClientBounds.Width / 2 - TextureWarehouse.enterTexture.Width / 2, 190, TextureWarehouse.enterTexture.Width, TextureWarehouse.enterTexture.Height);
            Rectangle lightRectangle = new Rectangle(myGame.Window.ClientBounds.Width / 2 -50- TextureWarehouse.normalMode.Width / 2, 150, TextureWarehouse.normalMode.Width, TextureWarehouse.normalMode.Height);
            Rectangle darkRectangle = new Rectangle(myGame.Window.ClientBounds.Width / 2 +50- TextureWarehouse.darkMode.Width / 2, 150, TextureWarehouse.darkMode.Width, TextureWarehouse.darkMode.Height);


            myGame.SpriteBatch.Draw(TextureWarehouse.level11, level11Rectangle, buttonColor[0]);
            myGame.SpriteBatch.Draw(TextureWarehouse.level14, level14Rectangle, buttonColor[1]);
            myGame.SpriteBatch.Draw(TextureWarehouse.normalMode, lightRectangle, buttonColor[2]);
            myGame.SpriteBatch.Draw(TextureWarehouse.darkMode, darkRectangle, buttonColor[3]);
            myGame.SpriteBatch.Draw(TextureWarehouse.enterTexture, enterRectangle, buttonColor[4]);

        }
    }

}
