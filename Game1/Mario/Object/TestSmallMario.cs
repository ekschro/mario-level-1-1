using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class TestSmallMario : AbstractTestMario
    {
        
        public TestSmallMario(Game1 game, Mario mario) : base(game,  mario)
        {
            
            marioSprite = new TestSmallMarioSprite(game, this, mario);
            stateMachine = new TestSmallMarioStateMachine(marioSprite);
            game.PersistentData.PlayerState = 1;
        }

        public override void Upgrade()
        {
             character.TestMario = new TestBigMario(myGame, character);
        }
        public override void Downgrade()
        {
            character.TestMario = new TestDeadMario(myGame, character);
        }
    }
}
