using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class TopWarpPipeBlock : AbstractBlock
    {
        public TopWarpPipeBlock(Game1 game, Vector2 location) : base(location)
        {
            blockSprite = new TopWarpPipeBlockSprite(game, this);
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, utility.PipeHeight, utility.Height);
        }
    }
}
