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
        public float CurrentXPos { get => blockLocation.X; set => blockLocation.X = value; }
        public float CurrentYPos { get => blockLocation.Y; set => blockLocation.Y = value; }

        private IBlockSprite questionPowerUpBlockSprite;
        
        private Vector2 blockLocation;
        private Rectangle blockRectangle;
        private int cyclePosition;
        private int cycleLength;
        private BlockUtilityClass utility;

        public QuestionPowerUpBlock(Game1 game, Vector2 location)
        {
            utility = new BlockUtilityClass();
            cyclePosition = utility.QuestionCyclePosition;
            cycleLength = utility.QuestionCoinLength;
            questionPowerUpBlockSprite = new QuestionPowerUpBlockSprite(game, this);
            blockLocation = location;
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, utility.Width, utility.Height);
        }

        public void Draw()
        {
            questionPowerUpBlockSprite.Draw();
        }

        public Vector2 GameObjectLocation => blockLocation;

        public Rectangle BlockRectangle()
        {
            return blockRectangle;
        }

        public void Update()
        {
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                questionPowerUpBlockSprite.Update();
                cyclePosition = utility.QuestionCyclePosition;
            }

        }
    }
}
