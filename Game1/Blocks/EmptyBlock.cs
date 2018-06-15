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

        private static IBlockSprite emptyBlockSprite;

        public static IBlockSprite EmptyBlockSprite { get => emptyBlockSprite; set => emptyBlockSprite = value; }

        private Game1 myGame;
        public Vector2 blockLocation;

        public EmptyBlock(Game1 game, Vector2 location)
        {
            EmptyBlockSprite = new EmptyBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            EmptyBlockSprite.Draw();
        }

        public Vector2 GameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            EmptyBlockSprite.Update();
        }

        public void ToEmpty()
        {
        }

        public void ToUsed()
        {
        }
    }
}
