using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class TestSmallMarioSprite :ITestMarioSprite
    {
        private TestSmallMario marioObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;
        private IPlayer player;
        //private MarioSpriteUtility spriteUtility;

        public TestSmallMarioSprite(Game1 game, TestSmallMario Mario, IPlayer player)
        {
            //spriteUtility = new MarioSpriteUtility();
            marioObject = Mario;
            myGame = game;
            currentFrame = startFrame;
            this.player = player;
            //startFrame = 41;
            //endFrame = 42;
            //startFrame = spriteUtility.SmallMarioRightIdleStart;
            //endFrame = spriteUtility.SmallMarioRightIdleEnd;
        }
        public void ChangeFrame(int start, int end)
        {
            if (!(start == startFrame && end == endFrame))
            {
                currentFrame = start;
            }
            startFrame = start;
            endFrame = end;
        }

        public void Update()
        {
            if (marioObject.GetStateMachine.FacingLeft())
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
            int width = TextureWarehouse.marioTexture.Width / player.TotalMarioColumns;
            int height = TextureWarehouse.marioTexture.Height / player.TotalMarioRows;
            int row = (int)((float)currentFrame / (float)player.TotalMarioColumns);
            int column = currentFrame % player.TotalMarioColumns;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(player.CurrentXPos);

            Rectangle sourceRectangle = new Rectangle(width * column, (height * row), width, height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)player.CurrentYPos, width, height);


            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.marioTexture, destinationRectangle, sourceRectangle, player.MarioColor);
            myGame.SpriteBatch.End();
        }
    }
}
