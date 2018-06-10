﻿using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioFireIdleLeft : ISprite
    {
        private Game1 myGame;
        private Mario marioObject;

        private int currentFrame = 41 + 28;

        public MarioFireIdleLeft(Game1 game, Mario mario)
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
            marioObject.MarioSprite = new MarioFireJumpingLeft(myGame, marioObject);
        }

        public void DownCommandCalled()
        {
            marioObject.MarioSprite = new MarioFireCrouchingLeft(myGame, marioObject);
        }

        public void LeftCommandCalled()
        {
            marioObject.MarioSprite = new MarioFireWalkLeft(myGame, marioObject);
        }

        public void RightCommandCalled()
        {
            marioObject.MarioSprite = new MarioFireIdleRight(myGame, marioObject);
        }

        public void SmallMarioCommandCalled()
        {
            marioObject.MarioSprite = new MarioSmallIdleLeft(myGame, marioObject);
        }

        public void BigMarioCommandCalled()
        {
            marioObject.MarioSprite = new MarioBigIdleLeft(myGame, marioObject);
        }

        public void FireMarioCommandCalled()
        {

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