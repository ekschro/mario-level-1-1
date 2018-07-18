using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class UsedBlock : AbstractBlock
    {
        public UsedBlock(Game1 game, Vector2 location) : base(game, location)
        {
            blockSprite = new UsedBlockSprite(game, this);
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, utility.Width, utility.Height);
        }
    }
}
