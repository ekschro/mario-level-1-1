using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class TestSmallMarioStateMachine 
    {
        private ISpriteTest marioSprite;
        private bool facingLeft = false;
        private enum MarioState {Idle, Walking, Jumping, Crouching};
        private MarioState state = MarioState.Idle;
        public TestSmallMarioStateMachine(ISpriteTest sprite)
        {
            marioSprite = sprite;
        }
        public void ChangeDirection()
        { }
        public void Upgrade()
        { }
        public void Downgrade()
        { }
        public void Update()
        {
        }
        public bool GetDirection()
        {
            return facingLeft;
        }

    }
}
