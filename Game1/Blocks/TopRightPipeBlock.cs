using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class TopRightPipeBlock : IBlock
    {

        private IBlockSprite topRightPipeBlockSprite;
        private Game1 myGame;
        private Vector2 blockLocation;

        public TopRightPipeBlock(Game1 game, Vector2 location)
        {
            topRightPipeBlockSprite = new TopRightPipeBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            topRightPipeBlockSprite.Draw();
        }

        public Vector2 GameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            topRightPipeBlockSprite.Update();
        }

        public void TopCollision() { }

        public void BottomCollision()
        {
        }

        public void LeftCollision() { }
        public void RightCollision() { }
    }
}
