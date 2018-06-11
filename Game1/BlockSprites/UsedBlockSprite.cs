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
    public class UsedBlockSprite : IBlockSprite
    {
        private Game1 myGame;
        private int currentFrame;
        private IBlock blockObject;

        public UsedBlockSprite(Game1 game, IBlock block)
        {
            myGame = game;
            currentFrame = 3;
            blockObject = block;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)blockObject.BlockLocation().X, (int)blockObject.BlockLocation().X, width, myGame.blockTexture.Height);


            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.White);
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

        }
    }
}