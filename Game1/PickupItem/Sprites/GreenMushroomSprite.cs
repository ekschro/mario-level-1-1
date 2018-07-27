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
        private PickupUtilityClass utility;
        public GreenMushroomSprite(Game1 game, GreenMushroom greenMushroom)
        {
            greenMushroomOject = greenMushroom;
            myGame = game;
           
            utility = new PickupUtilityClass();
            currentFrame = utility.GreenMushroomFrame;
        }

        public void Update()
        {
        }

        public void Draw()
        {
            int width = TextureWarehouse.PickupTexture.Width / utility.PickupColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(greenMushroomOject.GameObjectLocation.X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.PickupTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)greenMushroomOject.GameObjectLocation.Y, width, TextureWarehouse.PickupTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.PickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}
