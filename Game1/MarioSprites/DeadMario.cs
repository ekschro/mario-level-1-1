using Microsoft.Xna.Framework;
using System;
namespace Game1 { 
public class MarioDead : ISprite
{
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private Game1 myGame;
    

    private int currentFrame = 12 + 28;

        private float bouncePosition;
        private float bounceVelocity;
        private float bounceGravity;
        private float bounceTimer;

    public MarioDead(Game1 game)
    {
        myGame = game;

            bouncePosition = 0f;
            bounceVelocity = -3.0f;
            bounceGravity = .07f;
            bounceTimer = ((bounceVelocity * bounceVelocity) / bounceGravity);
    }


        public void Draw()
        {
            int width = TextureWareHouse.marioTexture.Width / Mario.TotalMarioColumns;
            int height = TextureWareHouse.marioTexture.Height / Mario.TotalMarioRows;
            int row = (int)((float)currentFrame / (float)Mario.TotalMarioColumns);
            int column = currentFrame % Mario.TotalMarioColumns;
            Bounce();

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(Mario.CurrentXPosition);
            int drawLocationY = (int)(Mario.CurrentYPosition  + bouncePosition);

            Rectangle sourceRectangle = new Rectangle(width * column, (height * row), width, height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, drawLocationY, width, height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.marioTexture, destinationRectangle, sourceRectangle, Mario.MarioColor);
            myGame.SpriteBatch.End();
        }

    public void UpCommandCalled()
    {
       
    }

    public void DownCommandCalled()
    {
        
    }

    public void LeftCommandCalled()
    {

    }

        public void RightCommandCalled()
        {

        }
    public void SmallMarioCommandCalled()
    {
        Mario.MarioSprite = new MarioSmallIdleRight(myGame);
    }

        public void BigMarioCommandCalled() => Mario.MarioSprite = new MarioBigIdleRight(myGame);

        public void FireMarioCommandCalled() => Mario.MarioSprite = new MarioFireIdleRight(myGame);

        public void DeadMarioCommandCalled()
        {
            if (!(Mario.MarioSprite is MarioDead))
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


        public Vector2 GetGameObjectLocation()
        {
            return new Vector2(Mario.CurrentXPosition, Mario.CurrentYPosition);
        }

        public void Bounce()
        {
            bounceVelocity += bounceGravity;
            bouncePosition += bounceVelocity;
            if (--bounceTimer < 0)
                myGame.Reset();
        }
    }
}

