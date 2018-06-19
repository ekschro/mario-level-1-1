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
        private int startFrame;
        private int endFrame;
        public KoopaSprite(Game1 game, Koopa koopa)
        {
            koopaObject = koopa;
            myGame = game;
            startFrame = 2;
            endFrame = 4;
            currentFrame = startFrame;
        }
        public void ChangeFrame(int start, int end)
        {
            startFrame = start;
            endFrame = end;
            currentFrame = startFrame;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == endFrame)
                currentFrame = startFrame;
        }

        public void Draw()
        {
            int width = TextureWareHouse.koopaTexture.Width / 6;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.koopaTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)koopaObject.GameObjectLocation().X, (int)koopaObject.GameObjectLocation().Y, width, TextureWareHouse.koopaTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.koopaTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}
