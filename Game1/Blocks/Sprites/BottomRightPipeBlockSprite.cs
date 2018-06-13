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
        //private Vector2 blockLocation;

        public BottomRightPipeBlockSprite(Game1 game, BottomRightPipeBlock bottomRightPipe)
        {
            bottomRightPipeBlockObject = bottomRightPipe;
            myGame = game;
            currentFrame = 11;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = TextureWareHouse.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)bottomRightPipeBlockObject.GetBlockCurrentLocation().X, (int)bottomRightPipeBlockObject.GetBlockCurrentLocation().Y, width, TextureWareHouse.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(TextureWareHouse.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
        public void ToEmpty()
        {
        }
        public void ToUsed()
        {
        }
    }
}