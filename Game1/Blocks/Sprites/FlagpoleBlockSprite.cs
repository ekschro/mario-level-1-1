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
    public class FlagpoleBlockSprite : IBlockSprite
    {
        private IBlock flagpoleObject;
        private Game1 myGame;
        private BlockUtilityClass utility;

        public FlagpoleBlockSprite(Game1 game, IBlock flag)
        {
            flagpoleObject = (FlagpoleBlock)flag;
            myGame = game;
            utility = new BlockUtilityClass();
        }

        public void Update()
        {

        }

        public void Draw()
        {
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(flagpoleObject.GameObjectLocation.X);

            Rectangle sourceRectangle = new Rectangle(utility.InitialFrame, utility.InitialFrame, TextureWarehouse.FlagpoleTexture.Width, TextureWarehouse.FlagpoleTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)flagpoleObject.GameObjectLocation.Y, TextureWarehouse.FlagpoleTexture.Width, TextureWarehouse.FlagpoleTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.FlagpoleTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}