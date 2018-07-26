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
       
        private PickupUtilityClass utility;

        public RedMushroomSprite(Game1 game, RedMushroom redMushroom)
        {
            utility = new PickupUtilityClass();
            redMushroomObject = redMushroom;
            myGame = game;
            
            currentFrame = utility.RedMushroomFrame;
        }
        public void Update()
        {}

        public void Draw()
        {
            int width = TextureWarehouse.PickupTexture.Width / utility.PickupColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(redMushroomObject.GameObjectLocation.X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.PickupTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)redMushroomObject.GameObjectLocation.Y, width, TextureWarehouse.PickupTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.PickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }


    }
}
