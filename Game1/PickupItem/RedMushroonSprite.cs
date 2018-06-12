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
        private Pickup pickupObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;

        public RedMushroomSprite(Game1 game, Pickup pickup)
        {
            pickupObject = pickup;
            myGame = game;
            startFrame = 0;
            endFrame = 1;
            currentFrame = startFrame;
        }
        public void Update()
        {
            currentFrame++;
            if (currentFrame == endFrame)
                currentFrame = startFrame;
        }

        public void Draw()
        {
            int width = myGame.pickupTexture.Width / myGame.totalPickupFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.pickupTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)200, (int)100, width, myGame.pickupTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.pickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }

        public void picked()
        {
            startFrame = 14;
            endFrame = 15;
        }
    }
}