using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class BlueStoneBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; } 

        private IBlockSprite blueStoneBlockSprite;
        //private Game1 myGame;
        private Vector2 blockLocation;

        private Vector2 blockSize;
        private Rectangle blockRectangle;

        public Vector2 BlockSize { get => blockSize; set => blockSize = value; }

        public BlueStoneBlock(Game1 game, Vector2 location, Vector2 size)
        {
            blueStoneBlockSprite = new BlueStoneBlockSprite(game, this);
            //myGame = game;
            blockLocation = location;
            blockSize = size;
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 16);
        }

        public void Draw()
        {
            blueStoneBlockSprite.Draw();
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
            stoneBlockSprite.Update();
        }

    }
}
