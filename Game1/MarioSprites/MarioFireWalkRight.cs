using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioFireWalkRight : ISprite
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private Game1 myGame;
        private IPlayer player;

        //private int currentFrame = 16 + 56;
        private int currentFrame;
        private int startFrame = 16 + 56;
        private int endFrame = 19 + 56;
        
        public MarioFireWalkRight(Game1 game,IPlayer player)
        {
            myGame = game;
            this.player = player;
            currentFrame = startFrame;
        }


        public void Draw()
        {
            int width = TextureWareHouse.marioTexture.Width / player.TotalMarioColumns;
            int height = TextureWareHouse.marioTexture.Height / player.TotalMarioRows;
            int row = (int)((float)currentFrame / (float)player.TotalMarioColumns);
            int column = currentFrame % player.TotalMarioColumns;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(player.CurrentXPos);

            Rectangle sourceRectangle = new Rectangle(width * column, (height * row), width, height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)player.CurrentYPos, width, height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.marioTexture, destinationRectangle, sourceRectangle, player.MarioColor);
            myGame.SpriteBatch.End();
        }

        public void UpCommandCalled()
        {
            player.MarioSprite = new MarioFireJumpingRight(myGame, player);
        }

        public void DownCommandCalled()
        {
            player.MarioSprite = new MarioFireCrouchingRight(myGame, player);
        }

        public void LeftCommandCalled()
        {
            player.MarioSprite = new MarioFireIdleRight(myGame, player);
        }

        public void RightCommandCalled()
        {
            currentFrame++;
            if (currentFrame == endFrame)
                currentFrame = startFrame;
            //player.marioSprite = new MarioFireWalkRightPart2(myGame);
        }

        public void SmallMarioCommandCalled()
        {
            player.MarioSprite = new MarioSmallWalkRight(myGame, player);
        }

        public void BigMarioCommandCalled()
        {
            player.MarioSprite = new MarioBigWalkRight(myGame, player);
        }

        public void FireMarioCommandCalled()
        {

        }

        public void DeadMarioCommandCalled()
        {
            if (!(player.MarioSprite is MarioDead))
                player.MarioSprite = new MarioDead(myGame, player);
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

        public Vector2 GetGameObjectLocation()
        {
            return new Vector2(player.CurrentXPos, player.CurrentYPos);
        }
    }
}