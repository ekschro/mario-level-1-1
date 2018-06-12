using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class GoombaSprite : IEnemySprite
    { 
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;

        public GoombaSprite(Game1 game)
        {
            myGame = game;
            startFrame = 0;
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
            int width = myGame.goombaTexture.Width / 4;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.goombaTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.goomba.GetCurrentXLocation().X, (int)myGame.goomba.GetCurrentXLocation().Y, width, myGame.goombaTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.goombaTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }
}
