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
        void Draw(Vector2 location);
        void QuestionToUsed();
        void BrickToEmpty();
        void HiddenToUsed();
        
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

        public void Draw(Vector2 location)
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int) location.X, (int) location.Y, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
        public void QuestionToUsed()
        {

        }
        public void BrickToEmpty()
        {

        }
        public void HiddenToUsed()
        {

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

        public void Draw(Vector2 location)
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
        public void QuestionToUsed()
        {

        }
        public void BrickToEmpty()
        {

        }
        public void HiddenToUsed()
        {

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

        public void Draw(Vector2 location)
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
        public void QuestionToUsed()
        {
            myGame.Block3Sprite = new UsedBlockSprite(myGame);
        }
        public void BrickToEmpty()
        {

        }
        public void HiddenToUsed()
        {

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

        public void Draw(Vector2 location)
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
        public void QuestionToUsed()
        {

        }
        public void BrickToEmpty()
        {
            myGame.Block4Sprite = new EmptyBlockSprite(myGame);
        }
        public void HiddenToUsed()
        {

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

        public void Draw(Vector2 location)
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
        public void QuestionToUsed()
        {

        }
        public void BrickToEmpty()
        {

        }
        public void HiddenToUsed()
        {

        }
    }
    
    public class HiddenBlockSprite : IBlockSprite
    {
        private Game1 myGame;
        private int currentFrame;

        public HiddenBlockSprite(Game1 game)
        {
            myGame = game;
            currentFrame = 0;
        }

        public void Update()
        {

        }

        public void Draw(Vector2 location)
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.Transparent);
            myGame.spriteBatch.End();
        }
        public void QuestionToUsed()
        {

        }
        public void BrickToEmpty()
        {

        }
        public void HiddenToUsed()
        {
            myGame.Block6Sprite = new UsedBlockSprite(myGame);
        }
    }

    public class EmptyBlockSprite : IBlockSprite
    {
        private Game1 myGame;
        private int currentFrame;

        public EmptyBlockSprite(Game1 game)
        {
            myGame = game;
            currentFrame = 0;
        }

        public void Update()
        {

        }

        public void Draw(Vector2 location)
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.Transparent);
            myGame.spriteBatch.End();
        }
        public void QuestionToUsed()
        {

        }
        public void BrickToEmpty()
        {

        }
        public void HiddenToUsed()
        {

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

        public void Draw(Vector2 location)
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
        public void QuestionToUsed()
        {

        }
        public void BrickToEmpty()
        {

        }
        public void HiddenToUsed()
        {

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

        public void Draw(Vector2 location)
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
        public void QuestionToUsed()
        {

        }
        public void BrickToEmpty()
        {

        }
        public void HiddenToUsed()
        {

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

        public void Draw(Vector2 location)
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
        public void QuestionToUsed()
        {

        }
        public void BrickToEmpty()
        {

        }
        public void HiddenToUsed()
        {

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

        public void Draw(Vector2 location)
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
        public void QuestionToUsed()
        {

        }
        public void BrickToEmpty()
        {

        }
        public void HiddenToUsed()
        {

        }
    }

    public class UpdateBlock
    {

    }

    public class DrawBlock
    {

    }


}