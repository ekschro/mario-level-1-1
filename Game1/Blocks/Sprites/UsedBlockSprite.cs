﻿using System;

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

        public UsedBlockSprite(Game1 game, IBlock usedBlock)
        {
            usedBlockObject = (UsedBlock)usedBlock;
            myGame = game;
            currentFrame = 3;
            //blockObject = block;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = TextureWareHouse.blockTexture.Width / 13;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)usedBlockObject.GameObjectLocation().X, (int)usedBlockObject.GameObjectLocation().Y, width, TextureWareHouse.blockTexture.Height);


            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(TextureWareHouse.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }
}