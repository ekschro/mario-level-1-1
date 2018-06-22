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

        private IBlockSprite usedBlockSprite;
        private Vector2 blockLocation;
        private Vector2 blockOriginalLocation;
        private bool up = true;
        private bool endofJumping = false;
        public UsedBlock(Game1 game, Vector2 location)//Boolean isJumping)
        {
            usedBlockSprite = new UsedBlockSprite(game, this);
            blockLocation = location;
            blockOriginalLocation = location;
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
            if (endofJumping==false)
            {
                if (blockLocation.Y == (blockOriginalLocation.Y - 20))
                { up = false; }
                if (up == true)
                { blockLocation.Y -= 2; }
                else if (blockLocation.Y != blockOriginalLocation.Y)
                { blockLocation.Y += 2; }
            }
        }

        public void TopCollision() { }
        public void BottomCollision() { }
        public void LeftCollision() { }
        public void RightCollision() { }
    }
}
