using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public interface IBlockSprite
    {
        void Update();
        void Draw();
    }

    public class StairBlockSprite : IBlockSprite
    {
        private Game1 myGame;
        private int currentFrame;

        public StairBlockSprite(Game1 game)
        {
            myGame = game;
            currentFrame = 1;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.PickupTexture.Width / myGame.totalPickupFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)100, (int)100, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.PickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }

    public class UsedBlockSprite : IBlockSprite
    {
        private Game1 myGame;
        private int currentFrame;

        public UsedBlockSprite(Game1 game)
        {
            myGame = game;
            currentFrame = 3;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.PickupTexture.Width / myGame.totalPickupFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)100, (int)100, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.PickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }

    public class QuestionBlockSprite : IBlockSprite
    {
        private Game1 myGame;
        private int currentFrame;
        private int cyclePosition = 0;
        private int cycleLength = 32;
        private int startFrame;
        private int endFrame;

        public QuestionBlockSprite(Game1 game)
        {
            myGame = game;
            startFrame = 4;
            endFrame = 6;
            currentFrame = startFrame;
        }

        public void Update()
        {
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                cyclePosition = 0;
                currentFrame++;
                if (currentFrame == endFrame)
                    currentFrame = startFrame;
            }
        }

        public void Draw()
        {
            int width = myGame.PickupTexture.Width / myGame.totalPickupFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)100, (int)100, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.PickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }

    public class BrickBlockSprite : IBlockSprite
    {
        private Game1 myGame;
        private int currentFrame;

        public BrickBlockSprite(Game1 game)
        {
            myGame = game;
            currentFrame = 2;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.PickupTexture.Width / myGame.totalPickupFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)100, (int)100, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.PickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }

    public class StoneBlockSprite : IBlockSprite
    {
        private Game1 myGame;
        private int currentFrame;

        public StoneBlockSprite(Game1 game)
        {
            myGame = game;
            currentFrame = 0;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.PickupTexture.Width / myGame.totalPickupFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)100, (int)100, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.PickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }

    public class TopLeftPipeSprite : IBlockSprite
    {
        private Game1 myGame;
        private int currentFrame;

        public TopLeftPipeSprite(Game1 game)
        {
            myGame = game;
            currentFrame = 8;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.PickupTexture.Width / myGame.totalPickupFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)100, (int)100, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.PickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }

    public class TopRightPipeSprite : IBlockSprite
    {
        private Game1 myGame;
        private int currentFrame;

        public TopRightPipeSprite(Game1 game)
        {
            myGame = game;
            currentFrame = 9;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.PickupTexture.Width / myGame.totalPickupFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)100, (int)100, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.PickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }

    public class BottomLeftPipeSprite : IBlockSprite
    {
        private Game1 myGame;
        private int currentFrame;

        public BottomLeftPipeSprite(Game1 game)
        {
            myGame = game;
            currentFrame = 10;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.PickupTexture.Width / myGame.totalPickupFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)100, (int)100, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.PickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }

    public class BottomRightPipeSprite : IBlockSprite
    {
        private Game1 myGame;
        private int currentFrame;

        public BottomRightPipeSprite(Game1 game)
        {
            myGame = game;
            currentFrame = 11;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.PickupTexture.Width / myGame.totalPickupFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)100, (int)100, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.PickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }

    public class UpdateBlock
    {

    }

    public class DrawBlock
    {

    }


}