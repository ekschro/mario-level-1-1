using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioFireIdleLeft : ISprite
    {
        private Game1 myGame;
        

        private int currentFrame = 41 + 28;

        public MarioFireIdleLeft(Game1 game)
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
            Mario.playerSprite = new MarioFireJumpingLeft(myGame);
        }

        public void DownCommandCalled()
        {
            Mario.playerSprite = new MarioFireCrouchingLeft(myGame);
        }

        public void LeftCommandCalled()
        {
            Mario.playerSprite = new MarioFireWalkLeft(myGame);
        }

        public void RightCommandCalled()
        {
            Mario.playerSprite = new MarioFireIdleRight(myGame);
        }

        public void SmallMarioCommandCalled()
        {
            Mario.playerSprite = new MarioSmallIdleLeft(myGame);
        }

        public void BigMarioCommandCalled()
        {
            Mario.playerSprite = new MarioBigIdleLeft(myGame);
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