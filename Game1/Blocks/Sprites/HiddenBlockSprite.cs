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
    public class HiddenBlockSprite : IBlockSprite
    {
        private HiddenBlock hiddenBlockObject;
        private Game1 myGame;
        private int currentFrame;
        private IBlock blockObject;

        public HiddenBlockSprite(Game1 game, IBlock hiddenBlock)
        {
            hiddenBlockObject = (HiddenBlock)hiddenBlock;
            myGame = game;
            currentFrame = 0;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = TextureWareHouse.blockTexture.Width / 13;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)hiddenBlockObject.GameObjectLocation().X, (int)hiddenBlockObject.GameObjectLocation().Y, width, TextureWareHouse.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(TextureWareHouse.blockTexture, destinationRectangle, sourceRectangle, Color.Transparent);
            myGame.spriteBatch.End();
        }

    }
}