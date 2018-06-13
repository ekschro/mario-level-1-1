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
        private Fireflower fireflowerObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;

        public FireflowerSprite(Game1 game, Fireflower fireflower)
        {
            fireflowerObject = fireflower;
            myGame = game;
            startFrame = 2;
            endFrame = 6;
            currentFrame = startFrame;
        }
        public void ChangeFrame(int start, int end)
        {
            startFrame = start;
            endFrame = end;
        }
        public void Update()
        {
            currentFrame++;
            if (currentFrame == endFrame)
                currentFrame = startFrame;
        }

        public void Draw()
        {
            int width = myGame.pickupTexture.Width / 15;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.pickupTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)fireflowerObject.GetCurrentLocation().X, (int)fireflowerObject.GetCurrentLocation().Y, width, myGame.pickupTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.pickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
        public void picked()
        {
            startFrame = 14;
            endFrame = 15;
        }
    }
}
