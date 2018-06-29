﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class BottomRightPipeBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite bottomRightPipeBlockSprite;

        
        //private Game1 myGame;
        private Vector2 blockLocation;

        public BottomRightPipeBlock(Game1 game, Vector2 location)
        {
            bottomRightPipeBlockSprite = new BottomRightPipeBlockSprite(game, this);
            //myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            bottomRightPipeBlockSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            bottomRightPipeBlockSprite.Update();
        }

    }
}
