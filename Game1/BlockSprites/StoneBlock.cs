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

        public static StoneBlockSprite stoneBlockSprite;

        public static StoneBlockSprite StoneBlockSprite { get => stoneBlockSprite; set => stoneBlockSprite = value; }

        private Game1 myGame;
        public Vector2 blockLocation;

        public StoneBlock(Game1 game, Vector2 location)
        {
            StoneBlockSprite = new StoneBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            StoneBlockSprite.Draw();
        }

        public Vector2 GetBlockCurrentLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            StoneBlockSprite.Update();
        }
    }
}
