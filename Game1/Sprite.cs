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
        void UpCommandCalled();
        void DownCommandCalled();
        void LeftCommandCalled();
        void RightCommandCalled();
        void SmallMarioCommandCalled();
        void BigMarioCommandCalled();
        void FireMarioCommandCalled();
        void DeadMarioCommandCalled();
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

}