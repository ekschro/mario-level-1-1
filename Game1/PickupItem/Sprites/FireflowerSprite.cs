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
        
        private PickupUtilityClass utility;
        public FireflowerSprite(Game1 game, Fireflower fireflower)
        {
            utility = new PickupUtilityClass();
            fireflowerObject = fireflower;
            myGame = game;
           
            startFrame = utility.FireflowerStartFrame;
            endFrame = utility.FireflowerEndFrame;
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
            int width = TextureWarehouse.PickupTexture.Width / utility.PickupColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(fireflowerObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.PickupTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)fireflowerObject.GetGameObjectLocation().Y, width, TextureWarehouse.PickupTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.PickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }

    }
}
