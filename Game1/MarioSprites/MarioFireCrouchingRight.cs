/*
using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioFireCrouchingRight : ISprite
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private Game1 myGame;
        private IPlayer player;
        private int currentFrame = 15 + 56;

        public MarioFireCrouchingRight(Game1 game,IPlayer player)
        {
            myGame = game;
            this.player = player;
        }

        public void Draw()
        {
            int width = TextureWarehouse.marioTexture.Width / player.TotalMarioColumns;
            int height = TextureWarehouse.marioTexture.Height / player.TotalMarioRows;
            int row = (int)((float)currentFrame / (float)player.TotalMarioColumns);
            int column = currentFrame % player.TotalMarioColumns;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(player.CurrentXPos);

            Rectangle sourceRectangle = new Rectangle(width * column, (height * row), width, height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)player.CurrentYPos, width, height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.marioTexture, destinationRectangle, sourceRectangle, player.MarioColor);
            myGame.SpriteBatch.End();
        }

        public void UpCommandCalled()
        {
            player.MarioSprite = new MarioFireIdleRight(myGame, player);
        }

        public void DownCommandCalled()
        {

        }

        public void LeftCommandCalled()
        {
            player.MarioSprite = new MarioFireIdleLeft(myGame, player);
        }

        public void RightCommandCalled()
        {
            player.MarioSprite = new MarioFireIdleRight(myGame, player);
        }

        public void SmallMarioCommandCalled()
        {
            player.MarioSprite = new MarioSmallIdleRight(myGame, player);
        }

        public void BigMarioCommandCalled()
        {
            player.MarioSprite = new MarioBigCrouchingRight(myGame, player);
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
            return true;
        }

        public Vector2 GetGameObjectLocation()
        {
            return new Vector2(player.CurrentXPos, player.CurrentYPos);
        }
    }
}
*/