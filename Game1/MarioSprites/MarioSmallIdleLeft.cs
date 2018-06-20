using Microsoft.Xna.Framework;
using System;

namespace Game1
{
    public class MarioSmallIdleLeft : ISprite
    {
        private Game1 myGame;
        

        private int currentFrame = 41;
        

        public MarioSmallIdleLeft(Game1 game)
        {
            myGame = game;
            
        }


        public void Draw()
        {
            int width = TextureWareHouse.marioTexture.Width / Mario.TotalMarioColumns;
            int height = TextureWareHouse.marioTexture.Height / Mario.TotalMarioRows;
            int row = (int)((float)currentFrame / (float)Mario.TotalMarioColumns);
            int column = currentFrame % Mario.TotalMarioColumns;


            Rectangle sourceRectangle = new Rectangle(width * column, (height * row), width, height );
            Rectangle destinationRectangle = new Rectangle((int)Mario.CurrentXPosition, (int)Mario.CurrentYPosition, width, height);


            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.marioTexture, destinationRectangle, sourceRectangle, Mario.MarioColor);
            myGame.SpriteBatch.End();
        }

        public void UpCommandCalled()
        {
            Mario.playerSprite = new MarioSmallJumpingLeft(myGame);
        }

        public void DownCommandCalled()
        {

        }

        public void LeftCommandCalled()
        {
            Mario.playerSprite = new MarioSmallWalkLeft(myGame);
        }

        public void RightCommandCalled()
        {
            Mario.playerSprite = new MarioSmallIdleRight(myGame);
        }

        public void SmallMarioCommandCalled()
        {

        }

        public void BigMarioCommandCalled()
        {
            Mario.playerSprite = new MarioBigIdleLeft(myGame);
        }

        public void FireMarioCommandCalled()
        {
            Mario.playerSprite = new MarioFireIdleLeft(myGame);
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