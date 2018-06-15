using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class StoneBlock : IBlock
    {

        public IBlockSprite stoneBlockSprite;

        //public static IBlockSprite StoneBlockSprite { get => stoneBlockSprite; set => stoneBlockSprite = value; }

        private Game1 myGame;
        public Vector2 blockLocation;

        public StoneBlock(Game1 game, Vector2 location)
        {
            stoneBlockSprite = new StoneBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            stoneBlockSprite.Draw();
        }

        public Vector2 GameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            stoneBlockSprite.Update();
        }

        public void TopCollision() { }

        public void BottomCollision()
        {
        }

        public void LeftCollision() { }
        public void RightCollision() { }
    }
}
