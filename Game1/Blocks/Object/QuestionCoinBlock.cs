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
        public float CurrentXPos { get => blockLocation.X; set => blockLocation.X = value; }
        public float CurrentYPos { get => blockLocation.Y; set => blockLocation.Y = value; }

        private IBlockSprite questionCoinBlockSprite;
       
        private Vector2 blockLocation;
        private BlockUtilityClass utility = new BlockUtilityClass();
        private Rectangle blockRectangle;
        private int cyclePosition;
        private int cycleLength;

        public QuestionCoinBlock(Game1 game, Vector2 location)
        {
            cyclePosition = utility.QuestionCyclePosition;
            cycleLength = utility.QuestionCoinLength;
            questionCoinBlockSprite = new QuestionCoinBlockSprite(game, this);
            
            blockLocation = location;
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, utility.Width, utility.Height);
        }

        public void Draw()
        {
            questionCoinBlockSprite.Draw();
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
                
                questionCoinBlockSprite.Update();
                cyclePosition = utility.QuestionCyclePosition;
            }

        }

    }
}
