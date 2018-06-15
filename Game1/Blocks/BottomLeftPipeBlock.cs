using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class BottomLeftPipeBlock : IBlock
    {

        public  IBlockSprite bottomLeftPipeBlockSprite;

       // public static IBlockSprite BottomLeftPipeBlockSprite { get => bottomLeftPipeBlockSprite; set => bottomLeftPipeBlockSprite = value; }

        private Game1 myGame;
        public Vector2 blockLocation;

        public BottomLeftPipeBlock(Game1 game, Vector2 location)
        {
            bottomLeftPipeBlockSprite = new BottomLeftPipeBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            bottomLeftPipeBlockSprite.Draw();
        }

        public Vector2 GameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            bottomLeftPipeBlockSprite.Update();
        }

        public void TopCollision() { }

        public void BottomCollision()
        {
        }

        public void LeftCollision() { }
        public void RightCollision() { }
    }
}
