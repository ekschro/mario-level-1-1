using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioSmallIdleRight : ISprite
    {
        private Game1 myGame;
        private Mario marioObject;

        private int currentFrame = 14 + 28;

        public MarioSmallIdleRight(Game1 game, Mario mario)
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
            marioObject.marioSprite = new MarioSmallJumpingRight(myGame, marioObject);
        }

        public void DownCommandCalled()
        {

        }

        public void LeftCommandCalled()
        {
            marioObject.marioSprite = new MarioSmallIdleLeft(myGame, marioObject);
        }

        public void RightCommandCalled()
        {
            marioObject.marioSprite = new MarioSmallWalkRight(myGame, marioObject);
        }

        public void SmallMarioCommandCalled()
        {

        }

        public void BigMarioCommandCalled()
        {
            marioObject.marioSprite = new MarioBigIdleRight(myGame, marioObject);
        }

        public void FireMarioCommandCalled()
        {
            marioObject.marioSprite = new MarioFireIdleRight(myGame, marioObject);
        }

        public void DeadMarioCommandCalled()
        {
            marioObject.marioSprite = new MarioDead(myGame, marioObject);
        }

        public void Update()
        {

        }
    }
}
