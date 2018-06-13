using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class TopRightPipeBlock : IBlock
    {

        public static TopRightPipeBlockSprite topRightPipeBlockSprite;

        public static TopRightPipeBlockSprite TopRightPipeBlockSprite { get => topRightPipeBlockSprite; set => topRightPipeBlockSprite = value; }

        private Game1 myGame;
        public Vector2 blockLocation;

        public TopRightPipeBlock(Game1 game, Vector2 location)
        {
            TopRightPipeBlockSprite = new TopRightPipeBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            TopRightPipeBlockSprite.Draw();
        }

        public Vector2 GetBlockCurrentLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            TopRightPipeBlockSprite.Update();
        }
    }
}
