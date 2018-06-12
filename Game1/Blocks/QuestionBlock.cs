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

        public static QuestionBlockSprite questionBlockSprite;

        public static QuestionBlockSprite QuestionBlockSprite { get => questionBlockSprite; set => questionBlockSprite = value; }

        private Game1 myGame;
        public Vector2 blockLocation;

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

        public Vector2 GetBlockCurrentLocation()
        {
            return blockLocation;
        }

        public void Update()
        {
            QuestionBlockSprite.Update();
        }
    }
}
