using Microsoft.Xna.Framework;

namespace Game1
{
    public class MarioSmallWalkRight : ISprite
    {
        private Game1 myGame;
        private int counter = 1;
        private int currentFrame = 16 + 28;
        private bool forward = true;
        private int delay = 0;
        private Mario marioObject;

        public MarioSmallWalkRight(Game1 game, Mario mario)
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
            marioObject.MarioSprite = new MarioSmallJumpingRight(myGame, marioObject);
        }

        public void DownCommandCalled()
        {

        }

        public void LeftCommandCalled()
        {
            marioObject.MarioSprite = new MarioSmallIdleRight(myGame, marioObject);
        }

        public void RightCommandCalled()
        {

        }

        public void SmallMarioCommandCalled()
        {

        }

        public void BigMarioCommandCalled()
        {
            marioObject.MarioSprite = new MarioBigWalkRight(myGame, marioObject);
        }

        public void FireMarioCommandCalled()
        {
            marioObject.MarioSprite = new MarioFireWalkRight(myGame, marioObject);
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
                currentFrame++;
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
                currentFrame--;
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