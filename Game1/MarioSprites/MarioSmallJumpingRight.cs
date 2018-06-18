﻿using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioSmallJumpingRight : ISprite
    {
        private Game1 myGame;
        

        private int currentFrame = 20 + 28;

        public MarioSmallJumpingRight(Game1 game)
        {
            myGame = game;
            
        }


        public void Draw()
        {
            int width = TextureWareHouse.marioTexture.Width / Mario.TotalMarioColumns;
            int height = TextureWareHouse.marioTexture.Height / Mario.TotalMarioRows;
            int row = (int)((float)currentFrame / (float)Mario.TotalMarioColumns);
            int column = currentFrame % Mario.TotalMarioColumns;


            Rectangle sourceRectangle = new Rectangle(width * column, (height * row), width, height);
            Rectangle destinationRectangle = new Rectangle((int)Mario.CurrentXPosition, (int)Mario.CurrentYPosition, width, height);


            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(TextureWareHouse.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {

        }

        public void DownCommandCalled()
        {
            Mario.marioSprite = new MarioSmallIdleRight(myGame);
        }

        public void LeftCommandCalled()
        {
            Mario.marioSprite = new MarioSmallIdleLeft(myGame);
        }

        public void RightCommandCalled()
        {
            Mario.marioSprite = new MarioSmallIdleRight(myGame);
        }

        public void SmallMarioCommandCalled()
        {

        }

        public void BigMarioCommandCalled()
        {
            Mario.marioSprite = new MarioBigJumpingRight(myGame);
        }

        public void FireMarioCommandCalled()
        {
            Mario.marioSprite = new MarioFireJumpingRight(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            Mario.marioSprite = new MarioDead(myGame);
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