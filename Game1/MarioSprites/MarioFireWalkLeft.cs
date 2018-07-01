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
        private IPlayer player;
        private int startFrame = 11 + 56;
        private int endFrame = 8 + 56;
        
        

        public MarioFireWalkLeft(Game1 game,IPlayer player)
        {
            myGame = game;
            currentFrame = startFrame;
            this.player = player;
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
            player.MarioSprite = new MarioFireJumpingLeft(myGame, player);
        }

        public void DownCommandCalled()
        {
            player.MarioSprite = new MarioFireCrouchingLeft(myGame, player);
        }

        public void LeftCommandCalled()
        {
            currentFrame--;
            if (currentFrame == endFrame)
                currentFrame = startFrame;
            //player.marioSprite = new MarioFireWalkLeftPart2(myGame);
        }

        public void RightCommandCalled()
        {
            player.MarioSprite = new MarioFireIdleLeft(myGame, player);
        }

        public void SmallMarioCommandCalled()
        {
            player.MarioSprite = new MarioSmallWalkLeft(myGame, player);
        }

        public void BigMarioCommandCalled()
        {
            player.MarioSprite = new MarioBigWalkLeft(myGame, player);
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