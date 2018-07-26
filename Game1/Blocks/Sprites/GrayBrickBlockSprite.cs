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
    public class GrayBrickBlockSprite : IBlockSprite
    {
        private GrayBrickBlock grayBrickBlockObject;
        private Game1 myGame;
        
        private BlockUtilityClass utility;
        public GrayBrickBlockSprite(Game1 game, IBlock grayBrickBlock)
        {
            utility = new BlockUtilityClass();
            grayBrickBlockObject = (GrayBrickBlock)grayBrickBlock;
            myGame = game;
            
        }

        public void Update(){}

        public void Draw()
        {
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(grayBrickBlockObject.GameObjectLocation.X);

            Rectangle sourceRectangle = new Rectangle(utility.InitialFrame,utility.InitialFrame,(int)grayBrickBlockObject.BlockSize.X,(int)grayBrickBlockObject.BlockSize.Y);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)grayBrickBlockObject.GameObjectLocation.Y, (int)grayBrickBlockObject.BlockSize.X, (int)grayBrickBlockObject.BlockSize.Y);

            myGame.SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);
            myGame.SpriteBatch.Draw(TextureWarehouse.GrayBrickBlockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}