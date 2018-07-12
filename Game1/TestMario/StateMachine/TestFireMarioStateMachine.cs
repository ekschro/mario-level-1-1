using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class TestFireMarioStateMachine : ITestMarioStateMachine
    {
        private ITestMarioSprite marioSprite;
        private bool facingLeft = false;
        private enum MarioSize { Small, Big, Fire, Dead };
        private enum MarioState { Idle, Walking, Jumping, Crouching };
        private MarioSize size = MarioSize.Fire;
        private MarioState state = MarioState.Idle;

        private MarioState State { get => state; set => state = value; }

        public TestFireMarioStateMachine(ITestMarioSprite sprite)
        {
            marioSprite = sprite;
        }
        public void ChangeDirection(bool left)
        {
            //facingLeft = !facingLeft;
            facingLeft = left;
        }
        public void Idle()
        {
            if (facingLeft)
                marioSprite.ChangeFrame(70, 69);
            else
                marioSprite.ChangeFrame(42 + 28, 42 + 28 + 1);
            State = MarioState.Idle;
        }
        public void Walking()
        {
            if (facingLeft)
                marioSprite.ChangeFrame(11 + 56, 8 + 56);
            else
                marioSprite.ChangeFrame(16 + 56, 19 + 56);
            State = MarioState.Walking;
        }
        public void Jumping()
        {
            if (facingLeft)
                marioSprite.ChangeFrame(7 + 56, 62);
            else
                marioSprite.ChangeFrame(20 + 56, 20 + 56 + 1);
            State = MarioState.Jumping;
        }
        public void Crouching()
        {
            if (facingLeft)
                marioSprite.ChangeFrame(12 + 56, 12 + 56 - 1);
            else
                marioSprite.ChangeFrame(15 + 56, 15 + 56 + 1);
            State = MarioState.Crouching;
        }
        
        public void Update()
        {
        }
        public bool GetDirection()
        {
            return facingLeft;
        }

        public bool FacingLeft()
        {
            if (facingLeft)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsWalking()
        {
            if (State == MarioState.Walking)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsJumping()
        {
            if (State == MarioState.Jumping)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsIdle()
        {
            if (State == MarioState.Idle)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsCrouching()
        {
            if (State == MarioState.Crouching)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ChangeState()
        {
            State = MarioState.Idle;
        }
    }
}
