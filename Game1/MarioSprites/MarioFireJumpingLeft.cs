using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioFireJumpingLeft : ISprite
    {
        private Game1 myGame;
        private Mario marioObject;

        private int currentFrame = 7 + 56;

        public MarioFireJumpingLeft(Game1 game, Mario mario)
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

        }

        public void DownCommandCalled()
        {
            marioObject.marioSprite = new MarioFireIdleLeft(myGame, marioObject);
        }

        public void LeftCommandCalled()
        {

        }

        public void RightCommandCalled()
        {

        }

        public void SmallMarioCommandCalled()
        {
            marioObject.marioSprite = new MarioSmallJumpingLeft(myGame, marioObject);
        }

        public void BigMarioCommandCalled()
        {
            marioObject.marioSprite = new MarioBigJumpingLeft(myGame, marioObject);
        }

        public void FireMarioCommandCalled()
        {

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