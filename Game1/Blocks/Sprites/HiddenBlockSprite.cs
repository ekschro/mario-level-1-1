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

        public HiddenBlockSprite(Game1 game, HiddenBlock hiddenBlock)
        {
            hiddenBlockObject = hiddenBlock;
            myGame = game;
            currentFrame = 0;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.blockTexture.Width / 13;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)hiddenBlockObject.GetBlockCurrentLocation().X, (int)hiddenBlockObject.GetBlockCurrentLocation().Y, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.Transparent);
            myGame.spriteBatch.End();
        }

        public void ToEmpty()
        {

        }
        public void ToUsed()
        {
             //= new UsedBlockSprite(myGame, new Block(myGame, blockObject.BlockLocation()));
        }
    }
}