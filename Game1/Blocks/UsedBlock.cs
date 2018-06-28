using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class UsedBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite usedBlockSprite;
        private Vector2 blockLocation;
        public UsedBlock(Game1 game, Vector2 location)
        {
            usedBlockSprite = new UsedBlockSprite(game, this);
            blockLocation = location;
        }

        public void Draw()
        {
            usedBlockSprite.Draw();
        }

        public Vector2 GameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {

        }

        public void TopCollision() { }
        public void BottomCollision() { }
        public void LeftCollision() { }
        public void RightCollision() { }
    }
}
