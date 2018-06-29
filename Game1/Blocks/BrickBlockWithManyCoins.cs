using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class BrickBlockWithManyCoins : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite brickBlockSprite;
        //private Game1 myGame;
        private Vector2 blockLocation;

        public BrickBlockWithManyCoins(Game1 game, Vector2 location)
        {
            brickBlockSprite = new BrickBlockSprite(game, this);
            //myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            brickBlockSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            brickBlockSprite.Update();
            
        }
        public void TopCollision() { }
        public void BottomCollision()
        {
            //brickBlockSprite = new EmptyBlockSprite(myGame, new EmptyBlock(myGame, blockLocation));
        }
        public void LeftCollision() { }
        public void RightCollision() { }
    }
}
