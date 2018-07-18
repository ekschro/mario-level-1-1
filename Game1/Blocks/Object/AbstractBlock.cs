using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public abstract class AbstractBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }
        internal IBlockSprite blockSprite;
        internal Vector2 blockLocation;
        internal Vector2 blockSize;
        internal Rectangle blockRectangle;
        internal BlockUtilityClass utility;
        public Vector2 BlockSize { get => blockSize; set => blockSize = value; }
        protected AbstractBlock(Vector2 location, Vector2 size)
        {
            utility = new BlockUtilityClass();
            blockLocation = location;
            blockSize = size;
        }
        protected AbstractBlock(Vector2 location)
        {
            utility = new BlockUtilityClass();
            blockLocation = location;
        }
        
            public Rectangle BlockRectangle()
        {
            return blockRectangle;
        }
        public void Draw()
        {
            blockSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            blockSprite.Update();
        }
    }
}
