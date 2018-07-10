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
    public class EmptyBlockSprite : IBlockSprite
    {
        private EmptyBlock emptyBlockObject;
        private Game1 myGame;
        private int currentFrame;

        public EmptyBlockSprite(Game1 game, IBlock emptyBlock)
        {
            emptyBlockObject = (EmptyBlock)emptyBlock;
            myGame = game;
            currentFrame = 12;
        }

        public void Update()
        {
        }

        public void Draw()
        {
            int width = TextureWarehouse.blockTexture.Width / 13;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(emptyBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)emptyBlockObject.GetGameObjectLocation().Y, width, TextureWarehouse.blockTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.blockTexture, destinationRectangle, sourceRectangle, Color.Transparent);
            myGame.SpriteBatch.End();
        }
    }

}