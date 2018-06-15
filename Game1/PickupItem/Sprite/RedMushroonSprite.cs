﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class RedMushroomSprite : IPickupSprite
    {
        private RedMushroom redMushroomObject;
        private Game1 myGame;
        private int currentFrame;

        public RedMushroomSprite(Game1 game, RedMushroom redMushroom)
        {
            redMushroomObject = redMushroom;
            myGame = game;
            currentFrame = 0;
        }
        public void Update()
        {}

        public void Draw()
        {
            int width = TextureWareHouse.pickupTexture.Width / 15;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.pickupTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)redMushroomObject.GetCurrentLocation().X, (int)redMushroomObject.GetCurrentLocation().Y, width, TextureWareHouse.pickupTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(TextureWareHouse.pickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void Picked()
        {
            currentFrame = 14;
        }
    }
}