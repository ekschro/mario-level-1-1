using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioBigWalkLeft : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 11;
        private bool forward = true;
        private int counter = 1;
        private int delay = 0;

        public MarioBigWalkLeft(Game1 game)
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
            Rectangle destinationRectangle = new Rectangle((int)myGame.marioObject.GetCurrentXPosition(), (int)myGame.currentLocation.Y, width, height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioBigJumpingLeft(myGame);
        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioBigCrouchingLeft(myGame);
        }

        public void LeftCommandCalled()
        {

        }

        public void RightCommandCalled()
        {
            myGame.marioSprite = new MarioBigIdleLeft(myGame);
        }

        public void SmallMarioCommandCalled()
        {
            myGame.marioSprite = new MarioSmallWalkLeft(myGame);
        }

        public void BigMarioCommandCalled()
        {

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