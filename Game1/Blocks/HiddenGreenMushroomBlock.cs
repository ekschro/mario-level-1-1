using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class HiddenGreenMushroomBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite hiddenGreenMushroomBlockSprite;
        //private Game1 myGame;
        private Vector2 blockLocation;

        public HiddenGreenMushroomBlock(Game1 game, Vector2 location)
        {
            hiddenGreenMushroomBlockSprite = new HiddenGreenMushroomBlockSprite(game, this);
            //myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            hiddenGreenMushroomBlockSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            hiddenGreenMushroomBlockSprite.Update();
        }

    }
}
