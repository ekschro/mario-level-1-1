using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioSmallJumpingRight : ISprite
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private Game1 myGame;
        

        private int currentFrame = 20 + 28;

        public MarioSmallJumpingRight(Game1 game)
        {
            myGame = game;
            
        }


        public void Draw()
        {
            int width = TextureWareHouse.marioTexture.Width / Mario.TotalMarioColumns;
            int height = TextureWareHouse.marioTexture.Height / Mario.TotalMarioRows;
            int row = (int)((float)currentFrame / (float)Mario.TotalMarioColumns);
            int column = currentFrame % Mario.TotalMarioColumns;


            Rectangle sourceRectangle = new Rectangle(width * column, (height * row), width, height);
            Rectangle destinationRectangle = new Rectangle((int)Mario.CurrentXPosition, (int)Mario.CurrentYPosition, width, height);


            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.marioTexture, destinationRectangle, sourceRectangle, Mario.MarioColor);
            myGame.SpriteBatch.End();
        }

        public void UpCommandCalled()
        {

        }

        public void DownCommandCalled()
        {
            Mario.MarioSprite = new MarioSmallIdleRight(myGame);
        }

        public void LeftCommandCalled()
        {
            Mario.MarioSprite = new MarioSmallIdleLeft(myGame);
        }

        public void RightCommandCalled()
        {
            Mario.MarioSprite = new MarioSmallIdleRight(myGame);
        }

        public void SmallMarioCommandCalled()
        {

        }

        public void BigMarioCommandCalled()
        {
            Mario.MarioSprite = new MarioBigJumpingRight(myGame);
        }

        public void FireMarioCommandCalled()
        {
            Mario.MarioSprite = new MarioFireJumpingRight(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            Mario.MarioSprite = new MarioDead(myGame);
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