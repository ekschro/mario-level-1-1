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

        private IBlockSprite hiddenStarBlockSprite;
        private Game1 myGame;
        private Vector2 blockLocation;

        public HiddenStarBlock(Game1 game, Vector2 location)
        {
            hiddenStarBlockSprite = new HiddenBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            hiddenStarBlockSprite.Draw();
        }

        public Vector2 GameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            hiddenStarBlockSprite.Update();
        }
        public void TopCollision() { }
        public void BottomCollision()
        {
            hiddenStarBlockSprite = new UsedBlockSprite(myGame, new UsedBlock(myGame, blockLocation));
        }
        public void LeftCollision() { }
        public void RightCollision() { }
    }
}
