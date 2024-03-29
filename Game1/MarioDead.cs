﻿using Microsoft.Xna.Framework;

namespace Game1
{
    public class MarioBigIdleRight : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 15 + 28;

        public MarioBigIdleRight(Game1 game)
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

        }

        public void LeftCommandCalled()
        {

        }

        public void RightCommandCalled()
        {

        }

        public void SmallMarioCommandCalled()
        {
            myGame.marioSprite = new MarioSmallIdleRight(myGame);
        }

        public void BigMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigIdleRight(myGame);
        }

        public void FireMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireIdleRight(myGame);
        }

        public void DeadMarioCommandCalled()
        {

        }

        public void Update()
        {

        }
    }
}