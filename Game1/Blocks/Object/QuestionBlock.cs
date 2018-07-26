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
        public float CurrentXPos { get => blockLocation.X; set => blockLocation.X = value; }
        public float CurrentYPos { get => blockLocation.Y; set => blockLocation.Y = value; }

        private IBlockSprite questionBlockSprite;
        private Vector2 blockLocation;
        private Rectangle blockRectangle;
        private int cyclePosition;
        private int cycleLength;
        private BlockUtilityClass utility;
        public QuestionBlock(Game1 game, Vector2 location)
        {
            questionBlockSprite = new QuestionBlockSprite(game, this);
            blockLocation = location;
            utility = new BlockUtilityClass();
            cyclePosition = utility.QuestionCyclePosition;
            cycleLength = utility.QuestionCycleLength;
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, utility.Width, utility.Height);
        }

        public void Draw()
        {
            questionBlockSprite.Draw();
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
                questionBlockSprite.Update();
                cyclePosition = utility.QuestionCyclePosition;
                blockLocation.Y -= 1;
            }
        }
    }
}
