﻿using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioSmallJumpingLeft : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 7 + 28;

        public MarioSmallJumpingLeft(Game1 game)
        {
            myGame = game;
        }


        public void Draw()
        {
            int width = myGame.marioTexture.Width / myGame.totalMarioColumns;
            int height = myGame.marioTexture.Height / myGame.totalMarioRows;
            int row = (int)((float)currentFrame / (float)myGame.totalMarioColumns);
            int column = currentFrame % myGame.totalMarioColumns;

            myGame.currentLocation.Y = myGame.startingLocation.Y;
            myGame.currentLocation.X = myGame.startingLocation.X;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {

        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioSmallIdleLeft(myGame);
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
            myGame.marioSprite = new MarioBigJumpingLeft(myGame);
        }

        public void FireMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireJumpingLeft(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioDead(myGame);
        }

        public void Update()
        {

        }
    }
}