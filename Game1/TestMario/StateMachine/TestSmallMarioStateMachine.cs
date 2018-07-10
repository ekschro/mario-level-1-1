using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class TestSmallMarioStateMachine : ITestMarioStateMachine
    {
        private ITestMarioSprite marioSprite;
        private bool facingLeft = true;
        private enum MarioSize { Small, Big, Fire, Dead};
        private enum MarioState {Idle, Walking, Jumping, Crouching};
        private MarioSize size = MarioSize.Small;
        private MarioState state = MarioState.Idle;
        public TestSmallMarioStateMachine(ITestMarioSprite sprite)
        {
            marioSprite = sprite;
        }
        public void ChangeDirection()
        {
            facingLeft = !facingLeft;
        }
        public void Upgrade()
        {
            
        }
        public void Downgrade()
        {
           
        }
        public void Idle()
        {
            
            if (facingLeft)
                marioSprite.ChangeFrame(41, 42);
            else
                marioSprite.ChangeFrame(14 + 28, 14 + 28 + 1);
            state = MarioState.Idle;
        }
        public void Walking()
        {
            
            if (facingLeft)
                marioSprite.ChangeFrame(11 + 28, 8 + 28);
            else
                marioSprite.ChangeFrame(16 + 28, 19 + 28);
            state = MarioState.Walking;
        }
        public void Jumping()
        {
            
            if (facingLeft)
                marioSprite.ChangeFrame(7 + 28, 7 + 28 + 1);
            else
                marioSprite.ChangeFrame(20 + 28, 20 + 28 + 1);
            state = MarioState.Jumping;
        }
        public void Crouching()
        {
            state = MarioState.Crouching;
        }
        public void Update()
        {
        }
        public bool GetDirection()
        {
            return facingLeft;
        }

    }
}
