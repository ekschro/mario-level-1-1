using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class GreenMushroomSprite : IPickupSprite
    {
        private GreenMushroom greenMushroomOject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;

        public GreenMushroomSprite(Game1 game, GreenMushroom greenMushroom)
        {
            greenMushroomOject = greenMushroom;
            myGame = game;
            startFrame = 1;
            endFrame = 2;
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
            Rectangle destinationRectangle = new Rectangle((int)greenMushroomOject.GetCurrentLocation().X, (int)greenMushroomOject.GetCurrentLocation().Y, width, myGame.pickupTexture.Height);

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
