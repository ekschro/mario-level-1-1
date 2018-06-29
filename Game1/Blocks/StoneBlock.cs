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
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite stoneBlockSprite;
        //private Game1 myGame;
        private Vector2 blockLocation;

        public StoneBlock(Game1 game, Vector2 location)
        {
            stoneBlockSprite = new StoneBlockSprite(game, this);
            //myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            stoneBlockSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            stoneBlockSprite.Update();
        }

    }
}
