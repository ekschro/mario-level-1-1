﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class QuestionBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite questionBlockSprite;
        private Vector2 blockLocation;
        private int cyclePosition = 0;
        private int cycleLength = 8;

        public QuestionBlock(Game1 game, Vector2 location)
        {
            questionBlockSprite = new QuestionBlockSprite(game, this);
            blockLocation = location;
        }

        public void Draw()
        {
            questionBlockSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                questionBlockSprite.Update();
                cyclePosition = 0;
                blockLocation.Y -= 1;
            }
        }
    }
}
