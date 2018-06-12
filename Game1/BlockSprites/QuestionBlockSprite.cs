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
    public class QuestionBlockSprite : IBlockSprite
    {
        private QuestionBlock questionBlockObject;
        private Game1 myGame;
        private int currentFrame;
        private int cyclePosition = 0;
        private int cycleLength = 32;
        private int startFrame;
        private int endFrame;
        //private Vector2 blockLocation;

        public QuestionBlockSprite(Game1 game, QuestionBlock questionBlock)
        {
            questionBlockObject = questionBlock;
            myGame = game;
            startFrame = 4;
            endFrame = 6;
            currentFrame = startFrame;
            //blockLocation = location;
        }

        public void Update()
        {
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                cyclePosition = 0;
                currentFrame++;
                if (currentFrame == endFrame)
                    currentFrame = startFrame;
            }
        }

        public void Draw()
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)questionBlockObject.GetBlockCurrentLocation().X, (int)questionBlockObject.GetBlockCurrentLocation().Y, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
        public void ToUsed()
        {
            startFrame = 3;
            endFrame = 4;
            //myGame.blockQuestionSprite = new UsedBlockSprite(myGame, blockLocation);
        }
        public void ToEmpty()
        {

        }
    }
}