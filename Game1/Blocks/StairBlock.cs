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
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite stairBlockSprite;
        //private Game1 myGame;
        private Vector2 blockLocation;
        private Rectangle blockRectangle;

        public StairBlock(Game1 game, Vector2 location)
        {
            stairBlockSprite = new StairBlockSprite(game, this);
            //myGame = game;
            blockLocation = location;
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 16);
        }

        public void Draw()
        {
            stairBlockSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return blockLocation;
        }

        public Rectangle BlockRectangle()
        {
            return blockRectangle;
        }

        public void Update()
        {
            stairBlockSprite.Update();
        }

    }
}
