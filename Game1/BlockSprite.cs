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
        void QuestionToUsed();
        void BrickToEmpty();
        void HiddenToUsed();
        
    }

    public class StairBlockSprite : IBlockSprite
    {
        private Game1 myGame;
        private int currentFrame;
        private Vector2 blockLocation;

        public StairBlockSprite(Game1 game, Vector2 location)
        {
            myGame = game;
            currentFrame = 1;
            blockLocation = location;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int) blockLocation.X, (int) blockLocation.Y, width, myGame.blockTexture.Height);

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
        private Vector2 blockLocation;

        public UsedBlockSprite(Game1 game, Vector2 location)
        {
            myGame = game;
            currentFrame = 3;
            blockLocation = location;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)blockLocation.X, (int)blockLocation.Y, width, myGame.blockTexture.Height);

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
        private Vector2 blockLocation;

        public QuestionBlockSprite(Game1 game, Vector2 location)
        {
            myGame = game;
            startFrame = 4;
            endFrame = 6;
            currentFrame = startFrame;
            blockLocation = location;
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
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)blockLocation.X, (int)blockLocation.Y, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
        public void QuestionToUsed()
        {
            myGame.Block3Sprite = new UsedBlockSprite(myGame, blockLocation);
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
        private Vector2 blockLocation;

        public BrickBlockSprite(Game1 game, Vector2 location)
        {
            myGame = game;
            currentFrame = 2;
            blockLocation = location;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)blockLocation.X, (int)blockLocation.Y, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
        public void QuestionToUsed()
        {

        }
        public void BrickToEmpty()
        {
            myGame.Block4Sprite = new EmptyBlockSprite(myGame, blockLocation);
        }
        public void HiddenToUsed()
        {

        }
    }

    public class StoneBlockSprite : IBlockSprite
    {
        private Game1 myGame;
        private int currentFrame;
        private Vector2 blockLocation;

        public StoneBlockSprite(Game1 game, Vector2 location)
        {
            myGame = game;
            currentFrame = 0;
            blockLocation = location;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)blockLocation.X, (int)blockLocation.Y, width, myGame.blockTexture.Height);

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
        private Vector2 blockLocation;

        public HiddenBlockSprite(Game1 game, Vector2 location)
        {
            myGame = game;
            currentFrame = 0;
            blockLocation = location;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)blockLocation.X, (int)blockLocation.Y, width, myGame.blockTexture.Height);

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
            myGame.Block6Sprite = new UsedBlockSprite(myGame, blockLocation);
        }
    }

    public class EmptyBlockSprite : IBlockSprite
    {
        private Game1 myGame;
        private int currentFrame;
        private Vector2 blockLocation;

        public EmptyBlockSprite(Game1 game, Vector2 location)
        {
            myGame = game;
            currentFrame = 0;
            blockLocation = location;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)blockLocation.X, (int)blockLocation.Y, width, myGame.blockTexture.Height);

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
        private Vector2 blockLocation;

        public TopLeftPipeSprite(Game1 game, Vector2 location)
        {
            myGame = game;
            currentFrame = 8;
            blockLocation = location;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)blockLocation.X, (int)blockLocation.Y, width, myGame.blockTexture.Height);

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
        private Vector2 blockLocation;

        public TopRightPipeSprite(Game1 game, Vector2 location)
        {
            myGame = game;
            currentFrame = 9;
        blockLocation = location;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)blockLocation.X, (int)blockLocation.Y, width, myGame.blockTexture.Height);

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
        private Vector2 blockLocation;

        public BottomLeftPipeSprite(Game1 game, Vector2 location)
        {
            myGame = game;
            currentFrame = 10;
            blockLocation = location;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)blockLocation.X, (int)blockLocation.Y, width, myGame.blockTexture.Height);

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
        private Vector2 blockLocation;

        public BottomRightPipeSprite(Game1 game, Vector2 location)
        {
            myGame = game;
            currentFrame = 11;
            blockLocation = location;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)blockLocation.X, (int)blockLocation.Y, width, myGame.blockTexture.Height);

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