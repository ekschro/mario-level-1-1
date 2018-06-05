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
    public class HiddenBlockSprite : IBlockSprite
    {
        private Game1 myGame;
        private int currentFrame;
        private Vector2 blockLocation;

        public HiddenBlockSprite(Game1 game, Vector2 location)
        {
            myGame = game;
            currentFrame = 0;
            blockLocation = location;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)blockLocation.X, (int)blockLocation.Y, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.Transparent);
            myGame.spriteBatch.End();
        }
        public void QuestionToUsed()
        {

        }
        public void BrickToEmpty()
        {

        }
        public void HiddenToUsed()
        {
            myGame.Block6Sprite = new UsedBlockSprite(myGame, blockLocation);
        }
    }
}