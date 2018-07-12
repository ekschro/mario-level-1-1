using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class TopWarpPipeBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite topWarpPipeBlockSprite;
        private Vector2 blockLocation;
        private Rectangle blockRectangle;

        public TopWarpPipeBlock(Game1 game, Vector2 location)
        {
            topWarpPipeBlockSprite = new TopWarpPipeBlockSprite(game, this);
            blockLocation = location;
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, 32, 16);
        }

        public void Draw()
        {
            topWarpPipeBlockSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return blockLocation;
        }

        public Rectangle BlockRectangle()
        {
            return blockRectangle;
        }

        public void Update()
        {
            topWarpPipeBlockSprite.Update();
        }

    }
}
