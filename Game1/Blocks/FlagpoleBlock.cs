using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class FlagpoleBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite flagpoleBlockSprite;
        private Vector2 blockLocation;
        public FlagpoleBlock(Game1 game, Vector2 location)
        {
            flagpoleBlockSprite = new FlagpoleBlockSprite(game, this);
            blockLocation = location;
        }

        public void Draw()
        {
            flagpoleBlockSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
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
