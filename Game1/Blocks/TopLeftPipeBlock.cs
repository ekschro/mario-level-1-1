using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class TopLeftPipeBlock : IBlock
    {

        public IBlockSprite topLeftPipeBlockSprite;

        //public static IBlockSprite TopLeftPipeBlockSprite { get => topLeftPipeBlockSprite; set => topLeftPipeBlockSprite = value; }

        private Game1 myGame;
        public Vector2 blockLocation;

        public TopLeftPipeBlock(Game1 game, Vector2 location)
        {
            topLeftPipeBlockSprite = new TopLeftPipeBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            topLeftPipeBlockSprite.Draw();
        }

        public Vector2 GameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            topLeftPipeBlockSprite.Update();
        }

        public void TopCollision() { }

        public void BottomCollision()
        {
        }

        public void LeftCollision() { }
        public void RightCollision() { }
    }
}
