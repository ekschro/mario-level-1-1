using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class BottomRightPipeBlock : IBlock
    {

        public IBlockSprite bottomRightPipeBlockSprite;

        //public static IBlockSprite BottomRightPipeBlockSprite { get => bottomRightPipeBlockSprite; set => bottomRightPipeBlockSprite = value; }

        private Game1 myGame;
        public Vector2 blockLocation;

        public BottomRightPipeBlock(Game1 game, Vector2 location)
        {
            bottomRightPipeBlockSprite = new BottomRightPipeBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            bottomRightPipeBlockSprite.Draw();
        }

        public Vector2 GameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            bottomRightPipeBlockSprite.Update();
        }

        public void TopCollision() { }

        public void BottomCollision()
        {
        }

        public void LeftCollision() { }
        public void RightCollision() { }
    }
}
