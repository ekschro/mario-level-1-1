using Microsoft.Xna.Framework;

namespace Game1
{
    public class MarioSmallWalkRight : ISprite
    {
        private Game1 myGame;
        
        private int currentFrame = 16 + 28;

        

        public MarioSmallWalkRight(Game1 game)
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
            Mario.marioSprite = new MarioSmallJumpingRight(myGame);
        }

        public void DownCommandCalled()
        {

        }

        public void LeftCommandCalled()
        {
            Mario.marioSprite = new MarioSmallIdleRight(myGame);
        }

        public void RightCommandCalled()
        {
            Mario.marioSprite = new MarioSmallWalkRightPart2(myGame);
        }

        public void SmallMarioCommandCalled()
        {

        }

        public void BigMarioCommandCalled()
        {
            Mario.marioSprite = new MarioBigWalkRight(myGame);
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
    }
}