using Microsoft.Xna.Framework;

namespace Game1
{
    public class MarioSmallWalkRight : ISprite
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private Game1 myGame;
        
       // private int currentFrame = 16 + 28;
        private int currentFrame;
        private int startFrame = 16 + 28;
        private int endFrame = 19 + 28;



        public MarioSmallWalkRight(Game1 game)
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


            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.marioTexture, destinationRectangle, sourceRectangle, Mario.MarioColor);
            myGame.SpriteBatch.End();
        }

        public void UpCommandCalled()
        {
            Mario.MarioSprite = new MarioSmallJumpingRight(myGame);
        }

        public void DownCommandCalled()
        {

        }

        public void LeftCommandCalled()
        {
            Mario.MarioSprite = new MarioSmallIdleRight(myGame);
        }

        public void RightCommandCalled()
        {
            currentFrame++;
            if (currentFrame == endFrame)
                currentFrame = startFrame;
            //Mario.marioSprite = new MarioSmallWalkRightPart2(myGame);
        }

        public void SmallMarioCommandCalled()
        {

        }

        public void BigMarioCommandCalled()
        {
            Mario.MarioSprite = new MarioBigWalkRight(myGame);
        }

        public void FireMarioCommandCalled()
        {
            Mario.MarioSprite = new MarioFireWalkRight(myGame);
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