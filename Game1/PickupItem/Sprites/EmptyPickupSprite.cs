/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class EmptyPickupSprite : IPickupSprite
    {
        private EmptyPickup emptyObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;
        private int pickupColumn = 15;

        public EmptyPickupSprite(Game1 game, EmptyPickup empty)
        {
            emptyObject = empty;
            myGame = game;
            startFrame = 10;
            endFrame = 14;
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
            int width = TextureWarehouse.pickupTexture.Width / pickupColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(emptyObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.pickupTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)emptyObject.GetGameObjectLocation().Y, width, TextureWarehouse.pickupTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.pickupTexture, destinationRectangle, sourceRectangle, Color.Transparent);
            myGame.SpriteBatch.End();
        }

    }
}
*/