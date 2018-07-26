using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class TestBigMario : AbstractTestMario
    {
        public TestBigMario(Game1 game, Vector2 location, Mario mario) : base(game, location, mario)
        {
            marioSprite = new TestBigMarioSprite(game, this,mario);
            stateMachine = new TestBigMarioStateMachine(marioSprite);
            game.PersistentData.PlayerState = 2;
        }

        public override void Upgrade()
        {
            character.TestMario = new TestFireMario(myGame, testMarioLocation, character);
        }
        public override void Downgrade()
        {
            character.TestMario = new TestSmallMario(myGame, testMarioLocation, character);
        }
    }
}
