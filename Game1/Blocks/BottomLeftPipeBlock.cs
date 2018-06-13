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

        private static IBlockSprite bottomLeftPipeBlockSprite;

        public static IBlockSprite BottomLeftPipeBlockSprite { get => bottomLeftPipeBlockSprite; set => bottomLeftPipeBlockSprite = value; }

        private Game1 myGame;
        public Vector2 blockLocation;

        public BottomLeftPipeBlock(Game1 game, Vector2 location)
        {
            BottomLeftPipeBlockSprite = new BottomLeftPipeBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            BottomLeftPipeBlockSprite.Draw();
        }

        public Vector2 GetBlockCurrentLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            BottomLeftPipeBlockSprite.Update();
        }
    }
}
