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

            //int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(marioObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * (14+28), 0, width, TextureWarehouse.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle(100,100, width, TextureWarehouse.marioTexture.Height);

            
            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.blackBackGroundTexture,new Vector2(0,0),Color.Black);
            //myGame.SpriteBatch.DrawString(myGame.SpriteFont, "Hello World", new Vector2(100, 100), Color.Black);
            myGame.SpriteBatch.Draw(TextureWarehouse.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.Draw(TextureWarehouse.backgroundTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}
