using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class CastleBlock : AbstractBlock
    {
        public CastleBlock(Game1 game, Vector2 location) : base(game, location)
        {
            blockSprite = new CastleBlockSprite(game, this);
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, utility.Width, utility.Height);
        }
    }
}
