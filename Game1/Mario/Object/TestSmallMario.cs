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
        
        public TestSmallMario(Game1 game, Vector2 location, Mario mario) : base(game, location, mario)
        {
            
            marioSprite = new TestSmallMarioSprite(game, this, mario);
            stateMachine = new TestSmallMarioStateMachine(marioSprite);
            game.PersistentData.PlayerState = 1;
        }

        public override void Upgrade()
        {
             character.TestMario = new TestBigMario(myGame, new Vector2(character.CurrentXPos, character.CurrentYPos), character);
        }
        public override void Downgrade()
        {
            character.TestMario = new TestDeadMario(myGame, new Vector2(character.CurrentXPos, character.CurrentYPos), character);
        }
    }
}
