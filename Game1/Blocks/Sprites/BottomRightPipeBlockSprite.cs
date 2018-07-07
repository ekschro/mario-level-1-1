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
    public class BottomRightPipeBlockSprite : IBlockSprite
    {
        private BottomRightPipeBlock bottomRightPipeBlockObject;
        private Game1 myGame;
        private int currentFrame;

        public BottomRightPipeBlockSprite(Game1 game, IBlock bottomRightPipe)
        {
            bottomRightPipeBlockObject = (BottomRightPipeBlock)bottomRightPipe;
            myGame = game;
            currentFrame = 11;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = TextureWarehouse.blockTexture.Width / 13;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(bottomRightPipeBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)bottomRightPipeBlockObject.GetGameObjectLocation().Y, width, TextureWarehouse.blockTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}