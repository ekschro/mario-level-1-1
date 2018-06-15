﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class GreenMushroomSprite : IPickupSprite
    {
        private GreenMushroom greenMushroomOject;
        private Game1 myGame;
        private int currentFrame;

        public GreenMushroomSprite(Game1 game, GreenMushroom greenMushroom)
        {
            greenMushroomOject = greenMushroom;
            myGame = game;
            currentFrame = 1;
        }

        public void Update()
        {
        }

        public void Draw()
        {
            int width = TextureWareHouse.pickupTexture.Width / 15;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.pickupTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)greenMushroomOject.GetCurrentLocation().X, (int)greenMushroomOject.GetCurrentLocation().Y, width, TextureWareHouse.pickupTexture.Height);

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