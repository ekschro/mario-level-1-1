using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class EmptyBlock : IBlock
    {

        private IBlockSprite emptyBlockSprite;
        //private Game1 myGame;
        private Vector2 blockLocation;

        public EmptyBlock(Game1 game, Vector2 location)
        {
            emptyBlockSprite = new EmptyBlockSprite(game, this);
           // myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            emptyBlockSprite.Draw();
        }

        public Vector2 GameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            emptyBlockSprite.Update();
        }

        public void TopCollision() { }
        public void BottomCollision() { }
        public void LeftCollision() { }
        public void RightCollision() { }
    }
}
