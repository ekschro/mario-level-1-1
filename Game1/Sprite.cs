using System;

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
        void Update();
        void Draw();
    }

    public class NonMovingNonAnimated : ISprite
    {
        private Game1 myGame;

        public NonMovingNonAnimated(Game1 game)
        {
            myGame = game;
        }

        public void Update() { }

        public void Draw()
        {
            int width = myGame.Texture.Width / myGame.totalFrames;

            myGame.currentLocation.Y = myGame.startingLocation.Y;
            myGame.currentLocation.X = myGame.startingLocation.X;

            Rectangle sourceRectangle = new Rectangle(width * 4, 0, width, myGame.Texture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.Texture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.Texture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }

    public class NonMovingAnimated : ISprite
    {
        private Game1 myGame;
        private int currentFrame;
        private int cyclePosition = 0;
        private int cycleLength = 16;
        private int startFrame;
        private int endFrame;

        public NonMovingAnimated(Game1 game)
        {
            myGame = game;
            startFrame = 6;
            endFrame = 7;
            currentFrame = startFrame;
        }

        public void Update()
        {
            cyclePosition = cyclePosition + 1;
            if (cyclePosition < .5 * cycleLength)
                currentFrame = startFrame;
            else 
                currentFrame = startFrame + 1;

            if (cyclePosition == cycleLength)
                cyclePosition = 0;
        }

        public void Draw()
        {
            int width = myGame.Texture.Width / myGame.totalFrames;

            myGame.currentLocation.Y = myGame.startingLocation.Y;
            myGame.currentLocation.X = myGame.startingLocation.X;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.Texture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.startingLocation.X, (int)myGame.startingLocation.Y, width, myGame.Texture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.Texture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }

    public class MovingNonAnimated : ISprite
    {
        private Game1 myGame;

        public MovingNonAnimated(Game1 game)
        {
            myGame = game;
        }

        public void Update()
        {
            myGame.currentLocation.Y = myGame.currentLocation.Y + 2;
            if (myGame.currentLocation.Y > 600)
                myGame.currentLocation.Y = -100;
        }

        public void Draw()
        {
            int width = myGame.Texture.Width / myGame.totalFrames;

            myGame.currentLocation.X = myGame.startingLocation.X;

            Rectangle sourceRectangle = new Rectangle(width * 5, 0, width, myGame.Texture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.currentLocation.X, (int)myGame.currentLocation.Y, width, myGame.Texture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.Texture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }

    public class MovingAnimated : ISprite
    {
        private Game1 myGame;
        private int currentFrame;
        private int cyclePosition = 0;
        private int cycleLength = 32;
        private int startFrame;
        private int endFrame;

        public MovingAnimated(Game1 game)
        {
            myGame = game;
            startFrame = 0;
            endFrame = 3;
            currentFrame = startFrame;
        }

        public void Update()
        {
            cyclePosition = cyclePosition + 1;
            if (cyclePosition < .25 * cycleLength)
                currentFrame = startFrame;
            else if (cyclePosition < .5 * cycleLength)
                currentFrame = startFrame + 1;
            else if (cyclePosition < .75 * cycleLength)
                currentFrame = startFrame + 2;
            else
                currentFrame = startFrame + 3;

            if (cyclePosition == cycleLength)
                cyclePosition = 0;

            myGame.currentLocation.X = myGame.currentLocation.X - 3;
            if (myGame.currentLocation.X < -10)
                myGame.currentLocation.X = 1000;
        }

        public void Draw()
        {
            int width = myGame.Texture.Width / myGame.totalFrames;

            myGame.currentLocation.Y = myGame.startingLocation.Y;

            Rectangle sourceRectangle = new Rectangle(width * (int)currentFrame, 0, width, myGame.Texture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.currentLocation.X, (int)myGame.currentLocation.Y, width, myGame.Texture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.Texture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }

}