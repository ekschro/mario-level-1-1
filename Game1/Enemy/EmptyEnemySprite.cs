using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class EmptySprite : IEnemySprite
    {
        private Empty emptyObject;
        private Game1 myGame;
        private int currentFrame;
        //private int startFrame;
        //private int endFrame;

        public EmptySprite(Game1 game, Empty empty)
        {
            emptyObject = empty;
            myGame = game;
            currentFrame = 4;
        }
        public void ChangeFrame(int start, int end)
        {
            //startFrame = start;
            //endFrame = end;
        }
        public void Update()
        {
        }

        public void Draw()
        {
            int width = TextureWareHouse.goombaTexture.Width / 4;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.goombaTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)emptyObject.GameObjectLocation().X, (int)emptyObject.GameObjectLocation().Y, width, TextureWareHouse.goombaTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(TextureWareHouse.goombaTexture, destinationRectangle, sourceRectangle, Color.Transparent);
            myGame.spriteBatch.End();
        }
    }
}
