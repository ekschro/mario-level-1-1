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
        private Koopa koopaObject;
        private Game1 myGame;
        private int currentFrame;
        private bool goingLeft = true;
        private int startFrame;
        private int endFrame;
        private int leftStartFrame;
        private int leftEndFrame;
        public KoopaSprite(Game1 game, Koopa koopa)
        {
            koopaObject = koopa;
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
                if (koopaObject.GameObjectLocation().X == 480)
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
                if (koopaObject.GameObjectLocation().X == 420)
                    goingLeft = true;
                currentFrame++;
                if (currentFrame == leftEndFrame)
                    currentFrame = leftStartFrame;
            }

        }

        public void Draw()
        {
            int width = TextureWareHouse.koopaTexture.Width / 6;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.koopaTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)koopaObject.GameObjectLocation().X, (int)koopaObject.GameObjectLocation().Y, width, TextureWareHouse.koopaTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(TextureWareHouse.koopaTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }
}
