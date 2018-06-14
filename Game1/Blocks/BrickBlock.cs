using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class BrickBlock : IBlock
    {

        private static IBlockSprite brickBlockSprite;

        public static IBlockSprite BrickBlockSprite { get => brickBlockSprite; set => brickBlockSprite = value; }

        private Game1 myGame;
        public Vector2 blockLocation;

        public BrickBlock(Game1 game, Vector2 location)
        {
            BrickBlockSprite = new BrickBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            BrickBlockSprite.Draw();
        }

        public Vector2 GetBlockCurrentLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            BrickBlockSprite.Update();
            
        }
        public void ToEmpty()
        {
            BrickBlockSprite = new EmptyBlockSprite(myGame, new EmptyBlock(myGame, blockLocation));
        }

        public void ToUsed()
        {
        }
    }
}
