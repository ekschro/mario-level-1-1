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
    public class HiddenStarBlockSprite : IBlockSprite
    {
        private HiddenStarBlock hiddenStarBlockObject;
        private Game1 myGame;
        private int currentFrame;

        public HiddenStarBlockSprite(Game1 game, IBlock hiddenStarBlock)
        {
            hiddenStarBlockObject = (HiddenStarBlock)hiddenStarBlock;
            myGame = game;
            currentFrame = 0;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = TextureWareHouse.blockTexture.Width / 13;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(hiddenStarBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)hiddenStarBlockObject.GetGameObjectLocation().Y, width, TextureWareHouse.blockTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.blockTexture, destinationRectangle, sourceRectangle, Color.Transparent);
            myGame.SpriteBatch.End();
        }

    }
}