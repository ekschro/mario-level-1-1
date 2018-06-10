using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioBigWalkRightPart2 : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 17;
        private Mario marioObject;
        
        

        public MarioBigWalkRightPart2(Game1 game, Mario mario)
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
            Rectangle destinationRectangle = new Rectangle((int)Mario.currentXPosition, (int)Mario.currentYPosition, width, height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            Mario.marioSprite = new MarioBigJumpingRight(myGame, marioObject);
        }

        public void DownCommandCalled()
        {
            Mario.marioSprite = new MarioBigCrouchingRight(myGame, marioObject);
        }

        public void LeftCommandCalled()
        {
            Mario.marioSprite = new MarioBigIdleRight(myGame, marioObject);
        }

        public void RightCommandCalled()
        {
            Mario.marioSprite = new MarioBigWalkRightPart3(myGame, marioObject);
        }

        public void SmallMarioCommandCalled()
        {
            Mario.marioSprite = new MarioSmallWalkRight(myGame, marioObject);
        }

        public void BigMarioCommandCalled()
        {

        }

        public void FireMarioCommandCalled()
        {
            Mario.marioSprite = new MarioFireWalkRight(myGame, marioObject);
        }

        public void DeadMarioCommandCalled()
        {
            Mario.marioSprite = new MarioDead(myGame, marioObject);
        }

        public void Update()
        {
           
        }
    }

}