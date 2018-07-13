/*
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
            int width = TextureWarehouse.goombaTexture.Width / 4;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.goombaTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)emptyObject.GetGameObjectLocation().X, (int)emptyObject.GetGameObjectLocation().Y, width, TextureWarehouse.goombaTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.goombaTexture, destinationRectangle, sourceRectangle, Color.Transparent);
            myGame.SpriteBatch.End();
        }

        public void FlipSprite()
        {
            throw new NotImplementedException();
        }
    }
}
*/