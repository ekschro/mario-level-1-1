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

        public static StairBlockSprite stairBlockSprite;

        public static StairBlockSprite StairBlockSprite { get => stairBlockSprite; set => stairBlockSprite = value; }

        private Game1 myGame;
        public Vector2 blockLocation;

        public StairBlock(Game1 game, Vector2 location)
        {
            StairBlockSprite = new StairBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            StairBlockSprite.Draw();
        }

        public Vector2 GetBlockCurrentLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            StairBlockSprite.Update();
        }
    }
}
