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
        private Game1 myGame;
        private Vector2 blockLocation;

        public HiddenGreenMushroomBlock(Game1 game, Vector2 location)
        {
            hiddenGreenMushroomBlockSprite = new HiddenBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            hiddenGreenMushroomBlockSprite.Draw();
        }

        public Vector2 GameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            hiddenGreenMushroomBlockSprite.Update();
        }
        public void TopCollision() { }
        public void BottomCollision()
        {
            hiddenGreenMushroomBlockSprite = new UsedBlockSprite(myGame, new UsedBlock(myGame, blockLocation));
        }
        public void LeftCollision() { }
        public void RightCollision() { }
    }
}
