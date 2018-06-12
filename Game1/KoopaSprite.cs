using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class KoopaSprite : IEnemySprite
    {
       
        private Game1 myGame;
        private int currentFrame;
        private bool goingLeft = true;
        private int startFrame;
        private int endFrame;
        private int leftStartFrame;
        private int leftEndFrame;
        public KoopaSprite(Game1 game)
        {
            
            myGame = game;
            startFrame = 2;
            endFrame = 4;
            leftStartFrame = 0;
            leftEndFrame = 2;
            currentFrame = startFrame;
        }

        public void BeStomped()
        {
            startFrame = leftStartFrame = 4;
            endFrame = leftEndFrame = 6;
            startFrame = leftStartFrame = 5;
            endFrame = leftEndFrame = 6;
        }

        public void ChangeFrame(int start, int end)
        {
            startFrame = start;
            leftStartFrame = start;
            endFrame = end;
            leftEndFrame = end;
        }

        public void Update()
        {
            if (goingLeft == true)
            {
                if (myGame.koopa.GetCurrentXLocation().X == 420)
                {
                    goingLeft = false;
                    currentFrame = leftStartFrame;
                }
                currentFrame++;
                if (currentFrame == endFrame)
                    currentFrame = startFrame;
            }
            else if (goingLeft == false)
            {
                if (myGame.koopa.GetCurrentXLocation().X == 380)
                    goingLeft = true;
                currentFrame++;
                if (currentFrame == leftEndFrame)
                    currentFrame = leftStartFrame;
            }

        }

        public void Draw()
        {
            int width = myGame.koopaTexture.Width / 6;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.koopaTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)myGame.koopa.GetCurrentXLocation().X, (int)myGame.koopa.GetCurrentXLocation().Y, width, myGame.koopaTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.koopaTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }
}
