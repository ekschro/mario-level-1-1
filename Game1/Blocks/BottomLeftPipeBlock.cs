﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class BottomLeftPipeBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private  IBlockSprite bottomLeftPipeBlockSprite;
        private Vector2 blockLocation;
        private Rectangle blockRectangle;

        public BottomLeftPipeBlock(Game1 game, Vector2 location)
        {
            bottomLeftPipeBlockSprite = new BottomLeftPipeBlockSprite(game, this);
            //myGame = game;
            blockLocation = location;
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 16);
        }

        public void Draw()
        {
            bottomLeftPipeBlockSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return blockLocation;
        }

        public Rectangle BlockRectangle()
        {
            return blockRectangle;
        }

        public void Update()
        {
            bottomLeftPipeBlockSprite.Update();
        }
    }
}
