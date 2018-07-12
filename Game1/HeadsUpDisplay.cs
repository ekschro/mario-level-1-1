using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class HeadsUpDisplay
    {
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;
        private int cyclePosition = 0;
        private int cycleLength = 16;


        public HeadsUpDisplay(Game1 game)
        {
            myGame = game;
            startFrame = 10;
            endFrame = 14;
            currentFrame = startFrame;
        }
        public void Update()
        {
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                currentFrame++;
                if (currentFrame == endFrame)
                    currentFrame = startFrame;
                cyclePosition = 0;
            }
            
        }

        public void Draw()
        {
            int width = TextureWarehouse.pickupTexture.Width / 15;
            
            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.pickupTexture.Height);
            Rectangle destinationRectangle = new Rectangle(90, 25, width, TextureWarehouse.pickupTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.DrawString(myGame.SpriteFont, "MARIO", new Vector2(10, 10), Color.White);
            myGame.SpriteBatch.DrawString(myGame.SpriteFont, "WORLD", new Vector2(200, 10), Color.White);
            myGame.SpriteBatch.DrawString(myGame.SpriteFont, "TIME", new Vector2(300, 10), Color.White);
            myGame.SpriteBatch.DrawString(myGame.SpriteFont, myGame.persistentData.Points.ToString(), new Vector2(10, 25), Color.White); //need to update
            myGame.SpriteBatch.Draw(TextureWarehouse.pickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.DrawString(myGame.SpriteFont, "X", new Vector2(105, 25), Color.White);
            myGame.SpriteBatch.DrawString(myGame.SpriteFont, myGame.persistentData.Coins.ToString(), new Vector2(115, 25), Color.White); //need to update
            myGame.SpriteBatch.DrawString(myGame.SpriteFont, "1-1", new Vector2(205, 25), Color.White); //need to update
            PlatformerLevel level = (PlatformerLevel)myGame.CurrentLevel;
            myGame.SpriteBatch.DrawString(myGame.SpriteFont,level.Time.ToString(), new Vector2(300, 25), Color.White); //need to update
            myGame.SpriteBatch.End();
        }
    }
}
