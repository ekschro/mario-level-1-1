﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class UsedBlock : IBlock
    {

        private static IBlockSprite usedBlockSprite;

        public static IBlockSprite UsedBlockSprite { get => usedBlockSprite; set => usedBlockSprite = value; }

        private Game1 myGame;
        public Vector2 blockLocation;

        public UsedBlock(Game1 game, Vector2 location)
        {
            UsedBlockSprite = new UsedBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            UsedBlockSprite.Draw();
        }

        public Vector2 GetBlockCurrentLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            UsedBlockSprite.Update();
        }

        public void ToEmpty()
        {
            throw new NotImplementedException();
        }

        public void ToUsed()
        {
            throw new NotImplementedException();
        }
    }
}