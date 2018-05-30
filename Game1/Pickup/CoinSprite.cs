using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class CoinSprite : IPickupSprite
    {
        private Game1 myGame;
        private int currentFrame;
        private int cyclePosition = 0;
        private int cycleLength = 32;
        private int startFrame;
        private int endFrame;

        public CoinSprite(Game1 game)
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
                cyclePosition = 0;
                currentFrame++;
                if (currentFrame == endFrame)
                    currentFrame = startFrame;
            }
        }

        public void Draw()
        {
            int width = myGame.PickupTexture.Width / myGame.totalPickupFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.PickupTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)150, (int)100, width, myGame.PickupTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.PickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }
}
