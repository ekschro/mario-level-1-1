using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class TestBigMarioSprite : ITestMarioSprite
    {
        private TestMario marioObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;

        public TestBigMarioSprite(Game1 game, TestMario Mario)
        {
            marioObject = Mario;
            myGame = game;
            startFrame = 14 + 28; //MarioSmllIdleRight
            endFrame = 2;
            currentFrame = startFrame;
        }
        public void ChangeFrame(int start, int end)
        {
            startFrame = start;
            endFrame = end;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == endFrame)
                currentFrame = startFrame;
        }

        public void Draw()
        {
            int width = TextureWareHouse.marioTexture.Width / 4;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(marioObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.goombaTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)marioObject.GetGameObjectLocation().Y, width, TextureWareHouse.goombaTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.goombaTexture, destinationRectangle, sourceRectangle, Color.Yellow);
            myGame.SpriteBatch.End();
        }

        public void ChangeFrame()
        {
            throw new NotImplementedException();
        }

        public Vector2 GetGameObjectLocation()
        {
            throw new NotImplementedException();
        }
    }
}
