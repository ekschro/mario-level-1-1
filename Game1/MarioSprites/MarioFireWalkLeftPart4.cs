using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioFireWalkLeftPart4 : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 10 + 56;
        
        
        

        public MarioFireWalkLeftPart4(Game1 game)
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
            Mario.marioSprite = new MarioFireJumpingLeft(myGame);
        }

        public void DownCommandCalled()
        {
            Mario.marioSprite = new MarioFireCrouchingLeft(myGame);
        }

        public void LeftCommandCalled()
        {
            Mario.marioSprite = new MarioFireWalkLeft(myGame);
        }

        public void RightCommandCalled()
        {
            Mario.marioSprite = new MarioFireIdleLeft(myGame);
        }

        public void SmallMarioCommandCalled()
        {
            Mario.marioSprite = new MarioSmallWalkLeft(myGame);
        }

        public void BigMarioCommandCalled()
        {
            Mario.marioSprite = new MarioBigWalkLeft(myGame);
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