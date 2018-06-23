using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioFireWalkLeft : ISprite
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private Game1 myGame;


        //private int currentFrame = 11 + 56;
        private int currentFrame;
        private int startFrame = 11 + 56;
        private int endFrame = 8 + 56;
        
        

        public MarioFireWalkLeft(Game1 game)
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
            Mario.MarioSprite = new MarioFireJumpingLeft(myGame);
        }

        public void DownCommandCalled()
        {
            Mario.MarioSprite = new MarioFireCrouchingLeft(myGame);
        }

        public void LeftCommandCalled()
        {
            currentFrame--;
            if (currentFrame == endFrame)
                currentFrame = startFrame;
            //Mario.marioSprite = new MarioFireWalkLeftPart2(myGame);
        }

        public void RightCommandCalled()
        {
            Mario.MarioSprite = new MarioFireIdleLeft(myGame);
        }

        public void SmallMarioCommandCalled()
        {
            Mario.MarioSprite = new MarioSmallWalkLeft(myGame);
        }

        public void BigMarioCommandCalled()
        {
            Mario.MarioSprite = new MarioBigWalkLeft(myGame);
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