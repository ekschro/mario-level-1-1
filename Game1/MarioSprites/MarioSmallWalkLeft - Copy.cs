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

        public MarioSmallWalkLeft(Game1 game)
        {
            myGame = game;
        }


        public void Draw()
        {
            int width = myGame.marioTexture.Width / myGame.totalMarioColumns;
            int height = myGame.marioTexture.Height / myGame.totalMarioRows;
            int row = (int)((float)currentFrame / (float)myGame.totalMarioColumns);
            int column = currentFrame % myGame.totalMarioColumns;

            
            

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.marioObject.GetCurrentXPosition(), (int)myGame.marioObject.GetCurrentYPosition(), width, height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioSmallJumpingLeft(myGame);
        }

        public void DownCommandCalled()
        {

        }

        public void LeftCommandCalled()
        {

        }

        public void RightCommandCalled()
        {
            myGame.marioSprite = new MarioSmallIdleLeft(myGame);
        }

        public void SmallMarioCommandCalled()
        {

        }

        public void BigMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigWalkLeft(myGame);
        }

        public void FireMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireWalkLeft(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioDead(myGame);
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