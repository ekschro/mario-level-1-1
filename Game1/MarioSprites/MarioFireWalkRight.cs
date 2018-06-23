using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioFireWalkRight : ISprite
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private Game1 myGame;


        //private int currentFrame = 16 + 56;
        private int currentFrame;
        private int startFrame = 16 + 56;
        private int endFrame = 19 + 56;
        
        

        public MarioFireWalkRight(Game1 game)
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

            
            

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Mario.CurrentXPosition, (int)Mario.CurrentYPosition, width, height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.marioTexture, destinationRectangle, sourceRectangle, Mario.MarioColor);
            myGame.SpriteBatch.End();
        }

        public void UpCommandCalled()
        {
            Mario.MarioSprite = new MarioFireJumpingRight(myGame);
        }

        public void DownCommandCalled()
        {
            Mario.MarioSprite = new MarioFireCrouchingRight(myGame);
        }

        public void LeftCommandCalled()
        {
            Mario.MarioSprite = new MarioFireIdleRight(myGame);
        }

        public void RightCommandCalled()
        {
            currentFrame++;
            if (currentFrame == endFrame)
                currentFrame = startFrame;
            //Mario.marioSprite = new MarioFireWalkRightPart2(myGame);
        }

        public void SmallMarioCommandCalled()
        {
            Mario.MarioSprite = new MarioSmallWalkRight(myGame);
        }

        public void BigMarioCommandCalled()
        {
            Mario.MarioSprite = new MarioBigWalkRight(myGame);
        }

        public void FireMarioCommandCalled()
        {

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