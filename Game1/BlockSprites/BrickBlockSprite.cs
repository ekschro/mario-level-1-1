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
    public class BrickBlockSprite : IBlockSprite
    {
        private BrickBlock brickBlockObject;
        private Game1 myGame;
        private int currentFrame;
        //private Vector2 blockLocation;

        public BrickBlockSprite(Game1 game, BrickBlock brick)
        {
            brickBlockObject = brick;
            myGame = game;
            currentFrame = 2;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)brickBlockObject.GetBlockCurrentLocation().X, (int)brickBlockObject.GetBlockCurrentLocation().Y, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
        public void ToEmpty()
        {
            currentFrame = 13;
        }
        public void ToUsed()
        {

        }
    }
}