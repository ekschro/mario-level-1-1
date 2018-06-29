using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class HiddenStarBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite hiddenStarBlockSprite;
        //private Game1 myGame;
        private Vector2 blockLocation;

        public HiddenStarBlock(Game1 game, Vector2 location)
        {
            hiddenStarBlockSprite = new HiddenStarBlockSprite(game, this);
            //myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            hiddenStarBlockSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            hiddenStarBlockSprite.Update();
        }

    }
}
