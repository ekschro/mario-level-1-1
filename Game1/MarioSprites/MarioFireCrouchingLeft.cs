using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioFireCrouchingLeft : ISprite
    {
        private Game1 myGame;
        private Mario marioObject;

        private int currentFrame = 12 + 56;

        public MarioFireCrouchingLeft(Game1 game, Mario mario)
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
            Mario.marioSprite = new MarioFireIdleLeft(myGame, marioObject);
        }

        public void DownCommandCalled()
        {

        }

        public void LeftCommandCalled()
        {

        }

        public void RightCommandCalled()
        {

        }

        public void SmallMarioCommandCalled()
        {
            Mario.marioSprite = new MarioSmallIdleLeft(myGame, marioObject);
        }

        public void BigMarioCommandCalled()
        {
            Mario.marioSprite = new MarioBigCrouchingLeft(myGame, marioObject);
        }

        public void FireMarioCommandCalled()
        {
            
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