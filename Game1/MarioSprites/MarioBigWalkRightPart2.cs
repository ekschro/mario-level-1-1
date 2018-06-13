using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioBigWalkRightPart2 : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 17;
        
        
        

        public MarioBigWalkRightPart2(Game1 game)
        {
            myGame = game;
            
        }


        public void Draw()
        {
            int width = myGame.marioTexture.Width / Mario.TotalMarioColumns;
            int height = myGame.marioTexture.Height / Mario.TotalMarioRows;
            int row = (int)((float)currentFrame / (float)Mario.TotalMarioColumns);
            int column = currentFrame % Mario.TotalMarioColumns;

            
            

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Mario.CurrentXPosition, (int)Mario.CurrentYPosition, width, height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            Mario.marioSprite = new MarioBigJumpingRight(myGame);
        }

        public void DownCommandCalled()
        {
            Mario.marioSprite = new MarioBigCrouchingRight(myGame);
        }

        public void LeftCommandCalled()
        {
            Mario.marioSprite = new MarioBigIdleRight(myGame);
        }

        public void RightCommandCalled()
        {
            Mario.marioSprite = new MarioBigWalkRightPart3(myGame);
        }

        public void SmallMarioCommandCalled()
        {
            Mario.marioSprite = new MarioSmallWalkRight(myGame);
        }

        public void BigMarioCommandCalled()
        {

        }

        public void FireMarioCommandCalled()
        {
            Mario.marioSprite = new MarioFireWalkRight(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            Mario.marioSprite = new MarioDead(myGame);
        }

        public void Update()
        {
           
        }
        public bool isSmall()
        {
            return false;
        }

        public bool isFire()
        {
            return false;
        }
    }

}