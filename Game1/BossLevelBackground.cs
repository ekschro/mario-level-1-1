﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class BossLevelBackground : IBackground
    {
        private Game1 myGame;
        private Vector2 backgroundLocation;

        public BossLevelBackground(Game1 game, Vector2 location)
        {
            myGame = game;
            backgroundLocation = location;
        }

        public float CurrentXPos { get => backgroundLocation.X; set => backgroundLocation.X = value; }
        public float CurrentYPos { get => backgroundLocation.Y; set => backgroundLocation.Y = value; }

        public void Draw()
        {
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(CurrentXPos);

            Rectangle sourceRectangle = new Rectangle(0, 0, TextureWarehouse.BossLevelBackgroundTexture.Width, TextureWarehouse.BossLevelBackgroundTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)GameObjectLocation.Y, 2248, TextureWarehouse.BossLevelBackgroundTexture.Height);

            myGame.SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);
            myGame.SpriteBatch.Draw(TextureWarehouse.BossLevelBackgroundTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }

        public Vector2 GameObjectLocation => backgroundLocation;

        public void Update()
        {
            
        }
    }
}
