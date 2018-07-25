using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class AxePickupSprite : IPickupSprite
    {
        private AxePickup axePickupObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;
        private PickupUtilityClass utility;

        public AxePickupSprite(Game1 game, AxePickup axePickup)
        {
            utility = new PickupUtilityClass();
            axePickupObject = axePickup;
            myGame = game;
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
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(axePickupObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(0, 0, utility.BlockSize, utility.BlockSize);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)axePickupObject.GetGameObjectLocation().Y, utility.BlockSize, utility.BlockSize);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.axeTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }

    }
}
