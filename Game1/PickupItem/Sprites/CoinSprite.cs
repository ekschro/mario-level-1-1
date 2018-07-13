using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class CoinPickupSprite : IPickupSprite
    {
        private CoinPickup coinPickupObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;
        //private int pickupColumn = 15;
        private PickupUtilityClass utility;

        public CoinPickupSprite(Game1 game, CoinPickup coinPickup)
        {
            utility = new PickupUtilityClass();
            coinPickupObject = coinPickup;
            myGame = game;
            //startFrame = 10;
            //endFrame = 14;
            startFrame = utility.CoinStartFrame;
            endFrame = utility.CoinEndFramw;
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
            int width = TextureWarehouse.pickupTexture.Width / utility.PickupColumn ;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(coinPickupObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.pickupTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)coinPickupObject.GetGameObjectLocation().Y, width, TextureWarehouse.pickupTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.pickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }

    }
}
