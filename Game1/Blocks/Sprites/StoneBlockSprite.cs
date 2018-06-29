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
            int width = TextureWareHouse.blockTexture.Width / 13;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(stoneBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)stoneBlockObject.GetGameObjectLocation().Y, (int)stoneBlockObject.BlockSize.X, (int)stoneBlockObject.BlockSize.Y);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}