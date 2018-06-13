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

        public static TopLeftPipeBlockSprite topLeftPipeBlockSprite;

        public static TopLeftPipeBlockSprite TopLeftPipeBlockSprite { get => topLeftPipeBlockSprite; set => topLeftPipeBlockSprite = value; }

        private Game1 myGame;
        public Vector2 blockLocation;

        public TopLeftPipeBlock(Game1 game, Vector2 location)
        {
            TopLeftPipeBlockSprite = new TopLeftPipeBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            TopLeftPipeBlockSprite.Draw();
        }

        public Vector2 GetBlockCurrentLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            TopLeftPipeBlockSprite.Update();
        }
    }
}
