using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class QuestionCoinBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite questionCoinBlockSprite;
        private Game1 myGame;
        private Vector2 blockLocation;
        private int cyclePosition = 0;
        private int cycleLength = 16;

        public QuestionCoinBlock(Game1 game, Vector2 location)
        {
            questionCoinBlockSprite = new QuestionBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            questionCoinBlockSprite.Draw();
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
                questionCoinBlockSprite.Update();
                cyclePosition = 0;
            }

        }

        public void TopCollision() { }
        public void BottomCollision()
        {
            questionCoinBlockSprite = new UsedBlockSprite(myGame, new UsedBlock(myGame, blockLocation));
        }
        public void LeftCollision() { }
        public void RightCollision() { }
    }
}
