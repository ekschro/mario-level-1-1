﻿using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public interface ISprite
    { 
        void Draw();
        void UpCommandCalled();
        void DownCommandCalled();
        void LeftCommandCalled();
        void RightCommandCalled();
        void SmallMarioCommandCalled();
        void BigMarioCommandCalled();
        void FireMarioCommandCalled();
        void DeadMarioCommandCalled();
    }

    public class MarioSmallIdleRight : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 43;

        public MarioSmallIdleRight(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioSmallJumpingRight(myGame);
        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioSmallCrouchingRight(myGame)
        }

        public void LeftCommandCalled()
        {
            myGame.marioSprite = new MarioSmallIdleLeft(myGame);
        }

        public void RightCommandCalled()
        {
            myGame.marioSprite = new MarioSmallWalkRight(myGame);
        }

        public void SmallMarioCommandCalled()
        {
            
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
            myGame.marioSprite = new MarioSmallDeadRight(myGame);
        }
    }
    public class MarioSmallIdleLeft : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 42;

        public MarioSmallIdleLeft(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioSmallJumpingLeft(myGame);
        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioSmallCrouchingLeft(myGame)
        }

        public void LeftCommandCalled()
        {
            myGame.marioSprite = new MarioSmallWalkLeft(myGame);
        }

        public void RightCommandCalled()
        {
            myGame.marioSprite = new MarioSmallIdleRight(myGame);
        }

        public void SmallMarioCommandCalled()
        {

        }

        public void BigMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigIdleLeft(myGame);
        }

        public void FireMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireIdleLeft(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioSmallDeadLeft(myGame);
        }
    }

    public class MarioSmallWalkRight : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 19 + 28;

        public MarioSmallWalkRight(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioSmallJumpingRight(myGame);
        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioSmallCrouchingRight(myGame)
        }

        public void LeftCommandCalled()
        {
            myGame.marioSprite = new MarioSmallIdleRight(myGame);
        }

        public void RightCommandCalled()
        {
            
        }

        public void SmallMarioCommandCalled()
        {

        }

        public void BigMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigWalkRight(myGame);
        }

        public void FireMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireWalkRight(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioSmallDeadRight(myGame);
        }
    }
    public class MarioSmallWalkLeft : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 11 + 28;

        public MarioSmallWalkLeft(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioSmallJumpingLeft(myGame);
        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioSmallCrouchingLeft(myGame)
        }

        public void LeftCommandCalled()
        {
            
        }

        public void RightCommandCalled()
        {
            myGame.marioSprite = new MarioSmallIdleLeft(myGame);
        }

        public void SmallMarioCommandCalled()
        {

        }

        public void BigMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigWalkLeft(myGame);
        }

        public void FireMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireWalkLeft(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioSmallDeadLeft(myGame);
        }
    }
    public class MarioSmallJumpingLeft : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 8 + 28;

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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            
        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioSmallIdleLeft(myGame)
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
            myGame.marioSprite = new MarioSmallDeadLeft(myGame);
        }
    }
    public class MarioSmallJumpingRight : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 21 + 28;

        public MarioSmallJumpingRight(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            
        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioSmallIdleRight(myGame)
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
            myGame.marioSprite = new MarioBigJumpingRight(myGame);
        }

        public void FireMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireJumpingRight(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioSmallDeadRight(myGame);
        }
    }
    public class MarioSmallCrouchingLeft : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 13 + 28;

        public MarioSmallCrouchingLeft(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioSmallIdleLeft(myGame);
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

        }

        public void BigMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigCrouchingLeft(myGame);
        }

        public void FireMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireCrouchingLeft(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioSmallDeadLeft(myGame);
        }
    }
    public class MarioSmallCrouchingRight : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 16 + 28;

        public MarioSmallCrouchingRight(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioSmallIdleLeft(myGame);
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

        }

        public void BigMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigCrouchingRight(myGame);
        }

        public void FireMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireCrouchingRight(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioSmallDeadRight(myGame);
        }
    }
    public class MarioSmallDeadLeft : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 1 + 28;

        public MarioSmallDeadLeft(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

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
    }
    public class MarioSmallDeadRight : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 28 + 28;

        public MarioSmallDeadRight(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

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
    }
    public class MarioBigIdleRight : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 43 - 28;

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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioBigJumpingRight(myGame);
        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioBigCrouchingRight(myGame)
        }

        public void LeftCommandCalled()
        {
            myGame.marioSprite = new MarioBigIdleLeft(myGame);
        }

        public void RightCommandCalled()
        {
            myGame.marioSprite = new MarioBigWalkRight(myGame);
        }

        public void SmallMarioCommandCalled()
        {
            myGame.marioSprite = new MarioSmallIdleRight(myGame);
        }

        public void BigMarioCommandCalled()
        {
            
        }

        public void FireMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireIdleRight(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigDeadRight(myGame);
        }
    }
    public class MarioBigIdleLeft : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 42- 28;

        public MarioBigIdleLeft(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioBigJumpingLeft(myGame);
        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioBigCrouchingLeft(myGame)
        }

        public void LeftCommandCalled()
        {
            myGame.marioSprite = new MarioBigWalkLeft(myGame);
        }

        public void RightCommandCalled()
        {
            myGame.marioSprite = new MarioBigIdleRight(myGame);
        }

        public void SmallMarioCommandCalled()
        {
            myGame.marioSprite = new MarioSmallIdleLeft(myGame);
        }

        public void BigMarioCommandCalled()
        {
            
        }

        public void FireMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireIdleLeft(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigDeadLeft(myGame);
        }
    }

    public class MarioBigWalkRight : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 19;

        public MarioBigWalkRight(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioBigJumpingRight(myGame);
        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioBigCrouchingRight(myGame)
        }

        public void LeftCommandCalled()
        {
            myGame.marioSprite = new MarioBigIdleRight(myGame);
        }

        public void RightCommandCalled()
        {

        }

        public void SmallMarioCommandCalled()
        {
            myGame.marioSprite = new MarioSmallWalkRight(myGame);
        }

        public void BigMarioCommandCalled()
        {
            
        }

        public void FireMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireWalkRight(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigDeadRight(myGame);
        }
    }
    public class MarioBigWalkLeft : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 11;

        public MarioBigWalkLeft(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioBigJumpingLeft(myGame);
        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioBigCrouchingLeft(myGame)
        }

        public void LeftCommandCalled()
        {

        }

        public void RightCommandCalled()
        {
            myGame.marioSprite = new MarioBigIdleLeft(myGame);
        }

        public void SmallMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigWalkLeft(myGame);
        }

        public void BigMarioCommandCalled()
        {
            
        }

        public void FireMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireWalkLeft(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigDeadLeft(myGame);
        }
    }
    public class MarioBigJumpingLeft : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 8;

        public MarioBigJumpingLeft(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {

        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioBigIdleLeft(myGame)
        }

        public void LeftCommandCalled()
        {

        }

        public void RightCommandCalled()
        {

        }

        public void SmallMarioCommandCalled()
        {
            myGame.marioSprite = new MarioSmallJumpingLeft(myGame);
        }

        public void BigMarioCommandCalled()
        {
            
        }

        public void FireMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireJumpingLeft(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigDeadLeft(myGame);
        }
    }
    public class MarioBigJumpingRight : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 21;

        public MarioBigJumpingRight(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {

        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioBigIdleRight(myGame)
        }

        public void LeftCommandCalled()
        {

        }

        public void RightCommandCalled()
        {

        }

        public void SmallMarioCommandCalled()
        {
            myGame.marioSprite = new MarioSmallJumpingRight(myGame);
        }

        public void BigMarioCommandCalled()
        {
            
        }

        public void FireMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireJumpingRight(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigDeadRight(myGame);
        }
    }
    public class MarioBigCrouchingLeft : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 13;

        public MarioBigCrouchingLeft(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioBigIdleLeft(myGame);
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
            myGame.marioSprite = new MarioSmallCrouchingLeft(myGame);
        }

        public void BigMarioCommandCalled()
        {
            
        }

        public void FireMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireCrouchingLeft(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigDeadLeft(myGame);
        }
    }
    public class MarioBigCrouchingRight : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 16;

        public MarioBigCrouchingRight(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioBigIdleLeft(myGame);
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
            myGame.marioSprite = new MarioSmallCrouchingRight(myGame);
        }

        public void BigMarioCommandCalled()
        {
            
        }

        public void FireMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireCrouchingRight(myGame);
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigDeadRight(myGame);
        }
    }
    public class MarioBigDeadLeft : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 1;

        public MarioBigDeadLeft(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

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
    }
    public class MarioBigDeadRight : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 28;

        public MarioBigDeadRight(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

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
    }
    public class MarioFireIdleRight : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 43 + 28;

        public MarioFireIdleRight(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioFireJumpingRight(myGame);
        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioFireCrouchingRight(myGame)
        }

        public void LeftCommandCalled()
        {
            myGame.marioSprite = new MarioFireIdleLeft(myGame);
        }

        public void RightCommandCalled()
        {
            myGame.marioSprite = new MarioFireWalkRight(myGame);
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
            
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireDeadRight(myGame);
        }
    }
    public class MarioFireIdleLeft : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 42 + 28;

        public MarioFireIdleLeft(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioFireJumpingLeft(myGame);
        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioFireCrouchingLeft(myGame)
        }

        public void LeftCommandCalled()
        {
            myGame.marioSprite = new MarioFireWalkLeft(myGame);
        }

        public void RightCommandCalled()
        {
            myGame.marioSprite = new MarioFireIdleRight(myGame);
        }

        public void SmallMarioCommandCalled()
        {
            myGame.marioSprite = new MarioSmallIdleLeft(myGame);
        }

        public void BigMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigIdleLeft(myGame);
        }

        public void FireMarioCommandCalled()
        {
            
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireDeadLeft(myGame);
        }
    }

    public class MarioFireWalkRight : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 19 + 56;

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

            myGame.currentLocation.Y = myGame.startingLocation.Y;
            myGame.currentLocation.X = myGame.startingLocation.X;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioFireJumpingRight(myGame);
        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioFireCrouchingRight(myGame)
        }

        public void LeftCommandCalled()
        {
            myGame.marioSprite = new MarioFireIdleRight(myGame);
        }

        public void RightCommandCalled()
        {

        }

        public void SmallMarioCommandCalled()
        {
            myGame.marioSprite = new MarioSmallWalkRight(myGame);
        }

        public void BigMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigWalkRight(myGame);
        }

        public void FireMarioCommandCalled()
        {
            
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireDeadRight(myGame);
        }
    }
    public class MarioFireWalkLeft : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 11 + 56;

        public MarioFireWalkLeft(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioFireJumpingLeft(myGame);
        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioFireCrouchingLeft(myGame)
        }

        public void LeftCommandCalled()
        {

        }

        public void RightCommandCalled()
        {
            myGame.marioSprite = new MarioFireIdleLeft(myGame);
        }

        public void SmallMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireWalkLeft(myGame);
        }

        public void BigMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigWalkLeft(myGame);
        }

        public void FireMarioCommandCalled()
        {
            
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireDeadLeft(myGame);
        }
    }
    public class MarioFireJumpingLeft : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 8 + 56;

        public MarioFireJumpingLeft(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {

        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioFireIdleLeft(myGame)
        }

        public void LeftCommandCalled()
        {

        }

        public void RightCommandCalled()
        {

        }

        public void SmallMarioCommandCalled()
        {
            myGame.marioSprite = new MarioSmallJumpingLeft(myGame);
        }

        public void BigMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigJumpingLeft(myGame);
        }

        public void FireMarioCommandCalled()
        {
            
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireDeadLeft(myGame);
        }
    }
    public class MarioFireJumpingRight : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 21 + 56;

        public MarioFireJumpingRight(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {

        }

        public void DownCommandCalled()
        {
            myGame.marioSprite = new MarioFireIdleRight(myGame)
        }

        public void LeftCommandCalled()
        {

        }

        public void RightCommandCalled()
        {

        }

        public void SmallMarioCommandCalled()
        {
            myGame.marioSprite = new MarioSmallJumpingRight(myGame);
        }

        public void BigMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigJumpingRight(myGame);
        }

        public void FireMarioCommandCalled()
        {
           
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireDeadRight(myGame);
        }
    }
    public class MarioFireCrouchingLeft : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 13 + 56;

        public MarioFireCrouchingLeft(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioFireIdleLeft(myGame);
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
            myGame.marioSprite = new MarioSmallCrouchingLeft(myGame);
        }

        public void BigMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigCrouchingLeft(myGame);
        }

        public void FireMarioCommandCalled()
        {
           
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireDeadLeft(myGame);
        }
    }
    public class MarioFireCrouchingRight : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 16 + 56;

        public MarioFireCrouchingRight(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void UpCommandCalled()
        {
            myGame.marioSprite = new MarioFireIdleLeft(myGame);
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
            myGame.marioSprite = new MarioSmallCrouchingRight(myGame);
        }

        public void BigMarioCommandCalled()
        {
            myGame.marioSprite = new MarioBigCrouchingRight(myGame);
        }

        public void FireMarioCommandCalled()
        {
            
        }

        public void DeadMarioCommandCalled()
        {
            myGame.marioSprite = new MarioFireDeadRight(myGame);
        }
    }
    public class MarioFireDeadLeft : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 1 + 56;

        public MarioFireDeadLeft(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

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
    }
    public class MarioFireDeadRight : ISprite
    {
        private Game1 myGame;

        private int currentFrame = 28 + 56;

        public MarioFireDeadRight(Game1 game)
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

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, myGame.marioTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.marioTexture.Height);

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
    }
}