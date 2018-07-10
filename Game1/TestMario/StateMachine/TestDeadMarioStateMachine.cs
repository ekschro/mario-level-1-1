using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class TestDeadMarioStateMachine : ITestMarioStateMachine
    {
        private ITestMarioSprite marioSprite;
        private bool facingLeft = true;
        private enum MarioSize { Small, Big, Fire, Dead };
        private enum MarioState { Idle, Walking, Jumping, Crouching };
        private MarioSize size = MarioSize.Dead;
        private MarioState state = MarioState.Idle;
        public TestDeadMarioStateMachine(ITestMarioSprite sprite)
        {
            marioSprite = sprite;
        }
        public void ChangeDirection()
        {
            facingLeft = !facingLeft;
        }
        public void Idle()
        {
            if (facingLeft)
                marioSprite.ChangeFrame(41 - 28, 42 - 28 + 1);
            else
                marioSprite.ChangeFrame(42 - 28, 42 - 28 + 1);
        }
        public void Walking()
        {
            if (facingLeft)
                marioSprite.ChangeFrame(11 + 56, 8 + 56);
            else
                marioSprite.ChangeFrame(16 + 56, 19 + 56);
        }
        public void Jumping()
        {
            if (facingLeft)
                marioSprite.ChangeFrame(7, 7 + 1);
            else
                marioSprite.ChangeFrame(20, 20 + 1);
        }
        public void Crouching()
        {
            if (facingLeft)
                marioSprite.ChangeFrame(12, 12 + 1);
            else
                marioSprite.ChangeFrame(15, 15 + 1);
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
