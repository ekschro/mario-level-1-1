using System;
namespace Game1
{
    public class MarioSmallIdleRight : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 14 + 28;

        public MarioSmallIdleRight(Game1 game)
        {
            myGame = game;
        }


        public void Draw()
        {
            int width = myGame.marioTexture.Width / myGame.totalMarioColumns;
            int height = myGame.marioTexture.Height / myGame.totalMarioRows;
            int row = (int)((float)currentFrame / (float)myGame.totalMarioColumns);
            int column = currentFrame % myGame.totalMarioColumns;

            myGame.currentLocation.Y = myGame.startingLocation.Y;
            myGame.currentLocation.X = myGame.startingLocation.X;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, height);

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
            myGame.marioSprite = new MarioSmallIdleLeft(myGame);
        }

        public void RightCommandCalled()
        {
            myGame.marioSprite = new MarioSmallWalkRight(myGame);
        }

        public void SmallMarioCommandCalled()
        {

        }

        public void BigMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigIdleRight(myGame);
        }

        public void FireMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireIdleRight(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioSmallDeadRight(myGame);
        }

        public void Update()
        {

        }
    }
}
