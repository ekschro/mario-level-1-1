using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioBigIdleRight : ISprite
    {
        private Game1 myGame;
        

        private int currentFrame = 42 - 28;

        public MarioBigIdleRight(Game1 game)
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
            Mario.playerSprite = new MarioBigJumpingRight(myGame);
        }

        public void DownCommandCalled()
        {
            Mario.playerSprite = new MarioBigCrouchingRight(myGame);
        }

        public void LeftCommandCalled()
        {
            Mario.playerSprite = new MarioBigIdleLeft(myGame);
        }

        public void RightCommandCalled()
        {
            Mario.playerSprite = new MarioBigWalkRight(myGame);
        }

        public void SmallMarioCommandCalled()
        {
            Mario.playerSprite = new MarioSmallIdleRight(myGame);
        }

        public void BigMarioCommandCalled()
        {

        }

        public void FireMarioCommandCalled()
        {
            Mario.playerSprite = new MarioFireIdleRight(myGame);
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
            return false;
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