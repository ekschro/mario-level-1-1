﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class PipeOnSideBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite pipeOnSideBlockSprite;
        //private Game1 myGame;
        private Vector2 blockLocation;
        private Rectangle blockRectangle;

        public PipeOnSideBlock(Game1 game, Vector2 location)
        {
            pipeOnSideBlockSprite = new PipeOnSideBlockSprite(game, this);
            //myGame = game;
            blockLocation = location;
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, 48, 32);
        }

        public void Draw()
        {
            pipeOnSideBlockSprite.Draw();
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
            pipeOnSideBlockSprite.Update();
        }

    }
}