using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class TestFireMario : AbstractTestMario
    {
        public TestFireMario(Game1 game, Mario mario) : base(game,  mario)
        {
            marioSprite = new TestFireMarioSprite(game, this, mario);
            stateMachine = new TestFireMarioStateMachine(marioSprite);
            game.PersistentData.PlayerState = 3;
        }
        public override void Upgrade()
        {
            
        }
        public override void Downgrade()
        {
            character.TestMario = new TestBigMario(myGame, character);
        }
    }
}
