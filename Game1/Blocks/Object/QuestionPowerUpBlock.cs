using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class QuestionPowerUpBlock : AbstractBlock
    {
        private int cyclePosition;
        private int cycleLength;
        public QuestionPowerUpBlock(Game1 game, Vector2 location) : base(location)
        {
            blockSprite = new QuestionPowerUpBlockSprite(game, this);
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, utility.Width, utility.Height);
            utility = new BlockUtilityClass();
            cyclePosition = utility.QuestionCyclePosition;
            cycleLength = utility.QuestionCycleLength;
        }
        public override void Update()
        {
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                blockSprite.Update();
                cyclePosition = utility.QuestionCyclePosition;
            }
        }

    }
}
