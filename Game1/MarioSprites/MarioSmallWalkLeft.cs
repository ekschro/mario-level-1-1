using Microsoft.Xna.Framework;
using System;

namespace Game1
{
    public class MarioSmallWalkLeft : ISprite
    {
        private Game1 myGame;
        private Boolean forward = true;
        private int currentFrame = 11 + 28;
        private int counter = 1;
        private int delay = 0;
        private Mario marioObject;

        public MarioSmallWalkLeft(Game1 game, Mario mario)
        {
            myGame = game;
            marioObject = mario;
        }


        public void Draw()
        {
            int width = myGame.marioTexture.Width / myGame.totalMarioColumns;
            int height = myGame.marioTexture.Height / myGame.totalMarioRows;
            int row = (int)((float)currentFrame / (float)myGame.totalMarioColumns);
            int column = currentFrame % myGame.totalMarioColumns;

            
            

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)marioObject.GetCurrentXPosition(), (int)marioObject.GetCurrentYPosition(), width, height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            marioObject.MarioSprite = new MarioSmallJumpingLeft(myGame, marioObject);
        }

        public void DownCommandCalled()
        {

        }

        public void LeftCommandCalled()
        {

        }

        public void RightCommandCalled()
        {
            marioObject.MarioSprite = new MarioSmallIdleLeft(myGame, marioObject);
        }

        public void SmallMarioCommandCalled()
        {

        }

        public void BigMarioCommandCalled()
        {
            marioObject.MarioSprite = new MarioBigWalkLeft(myGame, marioObject);
        }

        public void FireMarioCommandCalled()
        {
            marioObject.MarioSprite = new MarioFireWalkLeft(myGame, marioObject);
        }

        public void DeadMarioCommandCalled()
        {
            marioObject.MarioSprite = new MarioDead(myGame, marioObject);
        }

        public void Update()
        {
            if (delay < 3)
            {
                delay++;
            }
            else if (forward)
            {
                currentFrame--;
                counter++;
                if (counter == 3)
                {
                    counter = 1;
                    forward = false;
                }
                delay = 0;
            }
            else
            {
                currentFrame++;
                counter++;
                if (counter == 3)
                {
                    counter = 1;
                    forward = true;
                }
                delay = 0;
            }
        }
    }
}