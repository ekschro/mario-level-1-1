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
    public class HiddenGreenMushroomBlockSprite : IBlockSprite
    {
        private IBlock hiddenGreenMushroomBlockObject;
        private Game1 myGame;
        private int currentFrame;
        private BlockUtilityClass utility;

        public HiddenGreenMushroomBlockSprite(Game1 game, IBlock hiddenGreenMushroomBlock)
        {
            utility = new BlockUtilityClass();
            hiddenGreenMushroomBlockObject = (HiddenGreenMushroomBlock)hiddenGreenMushroomBlock;
            myGame = game;
            currentFrame = utility.InitialFrame;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int width = TextureWarehouse.BlockTexture.Width / utility.BlockColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(hiddenGreenMushroomBlockObject.GameObjectLocation.X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, utility.InitialFrame, width, TextureWarehouse.BlockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)hiddenGreenMushroomBlockObject.GameObjectLocation.Y, width, TextureWarehouse.BlockTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.BlockTexture, destinationRectangle, sourceRectangle, Color.Transparent);
            myGame.SpriteBatch.End();
        }

    }
}