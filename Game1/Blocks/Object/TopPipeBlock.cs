using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class TopPipeBlock : AbstractBlock
    {
        public TopPipeBlock(Game1 game, Vector2 location) : base(game, location)
        {
            blockSprite = new TopPipeBlockSprite(game, this);
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, utility.PipeHeight, utility.Height);
        }
    }
}
