using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class BrickBlock : AbstractBlock
    {
        public BrickBlock(Game1 game, Vector2 location) : base(game, location)
        {
            blockSprite = new BrickBlockSprite(game, this);
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, utility.Width, utility.Height);
        }
        public void Bounce()
        {
            ((BrickBlockSprite)blockSprite).Bounce();
        }
    }
}
