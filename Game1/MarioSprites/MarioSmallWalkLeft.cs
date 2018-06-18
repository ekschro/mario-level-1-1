using Microsoft.Xna.Framework;
using System;

namespace Game1
{
    public class MarioSmallWalkLeft : ISprite
    {
        private Game1 myGame;
        
        //private int currentFrame = 11 + 28;
        private int startFrame = 11 + 28;
        private int endFrame = 8 + 28;
        private int currentFrame;
        

        public MarioSmallWalkLeft(Game1 game)
        {
            myGame = game;
            currentFrame = startFrame;
        }


        public void Draw()
        {
            int width = TextureWareHouse.marioTexture.Width / Mario.TotalMarioColumns;
            int height = TextureWareHouse.marioTexture.Height / Mario.TotalMarioRows;
            int row = (int)((float)currentFrame / (float)Mario.TotalMarioColumns);
            int column = currentFrame % Mario.TotalMarioColumns;


            Rectangle sourceRectangle = new Rectangle(width * column, (height * row), width, height);
            Rectangle destinationRectangle = new Rectangle((int)Mario.CurrentXPosition, (int)Mario.CurrentYPosition, width, height);


            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(TextureWareHouse.marioTexture, destinationRectangle, sourceRectangle, Mario.MarioColor);
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
            currentFrame--;
            if (currentFrame == endFrame)
                currentFrame = startFrame;
            //Mario.marioSprite = new MarioSmallWalkLeftPart2(myGame);
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