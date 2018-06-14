using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class HiddenBlock : IBlock
    {

        private static IBlockSprite hiddenBlockSprite;

        public static IBlockSprite HiddenBlockSprite { get => hiddenBlockSprite; set => hiddenBlockSprite = value; }

        private Game1 myGame;
        public Vector2 blockLocation;

        public HiddenBlock(Game1 game, Vector2 location)
        {
            HiddenBlockSprite = new HiddenBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            HiddenBlockSprite.Draw();
        }

        public Vector2 GetBlockCurrentLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            HiddenBlockSprite.Update();
        }
        public void ToUsed()
        {
            HiddenBlockSprite = new UsedBlockSprite(myGame, new UsedBlock(myGame,blockLocation));
        }

        public void ToEmpty()
        {
            //throw new NotImplementedException();
        }
    }
}
