using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public abstract class AbstractTestMarioSprite : ITestMarioSprite
    {
        private ITestMario marioObject;
        private Game1 myGame;
        internal int currentFrame;
        internal int startFrame;
        private int endFrame;
        internal IPlayer player;

        public AbstractTestMarioSprite(Game1 game, ITestMario Mario, IPlayer player)
        {
            marioObject = Mario;
            myGame = game;
            currentFrame = startFrame;
            this.player = player;
        }
        public void ChangeFrame(int start, int end)
        {
            if (!(start == startFrame && end == endFrame))
                currentFrame = start;
            startFrame = start;
            endFrame = end;
        }

        public void Update()
        {
            if (marioObject.StateMachine.FacingLeft())
            {
                currentFrame--;
                if (currentFrame == endFrame)
                    currentFrame = startFrame;
            }
            else
            {
                currentFrame++;
                if (currentFrame == endFrame)
                    currentFrame = startFrame;
            }
        }

        public void Draw()
        {
            Draw(0, 0);
        }

        public void Draw(int xOffset, int yOffset)
        {
            int width = TextureWarehouse.MarioTexture.Width / player.TotalMarioColumns;
            int height = TextureWarehouse.MarioTexture.Height / player.TotalMarioRows;
            int row = (int)((float)currentFrame / (float)player.TotalMarioColumns);
            int column = currentFrame % player.TotalMarioColumns;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(player.CurrentXPos);

            Rectangle sourceRectangle = new Rectangle(width * column, (height * row), width, height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX + xOffset, (int)player.CurrentYPos + yOffset, width, height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.MarioTexture, destinationRectangle, sourceRectangle, player.MarioColor);
            myGame.SpriteBatch.End();
        }
    }
}
