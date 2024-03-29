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
    public class FlagBlockSprite : IBlockSprite
    {
        private IBlock flagObject;
        private Game1 myGame;
        private BlockUtilityClass utility;
        public FlagBlockSprite(Game1 game, IBlock flag)
        {
            flagObject = (FlagBlock)flag;
            myGame = game;
            utility = new BlockUtilityClass();
        }

        public void Update()
        {

        }

        public void Draw()
        {

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(flagObject.GameObjectLocation.X);

            Rectangle sourceRectangle = new Rectangle(utility.InitialFrame, utility.InitialFrame, TextureWarehouse.FlagTexture.Width, TextureWarehouse.FlagTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)flagObject.GameObjectLocation.Y, TextureWarehouse.FlagTexture.Width, TextureWarehouse.FlagTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.FlagTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}