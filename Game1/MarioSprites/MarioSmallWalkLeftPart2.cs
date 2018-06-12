using Microsoft.Xna.Framework;
using System;

namespace Game1
{
    public class MarioSmallWalkLeftPart2 : ISprite
    {
        private Game1 myGame;
        
        private int currentFrame = 10 + 28;
        
        

        public MarioSmallWalkLeftPart2(Game1 game)
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
            Rectangle destinationRectangle = new Rectangle((int)Mario.CurrentXPosition, (int)Mario.CurrentYPosition, width, height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            Mario.marioSprite = new MarioSmallJumpingLeft(myGame);
        }

        public void DownCommandCalled()
        {

        }

        public void LeftCommandCalled()
        {
            Mario.marioSprite = new MarioSmallWalkLeftPart3(myGame);
        }

        public void RightCommandCalled()
        {
            Mario.marioSprite = new MarioSmallIdleLeft(myGame);
        }

        public void SmallMarioCommandCalled()
        {

        }

        public void BigMarioCommandCalled()
        {
            Mario.marioSprite = new MarioBigWalkLeft(myGame);
        }

        public void FireMarioCommandCalled()
        {
            Mario.marioSprite = new MarioFireWalkLeft(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            Mario.marioSprite = new MarioDead(myGame);
        }

        public void Update()
        {
          
        }
    }
}