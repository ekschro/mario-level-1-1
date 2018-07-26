using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class BrickBlock : IBlock
    {
        public float CurrentXPos { get => blockLocation.X; set => blockLocation.X = value; }
        public float CurrentYPos { get => blockLocation.Y; set => blockLocation.Y = value; }

        private IBlockSprite brickBlockSprite;
        //private Game1 myGame;
        private Vector2 blockLocation;
        private Rectangle blockRectangle;
        private BlockUtilityClass utility;
        public BrickBlock(Game1 game, Vector2 location)
        {
            brickBlockSprite = new BrickBlockSprite(game, this);
            //myGame = game;
            blockLocation = location;
            utility = new BlockUtilityClass();
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, utility.Width, utility.Height);
        }

        public void Draw()
        {
            brickBlockSprite.Draw();
        }

        public Vector2 GameObjectLocation => blockLocation;

        public Rectangle BlockRectangle()
        {
            return blockRectangle;
        }

        public void Update()
        {
            brickBlockSprite.Update();
            
        }

        public void Bounce()
        {
            ((BrickBlockSprite)brickBlockSprite).Bounce();
        }
    }
}
