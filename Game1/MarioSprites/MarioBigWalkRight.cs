using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioBigWalkRight : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 16;
        
        private bool forward = true;
        

        public MarioBigWalkRight(Game1 game)
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
            myGame.marioSprite = new MarioBigJumpingRight(myGame);
        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioBigCrouchingRight(myGame);
        }

        public void LeftCommandCalled()
        {
            myGame.marioSprite = new MarioBigIdleRight(myGame);
        }

        public void RightCommandCalled()
        {
            myGame.marioSprite = new MarioBigWalkRightPart2(myGame);
        }

        public void SmallMarioCommandCalled()
        {
            myGame.marioSprite = new MarioSmallWalkRight(myGame);
        }

        public void BigMarioCommandCalled()
        {

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

        }
    }

}