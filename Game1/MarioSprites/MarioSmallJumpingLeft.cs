﻿using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioSmallJumpingLeft : ISprite
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private Game1 myGame;
        

        private int currentFrame = 7 + 28;

        public MarioSmallJumpingLeft(Game1 game)
        {
            myGame = game;
            
        }


        public void Draw()
        {
            int width = TextureWareHouse.marioTexture.Width / Mario.TotalMarioColumns;
            int height = TextureWareHouse.marioTexture.Height / Mario.TotalMarioRows;
            int row = (int)((float)currentFrame / (float)Mario.TotalMarioColumns);
            int column = currentFrame % Mario.TotalMarioColumns;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(Mario.CurrentXPosition);

            Rectangle sourceRectangle = new Rectangle(width * column, (height * row), width, height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)Mario.CurrentYPosition, width, height);


            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.marioTexture, destinationRectangle, sourceRectangle, Mario.MarioColor);
            myGame.SpriteBatch.End();
        }

        public void UpCommandCalled()
        {

        }

        public void DownCommandCalled()
        {
            Mario.MarioSprite = new MarioSmallIdleLeft(myGame);
        }

        public void LeftCommandCalled()
        {
            
        }

        public void RightCommandCalled()
        {
            
        }

        public void SmallMarioCommandCalled()
        {

        }

        public void BigMarioCommandCalled()
        {
            Mario.MarioSprite = new MarioBigJumpingLeft(myGame);
        }

        public void FireMarioCommandCalled()
        {
            Mario.MarioSprite = new MarioFireJumpingLeft(myGame);
        }

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
    }
}