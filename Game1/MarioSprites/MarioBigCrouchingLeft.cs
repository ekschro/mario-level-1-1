﻿using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioBigCrouchingLeft : ISprite
    {
        private Game1 myGame;
        private Mario marioObject;

        private int currentFrame = 12;

        public MarioBigCrouchingLeft(Game1 game, Mario mario)
        {
            myGame = game;
            marioObject = mario;
        }


        public void Draw()
        {
            int width = myGame.marioTexture.Width / myGame.totalMarioColumns;
            int height = myGame.marioTexture.Height / myGame.totalMarioRows;
            int row = (int)((float)currentFrame / (float)myGame.totalMarioColumns);
            int column = currentFrame % myGame.totalMarioColumns;

            

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)marioObject.GetCurrentXPosition(), (int)marioObject.GetCurrentYPosition(), width, height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            marioObject.MarioSprite = new MarioBigIdleLeft(myGame, marioObject);
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
            marioObject.MarioSprite = new MarioSmallIdleLeft(myGame, marioObject);
        }

        public void BigMarioCommandCalled()
        {

        }

        public void FireMarioCommandCalled()
        {
            marioObject.MarioSprite = new MarioFireCrouchingLeft(myGame, marioObject);
        }

        public void DeadMarioCommandCalled()
        {
            marioObject.MarioSprite = new MarioDead(myGame, marioObject);
        }

        public void Update()
        {

        }
    }
}