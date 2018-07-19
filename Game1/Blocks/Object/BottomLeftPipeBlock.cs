using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class BottomLeftPipeBlock : AbstractBlock
    {
        public BottomLeftPipeBlock(Game1 game, Vector2 location) : base(location)
        {
            blockSprite = new BottomLeftPipeBlockSprite(game, this);
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, utility.Width, utility.Height);
        }
    }
}
