using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class RedMushroomSprite : IPickupSprite
    {
        private RedMushroom redMushroomObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;

        public RedMushroomSprite(Game1 game, RedMushroom redMushroom)
        {
            redMushroomObject = redMushroom;
            myGame = game;
            startFrame = 0;
            endFrame = 1;
            currentFrame = startFrame;
        }
        public void Update()
        {

        }

        public void Draw()
        {
            int width = TextureWareHouse.pickupTexture.Width / 15;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.pickupTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)redMushroomObject.GetCurrentLocation().X, (int)redMushroomObject.GetCurrentLocation().Y, width, TextureWareHouse.pickupTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(TextureWareHouse.pickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void picked()
        {
            startFrame = 14;
            endFrame = 15;
        }
    }
}
