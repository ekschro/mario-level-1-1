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
    public class StairBlockSprite : IBlockSprite
    {
        private StairBlock stairBlockObject;
        private Game1 myGame;
        private int currentFrame;

        public StairBlockSprite(Game1 game, IBlock stairBlock)
        {
            stairBlockObject = (StairBlock)stairBlock;
            myGame = game;
            currentFrame = 1;
            //blockLocation = location;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = TextureWareHouse.blockTexture.Width / 13;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(stairBlockObject.GameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)stairBlockObject.GameObjectLocation().Y, width, TextureWareHouse.blockTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}