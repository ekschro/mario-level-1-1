﻿using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioFireWalkRightPart4 : ISprite
    {
        private Game1 myGame;
        private Mario marioObject;
        private int currentFrame = 17 + 56;
        
        
        

        public MarioFireWalkRightPart4(Game1 game, Mario mario)
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
            Rectangle destinationRectangle = new Rectangle((int)Mario.currentXPosition, (int)Mario.currentYPosition, width, height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            Mario.marioSprite = new MarioFireJumpingRight(myGame, marioObject);
        }

        public void DownCommandCalled()
        {
            Mario.marioSprite = new MarioFireCrouchingRight(myGame, marioObject);
        }

        public void LeftCommandCalled()
        {
            Mario.marioSprite = new MarioFireIdleRight(myGame, marioObject);
        }

        public void RightCommandCalled()
        {
            Mario.marioSprite = new MarioFireWalkRight(myGame, marioObject);
        }

        public void SmallMarioCommandCalled()
        {
            Mario.marioSprite = new MarioSmallWalkRight(myGame, marioObject);
        }

        public void BigMarioCommandCalled()
        {
            Mario.marioSprite = new MarioBigWalkRight(myGame, marioObject);
        }

        public void FireMarioCommandCalled()
        {

        }

        public void DeadMarioCommandCalled()
        {
            Mario.marioSprite = new MarioDead(myGame, marioObject);
        }

        public void Update()
        {
        }

    }
}