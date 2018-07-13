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
        private int pickupColumn = 15;

        public RedMushroomSprite(Game1 game, RedMushroom redMushroom)
        {
            redMushroomObject = redMushroom;
            myGame = game;
            currentFrame = 0;
        }
        public void Update()
        {}

        public void Draw()
        {
            int width = TextureWarehouse.pickupTexture.Width / pickupColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(redMushroomObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.pickupTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)redMushroomObject.GetGameObjectLocation().Y, width, TextureWarehouse.pickupTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.pickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }


    }
}
