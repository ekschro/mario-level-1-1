using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class BlueBrickBlock : AbstractBlock
    {
        public BlueBrickBlock(Game1 game, Vector2 location, Vector2 size) : base(location, size)
        {
            blockSprite = new BlueBrickBlockSprite(game, this);
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y);
        }

        public override void Update()
        {
            blockSprite.Update();
        }
    }
}
