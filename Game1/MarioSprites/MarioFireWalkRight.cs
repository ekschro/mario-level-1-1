using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioFireWalkRight : ISprite
    {
        private Game1 myGame;
        

        private int currentFrame = 16 + 56;
       
        
        

        public MarioFireWalkRight(Game1 game)
        {
            myGame = game;
            
        }


        public void Draw()
        {
            int width = TextureWareHouse.marioTexture.Width / Mario.TotalMarioColumns;
            int height = TextureWareHouse.marioTexture.Height / Mario.TotalMarioRows;
            int row = (int)((float)currentFrame / (float)Mario.TotalMarioColumns);
            int column = currentFrame % Mario.TotalMarioColumns;

            
            

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Mario.CurrentXPosition, (int)Mario.CurrentYPosition, width, height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(TextureWareHouse.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            Mario.marioSprite = new MarioFireJumpingRight(myGame);
        }

        public void DownCommandCalled()
        {
            Mario.marioSprite = new MarioFireCrouchingRight(myGame);
        }

        public void LeftCommandCalled()
        {
            Mario.marioSprite = new MarioFireIdleRight(myGame);
        }

        public void RightCommandCalled()
        {
            Mario.marioSprite = new MarioFireWalkRightPart2(myGame);
        }

        public void SmallMarioCommandCalled()
        {
            Mario.marioSprite = new MarioSmallWalkRight(myGame);
        }

        public void BigMarioCommandCalled()
        {
            Mario.marioSprite = new MarioBigWalkRight(myGame);
        }

        public void FireMarioCommandCalled()
        {

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
            return true;
        }
        public Vector2 GameObjectLocation()
        {
            return new Vector2(Mario.CurrentXPosition, Mario.CurrentYPosition);
        }
    }
}