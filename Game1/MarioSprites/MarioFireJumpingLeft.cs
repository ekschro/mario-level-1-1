﻿using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioFireJumpingLeft : ISprite
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private Game1 myGame;
        private IPlayer player;
        private int currentFrame = 7 + 56;

        public MarioFireJumpingLeft(Game1 game)
        {
            myGame = game;
            player = game.CurrentLevel.PlayerObject;
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

        }

        public void DownCommandCalled()
        {
            player.MarioSprite = new MarioFireIdleLeft(myGame);
        }

        public void LeftCommandCalled()
        {
            
        }

        public void RightCommandCalled()
        {
           
        }

        public void SmallMarioCommandCalled()
        {
            player.MarioSprite = new MarioSmallJumpingLeft(myGame);
        }

        public void BigMarioCommandCalled()
        {
            player.MarioSprite = new MarioBigJumpingLeft(myGame);
        }

        public void FireMarioCommandCalled()
        {

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
            return true;
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