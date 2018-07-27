using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class TestDeadMario : AbstractTestMario
    {
        public TestDeadMario(Game1 game, Vector2 location, Mario mario) : base(game,  mario)
        {
            marioSprite = new TestDeadMarioSprite(game, mario);
            stateMachine = new TestDeadMarioStateMachine(marioSprite);
        }

        public override void Upgrade()
        {

        }
        public override void Downgrade()
        {

        }
    }
}
