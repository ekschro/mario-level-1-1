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
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite topLeftPipeBlockSprite;
        //private Game1 myGame;
        private Vector2 blockLocation;

        public TopLeftPipeBlock(Game1 game, Vector2 location)
        {
            topLeftPipeBlockSprite = new TopLeftPipeBlockSprite(game, this);
            //myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            topLeftPipeBlockSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            topLeftPipeBlockSprite.Update();
        }

    }
}
