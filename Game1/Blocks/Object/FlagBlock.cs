using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class FlagBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite flagBlockSprite;
        private Vector2 blockLocation;
        private Rectangle blockRectangle;
        private BlockUtilityClass utility;

        private bool pulled;
        private int pullDistance;
            
        public FlagBlock(Game1 game, Vector2 location)
        {
            flagBlockSprite = new FlagBlockSprite(game, this);
            blockLocation = location;
            utility = new BlockUtilityClass();
            blockRectangle = new Rectangle((int)location.X + 16, (int)location.Y, utility.Width, utility.Height);
            pulled = false;
        }

        public void Draw()
        {
            if (pulled && pullDistance > 0)
            {
                blockLocation.Y++;
                pullDistance--;
            }
            flagBlockSprite.Draw();
        }

        public Vector2 GameObjectLocation => blockLocation;

        public Rectangle BlockRectangle()
        {
            return blockRectangle;
        }

        public void Update()
        {
        }

        public void Activate(int distance)
        {
            if (!pulled)
            {
                pulled = true;
                pullDistance = distance;
            }
        }

    }
}
