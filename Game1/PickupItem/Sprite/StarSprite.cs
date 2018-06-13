using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class StarSprite : IPickupSprite
    {
        private Star starObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;

        public StarSprite(Game1 game, Star star)
        {
            starObject = star;
            myGame = game;
            startFrame = 6;
            endFrame = 10;
            currentFrame = startFrame;
        }
        public void Update()
        {
            currentFrame++;
            if (currentFrame == endFrame)
                currentFrame = startFrame;
        }

        public void Draw()
        {
            int width = myGame.pickupTexture.Width / 14;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.pickupTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)starObject.GetCurrentLocation().X, (int)starObject.GetCurrentLocation().Y, width, myGame.pickupTexture.Height);

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
