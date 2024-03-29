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
    public class CastleBlockSprite : IBlockSprite
    {
        private CastleBlock castleBlockObject;
        private Game1 myGame;
        BlockUtilityClass utility;

        public CastleBlockSprite(Game1 game, IBlock castle)
        {
            castleBlockObject = (CastleBlock)castle;
            myGame = game;
            utility = new BlockUtilityClass();
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(castleBlockObject.GameObjectLocation.X);

            Rectangle sourceRectangle = new Rectangle(utility.InitialFrame, utility.InitialFrame, TextureWarehouse.CastleTexture.Width, TextureWarehouse.CastleTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)castleBlockObject.GameObjectLocation.Y, TextureWarehouse.CastleTexture.Width, TextureWarehouse.CastleTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.CastleTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}