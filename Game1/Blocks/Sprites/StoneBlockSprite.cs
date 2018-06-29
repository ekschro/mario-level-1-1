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
    public class StoneBlockSprite : IBlockSprite
    {
        private StoneBlock stoneBlockObject;
        private Game1 myGame;
        private int currentFrame;

        public StoneBlockSprite(Game1 game, IBlock stoneBlock)
        {
            stoneBlockObject = (StoneBlock)stoneBlock;
            myGame = game;
            currentFrame = 0;
        }

        public void Update(){}

        public void Draw()
        {
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(stoneBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(0,0,(int)stoneBlockObject.BlockSize.X,(int)stoneBlockObject.BlockSize.Y);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)stoneBlockObject.GetGameObjectLocation().Y, (int)stoneBlockObject.BlockSize.X, (int)stoneBlockObject.BlockSize.Y);

            myGame.SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);
            myGame.SpriteBatch.Draw(TextureWareHouse.stoneBlockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}