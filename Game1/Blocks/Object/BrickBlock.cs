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
        public BrickBlock(Game1 game, Vector2 location) : base(location)
        {
            blockSprite = new BrickBlockSprite(game, this);
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, utility.Width, utility.Height);
        }
        public override void Update()
        {
            blockSprite.Update();
        }
        public void Bounce()
        {
            ((BrickBlockSprite)blockSprite).Bounce();
        }
    }
}
