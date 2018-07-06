using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class TestMarioStateMachine : ITestMarioStateMachine
    {
        private ITestMarioSprite marioSprite;
        private bool facingLeft = true;
        private enum MarioSize { Small, Big, Fire};
        private enum MarioState {Idle, Walking, Jumping, Crouching};
        private MarioSize size = MarioSize.Small;
        private MarioState state = MarioState.Idle;
        public TestMarioStateMachine(ITestMarioSprite sprite)
        {
            marioSprite = sprite;
        }
        public void ChangeDirection()
        {
            facingLeft = !facingLeft;
            if (size == MarioSize.Small && state == MarioState.Idle)
            {
                if (facingLeft)
                    marioSprite.ChangeFrame(41, 42);
                else
                    marioSprite.ChangeFrame(14+28,14+28+1);
            }
            else if (size == MarioSize.Small && state == MarioState.Walking)
            {
                if (facingLeft)
                    marioSprite.ChangeFrame(11 + 28, 8 + 28);
                else
                    marioSprite.ChangeFrame(16 + 28, 19 + 28);
            }
            else if (size == MarioSize.Small && state == MarioState.Jumping)
            {
                if (facingLeft)
                    marioSprite.ChangeFrame(7 + 28, 7 + 28 + 1);
                else
                    marioSprite.ChangeFrame(20 + 28, 20 + 28 + 1);
            }
            //Mario Big
            if (size == MarioSize.Big && state == MarioState.Idle)
            {
                if (facingLeft)
                    marioSprite.ChangeFrame(41 - 28, 42 - 28);
                else
                    marioSprite.ChangeFrame(42 - 28, 42 - 28 + 1);
            }
            else if (size == MarioSize.Big && state == MarioState.Walking)
            {
                if (facingLeft)
                    marioSprite.ChangeFrame(11, 8);
                else
                    marioSprite.ChangeFrame(16, 19);
            }
            else if (size == MarioSize.Big && state == MarioState.Jumping)
            {
                if (facingLeft)
                    marioSprite.ChangeFrame(7, 7 + 1);
                else
                    marioSprite.ChangeFrame(20, 20 + 1);
            }
        }
        public void Upgrade()
        {
            if (size == MarioSize.Small)
            {
                size = MarioSize.Big;
            }
            else if (size == MarioSize.Big)
            {
                size = MarioSize.Fire;
            }
            else { size = MarioSize.Fire; }
        }
        public void Downgrade()
        {
            if (size == MarioSize.Fire)
            {
                size = MarioSize.Big;
            }
            else if (size == MarioSize.Big)
            {
                size = MarioSize.Small;
            }
            else
            {
                size = MarioSize.Small;
            }
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
