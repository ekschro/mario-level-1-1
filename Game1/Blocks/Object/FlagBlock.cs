using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class FlagBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite flagBlockSprite;
        private Vector2 blockLocation;
        private Rectangle blockRectangle;
        private BlockUtilityClass utility;
        public FlagBlock(Game1 game, Vector2 location)
        {
            flagBlockSprite = new FlagBlockSprite(game, this);
            blockLocation = location;
            utility = new BlockUtilityClass();
            blockRectangle = new Rectangle((int)location.X + utility.Width, (int)location.Y, utility.Width, utility.Height);
            
        }

        public void Draw()
        {
            flagBlockSprite.Draw();
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

        }


    }
}
