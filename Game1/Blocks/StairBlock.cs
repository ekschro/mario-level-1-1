using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class StairBlock : IBlock
    {

        public IBlockSprite stairBlockSprite;

       // public static IBlockSprite StairBlockSprite { get => stairBlockSprite; set => stairBlockSprite = value; }

        private Game1 myGame;
        public Vector2 blockLocation;

        public StairBlock(Game1 game, Vector2 location)
        {
            stairBlockSprite = new StairBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            stairBlockSprite.Draw();
        }

        public Vector2 GameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            stairBlockSprite.Update();
        }

        public void TopCollision() { }

        public void BottomCollision()
        {
        }

        public void LeftCollision() { }
        public void RightCollision() { }
    }
}
