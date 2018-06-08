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

        public MarioSmallWalkRight(Game1 game)
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
            myGame.marioSprite = new MarioSmallJumpingRight(myGame);
        }

        public void DownCommandCalled()
        {

        }

        public void LeftCommandCalled()
        {
            myGame.marioSprite = new MarioSmallIdleRight(myGame);
        }

        public void RightCommandCalled()
        {

        }

        public void SmallMarioCommandCalled()
        {

        }

        public void BigMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigWalkRight(myGame);
        }

        public void FireMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireWalkRight(myGame);
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