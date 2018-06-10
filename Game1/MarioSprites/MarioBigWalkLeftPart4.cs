using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioBigWalkLeftPart4 : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 10;
       
        
        

        public MarioBigWalkLeftPart4(Game1 game)
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
            myGame.marioSprite = new MarioBigJumpingLeft(myGame);
        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioBigCrouchingLeft(myGame);
        }

        public void LeftCommandCalled()
        {
            myGame.marioSprite = new MarioBigWalkLeft(myGame);
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
           
        }
    }
}