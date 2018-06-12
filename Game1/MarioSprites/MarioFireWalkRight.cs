﻿using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioFireWalkRight : ISprite
    {
        private Game1 myGame;
        

        private int currentFrame = 16 + 56;
       
        
        

        public MarioFireWalkRight(Game1 game)
        {
            myGame = game;
            
        }


        public void Draw()
        {
            int width = myGame.marioTexture.Width / myGame.totalMarioColumns;
            int height = myGame.marioTexture.Height / myGame.totalMarioRows;
            int row = (int)((float)currentFrame / (float)myGame.totalMarioColumns);
            int column = currentFrame % myGame.totalMarioColumns;

            
            

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Mario.CurrentXPosition, (int)Mario.CurrentYPosition, width, height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            Mario.marioSprite = new MarioFireJumpingRight(myGame);
        }

        public void DownCommandCalled()
        {
            Mario.marioSprite = new MarioFireCrouchingRight(myGame);
        }

        public void LeftCommandCalled()
        {
            Mario.marioSprite = new MarioFireIdleRight(myGame);
        }

        public void RightCommandCalled()
        {
            Mario.marioSprite = new MarioFireWalkRightPart2(myGame);
        }

        public void SmallMarioCommandCalled()
        {
            Mario.marioSprite = new MarioSmallWalkRight(myGame);
        }

        public void BigMarioCommandCalled()
        {
            Mario.marioSprite = new MarioBigWalkRight(myGame);
        }

        public void FireMarioCommandCalled()
        {

        }

        public void DeadMarioCommandCalled()
        {
            Mario.marioSprite = new MarioDead(myGame);
        }

        public void Update()
        {
            
        }

    }
}