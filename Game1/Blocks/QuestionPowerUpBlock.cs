using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class QuestionPowerUpBlock : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite questionPowerUpBlockSprite;
        private Game1 myGame;
        private Vector2 blockLocation;
        private int cyclePosition = 0;
        private int cycleLength = 16;

        public QuestionPowerUpBlock(Game1 game, Vector2 location)
        {
            questionPowerUpBlockSprite = new QuestionPowerUpBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            questionPowerUpBlockSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                questionPowerUpBlockSprite.Update();
                cyclePosition = 0;
            }

        }

        public void TopCollision() { }
        public void BottomCollision()
        {
            questionPowerUpBlockSprite = new UsedBlockSprite(myGame, new UsedBlock(myGame, blockLocation));
        }
        public void LeftCollision() { }
        public void RightCollision() { }
    }
}
