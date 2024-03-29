﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class CoinSprite : ITemporarySprite
    {
        private Coin coinObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;
        
        private PickupUtilityClass utility;

        public CoinSprite(Game1 game, Coin coin)
        {
            utility = new PickupUtilityClass();
            coinObject = coin;
            myGame = game;
            //startFrame = 10;
            //endFrame = 14;
            startFrame = utility.CoinStartFrame;
            endFrame = utility.CoinEndFrame;
            currentFrame = startFrame;
        }
        public void ChangeFrame(int start, int end)
        {
            startFrame = start;
            endFrame = end;
        }

        public void Update()
        {
            utility.PickpupCyclePosition++;
            if (utility.PickpupCyclePosition == utility.PickpupCycleLength)
            {
                utility.PickpupCyclePosition = 0;
                currentFrame++;
                if (currentFrame == endFrame)
                    currentFrame = startFrame;
            }
        }

        public void Draw()
        {
            int width = TextureWarehouse.PickupTexture.Width / utility.PickupColumn;
            
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(coinObject.GameObjectLocation.X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.PickupTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)coinObject.GameObjectLocation.Y, width, TextureWarehouse.PickupTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.PickupTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }

    }
}
