using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class FireflowerSprite : IPickupSprite
    {
        private Game1 myGame;
        private int currentFrame;
        private int cyclePosition = 0;
        private int cycleLength = 32;
        private int startFrame;
        private int endFrame;
        private Vector2 fireflowerLocation;

        public FireflowerSprite(Game1 game, Vector2 location)
        {
            myGame = game;
            startFrame = 2;
            endFrame = 6;
            currentFrame = startFrame;
            fireflowerLocation = location;
        }
        public void picked()
        {
            marioObject.marioSprite.FireMarioCommandCalled();
            //disapper code
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
            int width = myGame.pickupTexture.Width / myGame.totalPickupFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.pickupTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)fireflowerLocation.X, (int)fireflowerLocation.Y, width, myGame.pickupTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.pickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }
}
