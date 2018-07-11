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
    public class TopPipeBlockSprite : IBlockSprite
    {
        private TopPipeBlock topPipeBlockObject;
        private Game1 myGame;
        private int currentFrame;

        public TopPipeBlockSprite(Game1 game, IBlock topPipe)
        {
            topPipeBlockObject = (TopPipeBlock)topPipe;
            myGame = game;
            currentFrame = 8;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = (TextureWarehouse.blockTexture.Width * 2) / 13;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(topPipeBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)topPipeBlockObject.GetGameObjectLocation().Y, width, TextureWarehouse.blockTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}