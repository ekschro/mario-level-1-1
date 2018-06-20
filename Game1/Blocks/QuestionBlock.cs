using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class QuestionBlock : IBlock
    {

        private IBlockSprite questionBlockSprite;
        private Game1 myGame;
        private Vector2 blockLocation;
        private int cyclePosition = 0;
        private int cycleLength = 16;

        public QuestionBlock(Game1 game, Vector2 location)
        {
            questionBlockSprite = new QuestionBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            questionBlockSprite.Draw();
        }

        public Vector2 GameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                questionBlockSprite.Update();
                cyclePosition = 0;
            }
            
        }

        public void TopCollision() { }
        public void BottomCollision()
        {
            questionBlockSprite = new UsedBlockSprite(myGame, new UsedBlock(myGame, blockLocation));
        }
        public void LeftCollision() { }
        public void RightCollision() { }
    }
}
