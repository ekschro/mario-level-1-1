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
        public LevelOpeningScreen(Game1 game)
        {
            myGame = game;

        }
        public void Draw()
        {
            int width = TextureWarehouse.openTexture.Width;
            int height = TextureWarehouse.openTexture.Height;

            Rectangle sourceRectangle = new Rectangle(width * 0, 0, width, TextureWarehouse.openTexture.Height);
            Rectangle destinationRectangle = new Rectangle(100, 50, width, TextureWarehouse.openTexture.Height);


            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.openTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();

            

        }
    }
}
