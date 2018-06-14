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

        private static IBlockSprite bottomRightPipeBlockSprite;

        public static IBlockSprite BottomRightPipeBlockSprite { get => bottomRightPipeBlockSprite; set => bottomRightPipeBlockSprite = value; }

        private Game1 myGame;
        public Vector2 blockLocation;

        public BottomRightPipeBlock(Game1 game, Vector2 location)
        {
            BottomRightPipeBlockSprite = new BottomRightPipeBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            BottomRightPipeBlockSprite.Draw();
        }

        public Vector2 GetBlockCurrentLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            BottomRightPipeBlockSprite.Update();
        }

        public void ToEmpty()
        {
            throw new NotImplementedException();
        }

        public void ToUsed()
        {
            throw new NotImplementedException();
        }
    }
}
