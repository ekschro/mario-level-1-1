using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class TestMarioSprite : ITestMarioSprite
    {
        private TestSmallMario marioObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;

        public TestMarioSprite(Game1 game, TestSmallMario Mario)
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
            int width = TextureWarehouse.marioTexture.Width / 28;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(marioObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.goombaTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)marioObject.GetGameObjectLocation().Y, width, TextureWarehouse.goombaTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.goombaTexture, destinationRectangle, sourceRectangle, Color.Yellow);
            myGame.SpriteBatch.End();
        }



        public Vector2 GetGameObjectLocation()
        {
            throw new NotImplementedException();
        }
    }
}
