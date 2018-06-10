using Microsoft.Xna.Framework;
using System;

namespace Game1
{
    public class MarioSmallWalkLeftPart3 : ISprite
    {
        private Game1 myGame;
        private Mario marioObject;
        private int currentFrame = 9 + 28;
        
        

        public MarioSmallWalkLeftPart3(Game1 game, Mario mario)
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
            Mario.marioSprite = new MarioSmallJumpingLeft(myGame, marioObject);
        }

        public void DownCommandCalled()
        {

        }

        public void LeftCommandCalled()
        {
            Mario.marioSprite = new MarioSmallWalkLeftPart4(myGame, marioObject);
        }

        public void RightCommandCalled()
        {
            Mario.marioSprite = new MarioSmallIdleLeft(myGame, marioObject);
        }

        public void SmallMarioCommandCalled()
        {

        }

        public void BigMarioCommandCalled()
        {
            Mario.marioSprite = new MarioBigWalkLeft(myGame, marioObject);
        }

        public void FireMarioCommandCalled()
        {
            Mario.marioSprite = new MarioFireWalkLeft(myGame, marioObject);
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