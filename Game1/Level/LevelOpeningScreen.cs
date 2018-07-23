using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class LevelOpeningScreen
    {
        private Game1 myGame;
        //private Texture2D buttonTexture;
        private TestButton button;
        //private enum ButtonState { None, Hoverd, Clicked}

        public LevelOpeningScreen(Game1 game)
        {
            myGame = game;
            button = new TestButton(game);
        }
        public void Update()
        {
            button.Update();
        }
        public void Draw()
        {
            
            Rectangle sourceRectangle = new Rectangle(TextureWarehouse.openTexture.Width * 0, 0, TextureWarehouse.openTexture.Width, TextureWarehouse.openTexture.Height);
            Rectangle destinationRectangle = new Rectangle(100, 50, TextureWarehouse.openTexture.Width, TextureWarehouse.openTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.level11, new Vector2(0, 0), Color.White);
            myGame.SpriteBatch.Draw(TextureWarehouse.openTexture, destinationRectangle, sourceRectangle, Color.White);
            //myGame.SpriteBatch.Draw(TextureWarehouse.enterTexture, enterDestinationRectangle, enterSourceRectangle, Color.White);
            //myGame.SpriteBatch.Draw(TextureWarehouse.levelSelectTexture, levelDestinationRectangle, levelSourceRectangle, Color.White);
            button.Draw();
            //myGame.SpriteBatch.DrawString(myGame.SpriteFont, "Enter Game", new Vector2(180, 150), Color.White);
            //myGame.SpriteBatch.DrawString(myGame.SpriteFont, "Level Select", new Vector2(180, 170), Color.White);

            myGame.SpriteBatch.End();
        }
    }
}
