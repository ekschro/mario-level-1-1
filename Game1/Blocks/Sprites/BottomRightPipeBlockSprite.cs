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
    public class BottomRightPipeBlockSprite : IBlockSprite
    {
        private BottomRightPipeBlock bottomRightPipeBlockObject;
        private Game1 myGame;
        private int currentFrame;

        public BottomRightPipeBlockSprite(Game1 game, IBlock bottomRightPipe)
        {
            bottomRightPipeBlockObject = (BottomRightPipeBlock)bottomRightPipe;
            myGame = game;
            currentFrame = 11;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = TextureWareHouse.blockTexture.Width / 13;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)bottomRightPipeBlockObject.GameObjectLocation().X, (int)bottomRightPipeBlockObject.GameObjectLocation().Y, width, TextureWareHouse.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(TextureWareHouse.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }
}