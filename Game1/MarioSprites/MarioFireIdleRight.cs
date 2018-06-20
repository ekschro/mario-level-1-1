using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioFireIdleRight : ISprite
    {
        private Game1 myGame;
        

        private int currentFrame = 42 + 28;

        public MarioFireIdleRight(Game1 game)
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

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.marioTexture, destinationRectangle, sourceRectangle, Mario.MarioColor);
            myGame.SpriteBatch.End();
        }

        public void UpCommandCalled()
        {
            Mario.playerSprite = new MarioFireJumpingRight(myGame);
        }

        public void DownCommandCalled()
        {
            Mario.playerSprite = new MarioFireCrouchingRight(myGame);
        }

        public void LeftCommandCalled()
        {
            Mario.playerSprite = new MarioFireIdleLeft(myGame);
        }

        public void RightCommandCalled()
        {
            Mario.playerSprite = new MarioFireWalkRight(myGame);
        }

        public void SmallMarioCommandCalled()
        {
            Mario.playerSprite = new MarioSmallIdleRight(myGame);
        }

        public void BigMarioCommandCalled()
        {
            Mario.playerSprite = new MarioBigIdleRight(myGame);
        }

        public void FireMarioCommandCalled()
        {

        }

        public void DeadMarioCommandCalled()
        {
            Mario.playerSprite = new MarioDead(myGame);
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

        public bool isCrouching()
        {
            return false;
        }

        public Vector2 GameObjectLocation()
        {
            return new Vector2(Mario.CurrentXPosition, Mario.CurrentYPosition);
        }
    }
}