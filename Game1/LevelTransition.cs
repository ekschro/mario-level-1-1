using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class LevelTransition
    {
        private Game1 myGame;
        public LevelTransition(Game1 game)
        {
            myGame = game;
            
        }
        public void Draw()
        {
            int width = TextureWarehouse.marioTexture.Width / 28;

            int height = TextureWarehouse.marioTexture.Height / 3;
            int row = (int)((float)(14+28) / (float)28);
            int column = (14+28) % 28;

           
            Rectangle sourceRectangle = new Rectangle(width * column, (height * row), width, height);
            Rectangle destinationRectangle = new Rectangle(160, 100, width, height);
            
            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.blackBackGroundTexture,new Vector2(0,0),Color.Black);
            myGame.SpriteBatch.DrawString(myGame.SpriteFont, "WORLD1-1", new Vector2(150, 80), Color.White);
            myGame.SpriteBatch.DrawString(myGame.SpriteFont, "X", new Vector2(180, 120), Color.White);
            myGame.SpriteBatch.DrawString(myGame.SpriteFont, "3", new Vector2(200, 120), Color.White);
            myGame.SpriteBatch.Draw(TextureWarehouse.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}
