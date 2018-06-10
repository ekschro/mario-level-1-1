using Microsoft.Xna.Framework;
using System;

namespace Game1
{
    public class MarioSmallIdleLeft : ISprite
    {
        private Game1 myGame;
        private Mario marioObject;

        private int currentFrame = 41;

        public MarioSmallIdleLeft(Game1 game, Mario mario)
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
            Mario.marioSprite = new MarioSmallWalkLeft(myGame, marioObject);
        }

        public void RightCommandCalled()
        {
            Mario.marioSprite = new MarioSmallIdleRight(myGame, marioObject);
        }

        public void SmallMarioCommandCalled()
        {

        }

        public void BigMarioCommandCalled()
        {
            Mario.marioSprite = new MarioBigIdleLeft(myGame, marioObject);
        }

        public void FireMarioCommandCalled()
        {
            Mario.marioSprite = new MarioFireIdleLeft(myGame, marioObject);
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