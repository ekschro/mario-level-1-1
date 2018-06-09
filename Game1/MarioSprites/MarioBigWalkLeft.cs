using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioBigWalkLeft : ISprite
    {
        private Game1 myGame;
        private Mario marioObject;

        private int currentFrame = 11;
        private bool forward = true;
        private int counter = 1;
        private int delay = 0;

        public MarioBigWalkLeft(Game1 game, Mario mario)
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
            marioObject.MarioSprite = new MarioBigJumpingLeft(myGame, marioObject);
        }

        public void DownCommandCalled()
        {
            marioObject.MarioSprite = new MarioBigCrouchingLeft(myGame, marioObject);
        }

        public void LeftCommandCalled()
        {

        }

        public void RightCommandCalled()
        {
            marioObject.MarioSprite = new MarioBigIdleLeft(myGame, marioObject);
        }

        public void SmallMarioCommandCalled()
        {
            marioObject.MarioSprite = new MarioSmallWalkLeft(myGame, marioObject);
        }

        public void BigMarioCommandCalled()
        {

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
            if (delay < 3) {
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

            //if (currentFrame < 9 || currentFrame > 11) {
            //    forward = !forward;
            //}
            //else if (delay != 3) {
            //    delay++;
            //}
            //else if (forward) {
            //    currentFrame--;
            //    delay = 0;
            //}
            //else {
            //    currentFrame++;
            //    delay = 0;
            //}
        }
    }
}