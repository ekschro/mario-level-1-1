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
    public class UsedBlockSprite : IBlockSprite
    {
        private UsedBlock usedBlockObject;
        private Game1 myGame;
        private int currentFrame;
        //private IBlock blockObject;

        public UsedBlockSprite(Game1 game, UsedBlock usedBlock)
        {
            usedBlockObject = usedBlock;
            myGame = game;
            currentFrame = 3;
            //blockObject = block;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)usedBlockObject.GetBlockCurrentLocation().X, (int)usedBlockObject.GetBlockCurrentLocation().Y, width, myGame.blockTexture.Height);


            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.White);
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