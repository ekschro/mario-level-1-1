using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioFireWalkRightPart2 : ISprite
    {
        private Game1 myGame;
        private Mario marioObject;
        private int currentFrame = 17 + 56;
        
        
        

        public MarioFireWalkRightPart2(Game1 game, Mario mario)
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
            marioObject.marioSprite = new MarioFireJumpingRight(myGame, marioObject);
        }

        public void DownCommandCalled()
        {
            marioObject.marioSprite = new MarioFireCrouchingRight(myGame, marioObject);
        }

        public void LeftCommandCalled()
        {
            marioObject.marioSprite = new MarioFireIdleRight(myGame, marioObject);
        }

        public void RightCommandCalled()
        {
            marioObject.marioSprite = new MarioFireWalkRightPart3(myGame, marioObject);
        }

        public void SmallMarioCommandCalled()
        {
            marioObject.marioSprite = new MarioSmallWalkRight(myGame, marioObject);
        }

        public void BigMarioCommandCalled()
        {
            marioObject.marioSprite = new MarioBigWalkRight(myGame, marioObject);
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