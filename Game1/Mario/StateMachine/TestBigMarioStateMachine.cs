using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class TestBigMarioStateMachine : ITestMarioStateMachine
    {
        private ITestMarioSprite marioSprite;
        private bool facingLeft = false;
        private enum MarioState { Idle, Walking, Jumping, Crouching };
        private MarioState state = MarioState.Idle;

        private MarioState State { get => state; set => state = value; }

        public TestBigMarioStateMachine(ITestMarioSprite sprite)
        {
            marioSprite = sprite;

        }
        public void ChangeDirection(bool left)
        {
            facingLeft = left;
        }
        public void Idle()
        {
            if (facingLeft)
                marioSprite.ChangeFrame(41 - 28, 40 - 28);
            else
                marioSprite.ChangeFrame(42 - 28, 43 - 28);
            State = MarioState.Idle;
        }
        public void Walking()
        {
            State = MarioState.Walking;
            if (facingLeft)
                marioSprite.ChangeFrame(11, 8);
            else
                marioSprite.ChangeFrame(16, 19);

        }
        public void Jumping()
        {

            if (facingLeft)
                marioSprite.ChangeFrame(7, 7 - 1);
            else
                marioSprite.ChangeFrame(20, 20 + 1);
            State = MarioState.Jumping;
        }
        public void Crouching()
        {
            if (facingLeft)
                marioSprite.ChangeFrame(12, 11);
            else
                marioSprite.ChangeFrame(15, 15 + 1);
            State = MarioState.Crouching;
        }
        public void Update()
        {
            if (state == MarioState.Crouching)
                Crouching();
            else if (state == MarioState.Idle)
                Idle();
            else if (state == MarioState.Jumping)
                Jumping();
            else if (state == MarioState.Walking)
                Walking();
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
