﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class TopRightPipeBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite topRightPipeBlockSprite;
        //private Game1 myGame;
        private Vector2 blockLocation;

        public TopRightPipeBlock(Game1 game, Vector2 location)
        {
            topRightPipeBlockSprite = new TopRightPipeBlockSprite(game, this);
            //myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            topRightPipeBlockSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            topRightPipeBlockSprite.Update();
        }
    }
}
