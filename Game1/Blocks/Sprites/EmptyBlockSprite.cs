using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Game1
{
    public class EmptyBlockSprite : IBlockSprite
    {
        private EmptyBlock emptyBlockObject;
        private Game1 myGame;
        private int currentFrame;
        //private Vector2 blockLocation;

        public EmptyBlockSprite(Game1 game, EmptyBlock emptyBlock)
        {
            emptyBlockObject = emptyBlock;
            myGame = game;
            currentFrame = 12;
            //blockLocation = location;
        }

        public void Update()
        {
        }

        public void Draw()
        {
            int width = TextureWareHouse.blockTexture.Width / 13;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)emptyBlockObject.GetBlockCurrentLocation().X, (int)emptyBlockObject.GetBlockCurrentLocation().Y, width, TextureWareHouse.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(TextureWareHouse.blockTexture, destinationRectangle, sourceRectangle, Color.Transparent);
            myGame.spriteBatch.End();
        }
        public void ToEmpty()
        {

        }
        public void ToUsed()
        {
        }
    }

}