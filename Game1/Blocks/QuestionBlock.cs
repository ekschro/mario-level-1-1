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

        private static IBlockSprite questionBlockSprite;

        public static IBlockSprite QuestionBlockSprite { get => questionBlockSprite; set => questionBlockSprite = value; }

        private Game1 myGame;
        public Vector2 blockLocation;
        private int cyclePosition = 0;
        private int cycleLength = 16;

        public QuestionBlock(Game1 game, Vector2 location)
        {
            QuestionBlockSprite = new QuestionBlockSprite(game, this);
            myGame = game;
            blockLocation = location;
        }

        public void Draw()
        {
            QuestionBlockSprite.Draw();
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
                QuestionBlockSprite.Update();
                cyclePosition = 0;
            }
            
        }

        public void ToEmpty()
        {
            //throw new NotImplementedException();
        }

        public void ToUsed()
        {
            QuestionBlockSprite = new UsedBlockSprite(myGame, new UsedBlock(myGame, blockLocation));
        }
    }
}
