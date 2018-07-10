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
    public class BlueStoneBlockSprite : IBlockSprite
    {
        private BlueStoneBlock blueStoneBlockObject;
        private Game1 myGame;
        private int currentFrame;

        public BlueStoneBlockSprite(Game1 game, IBlock blueStoneBlock)
        {
            blueStoneBlockObject = (BlueStoneBlock)blueStoneBlock;
            myGame = game;
            currentFrame = 0;
        }

        public void Update(){}

        public void Draw()
        {
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(blueStoneBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(0,0,(int)blueStoneBlockObject.BlockSize.X,(int)blueStoneBlockObject.BlockSize.Y);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)blueStoneBlockObject.GetGameObjectLocation().Y, (int)blueStoneBlockObject.BlockSize.X, (int)blueStoneBlockObject.BlockSize.Y);

            myGame.SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);
            myGame.SpriteBatch.Draw(TextureWareHouse.blueStoneBlockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}