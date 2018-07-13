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
        //private int pickupColumn = 15;
        private PickupUtilityClass utility;
        public StarSprite(Game1 game, Star star)
        {
            utility = new PickupUtilityClass();
            starObject = star;
            myGame = game;
            //startFrame = 6;
            //endFrame = 10;
            startFrame = utility.StarStartFrame;
            endFrame = utility.StarEndFrame;
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
            int width = TextureWarehouse.pickupTexture.Width / utility.PickupColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(starObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.pickupTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)starObject.GetGameObjectLocation().Y, width, TextureWarehouse.pickupTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.pickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}
