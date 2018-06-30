using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioBigWalkRight : ISprite
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private Game1 myGame;
        private IPlayer player;


        //private int currentFrame = 16;
        private int currentFrame;
        private int startFrame = 16;
        private int endFrame = 19;
        
        

        public MarioBigWalkRight(Game1 game)
        {
            myGame = game;
            player = game.CurrentLevel.PlayerObject;
            currentFrame = startFrame;
        }


        public void Draw()
        {
            int width = TextureWareHouse.marioTexture.Width / player.TotalMarioColumns;
            int height = TextureWareHouse.marioTexture.Height / player.TotalMarioRows;
            int row = (int)((float)currentFrame / (float)player.TotalMarioColumns);
            int column = currentFrame % player.TotalMarioColumns;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(player.CurrentXPosition);

            Rectangle sourceRectangle = new Rectangle(width * column, (height * row), width, height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)player.CurrentYPosition, width, height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.marioTexture, destinationRectangle, sourceRectangle, player.MarioColor);
            myGame.SpriteBatch.End();
        }

        public void UpCommandCalled()
        {
            player.MarioSprite = new MarioBigJumpingRight(myGame);
        }

        public void DownCommandCalled()
        {
            player.MarioSprite = new MarioBigCrouchingRight(myGame);
        }

        public void LeftCommandCalled()
        {
            player.MarioSprite = new MarioBigIdleRight(myGame);
        }

        public void RightCommandCalled()
        {
            currentFrame++;
            if (currentFrame == endFrame)
                currentFrame = startFrame;
            //player.marioSprite = new MarioBigWalkRightPart2(myGame);
        }

        public void SmallMarioCommandCalled()
        {
            player.MarioSprite = new MarioSmallWalkRight(myGame);
        }

        public void BigMarioCommandCalled()
        {

        }

        public void FireMarioCommandCalled()
        {
            player.MarioSprite = new MarioFireWalkRight(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            if (!(player.MarioSprite is MarioDead))
                player.MarioSprite = new MarioDead(myGame);
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

        public Vector2 GetGameObjectLocation()
        {
            return new Vector2(player.CurrentXPosition, player.CurrentYPosition);
        }
    }

}