using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class TopPipeBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite topPipeBlockSprite;
        private Vector2 blockLocation;
        private Rectangle blockRectangle;

        public TopPipeBlock(Game1 game, Vector2 location)
        {
            topPipeBlockSprite = new TopPipeBlockSprite(game, this);
            blockLocation = location;
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, 32, 16);
        }

        public void Draw()
        {
            topPipeBlockSprite.Draw();
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
            topPipeBlockSprite.Update();
        }

    }
}
