using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Game1
{
    public class BridgeBlockSprite : IBlockSprite
    {
        private BridgeBlock bridgeBlockObject;
        private Game1 myGame;
        
        private BlockUtilityClass utility;
        public BridgeBlockSprite(Game1 game, IBlock bridgeBlock)
        {
            utility = new BlockUtilityClass();
            bridgeBlockObject = (BridgeBlock)bridgeBlock;
            myGame = game;
            
        }

        public void Update(){}

        public void Draw()
        {
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(bridgeBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(utility.InitialFrame,utility.InitialFrame,(int)bridgeBlockObject.BlockSize.X,(int)bridgeBlockObject.BlockSize.Y);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)bridgeBlockObject.GetGameObjectLocation().Y, (int)bridgeBlockObject.BlockSize.X, (int)bridgeBlockObject.BlockSize.Y);

            myGame.SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);
            myGame.SpriteBatch.Draw(TextureWarehouse.bridgeBlockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}