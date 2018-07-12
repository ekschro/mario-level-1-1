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

        public TestSmallMarioSprite(Game1 game, TestSmallMario Mario)
        {
            marioObject = Mario;
            myGame = game;
            startFrame = 14+28; //MarioSmllIdleRight
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
            if (marioObject.GetStateMachine.FacingLeft())
            {
                currentFrame--;

            }
            else
            {
                currentFrame++;
            }
            if (currentFrame == endFrame)
                currentFrame = startFrame;
        }

    
        public void Draw()
        {

            int width = TextureWarehouse.marioTexture.Width / 28;
            int height = TextureWarehouse.marioTexture.Height / 6;
            int row = currentFrame / 28;
            int column = currentFrame % 28;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(marioObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * column, 32, width, height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)(marioObject.GetGameObjectLocation().Y), width, height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.marioTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }

        

        public Vector2 GetGameObjectLocation()
        {
            throw new NotImplementedException();
        }
    }
}
