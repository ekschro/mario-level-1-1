using Microsoft.Xna.Framework;
using System;

namespace Game1
{
    public class MarioSmallWalkLeftPart3 : ISprite
    {
        private Game1 myGame;
        
        private int currentFrame = 9 + 28;

        private int smallSizeOffset = 16;



        public MarioSmallWalkLeftPart3(Game1 game)
        {
            myGame = game;
            
        }


        public void Draw()
        {
            int width = TextureWareHouse.marioTexture.Width / Mario.TotalMarioColumns;
            int height = TextureWareHouse.marioTexture.Height / Mario.TotalMarioRows;
            int row = (int)((float)currentFrame / (float)Mario.TotalMarioColumns);
            int column = currentFrame % Mario.TotalMarioColumns;


            Rectangle sourceRectangle = new Rectangle(width * column, (height * row) + smallSizeOffset, width, height - smallSizeOffset);
            Rectangle destinationRectangle = new Rectangle((int)Mario.CurrentXPosition, (int)Mario.CurrentYPosition, width, height - smallSizeOffset);


            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(TextureWareHouse.marioTexture, destinationRectangle, sourceRectangle, Color.White);
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
            Mario.marioSprite = new MarioSmallWalkLeftPart4(myGame);
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
        public bool isSmall()
        {
            return true;
        }

        public bool isFire()
        {
            return false;
        }

        public bool isCrouching()
        {
            return true;
        }

        public Vector2 GameObjectLocation()
        {
            return new Vector2(Mario.CurrentXPosition, Mario.CurrentYPosition);
        }
    }
}