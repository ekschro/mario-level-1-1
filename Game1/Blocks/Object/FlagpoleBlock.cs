using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class FlagpoleBlock : AbstractBlock
    {
        public FlagpoleBlock(Game1 game, Vector2 location) : base(game, location)
        {
            blockSprite = new FlagpoleBlockSprite(game, this);
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, TextureWarehouse.flagpoleTexture.Width, TextureWarehouse.flagpoleTexture.Height);
        }
    }
}
