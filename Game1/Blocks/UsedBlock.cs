using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class UsedBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite usedBlockSprite;
        private Vector2 blockLocation;
        private Rectangle blockRectangle;
        private BlockUtilityClass utility;
        public UsedBlock(Game1 game, Vector2 location)
        {
            utility = new BlockUtilityClass();
            usedBlockSprite = new UsedBlockSprite(game, this);
            blockLocation = location;
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, utility.Width, utility.Height);
        }

        public void Draw()
        {
            usedBlockSprite.Draw();
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
        }
    }
}
