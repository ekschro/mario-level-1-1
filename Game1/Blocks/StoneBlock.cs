using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class StoneBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; } 

        private IBlockSprite stoneBlockSprite;
        //private Game1 myGame;
        private Vector2 blockLocation;

        private Vector2 blockSize;
        public Vector2 BlockSize { get => blockSize; set => blockSize = value; }

        public StoneBlock(Game1 game, Vector2 location, Vector2 size)
        {
            stoneBlockSprite = new StoneBlockSprite(game, this);
            //myGame = game;
            blockLocation = location;
            blockSize = size;
        }

        public void Draw()
        {
            stoneBlockSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            stoneBlockSprite.Update();
        }

    }
}
