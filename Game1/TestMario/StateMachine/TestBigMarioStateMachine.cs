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
        private bool facingLeft = true;
        private enum MarioSize { Small, Big, Fire, Dead};
        public enum MarioState { Idle, Walking, Jumping, Crouching };
        private MarioSize size = MarioSize.Big;
        private MarioState state = MarioState.Idle;
        
        public MarioState State { get => state; set => state = value; }
        public bool FacingLeft { get => facingLeft; set => facingLeft = value; }

        public TestBigMarioStateMachine(ITestMarioSprite sprite)
        {
            marioSprite = sprite;
        }
        public void ChangeDirection()
        {
            FacingLeft = !FacingLeft;
        }
        public void Idle()
        {
            if (FacingLeft)
                marioSprite.ChangeFrame(41 - 28, 42 - 28 + 1);
            else
                marioSprite.ChangeFrame(42 - 28, 42 - 28 + 1);
            State = MarioState.Idle;
        }
        public void Walking()
        {
            if (FacingLeft)
                marioSprite.ChangeFrame(11 + 56, 8 + 56);
            else
                marioSprite.ChangeFrame(16 + 56, 19 + 56);
            State = MarioState.Walking;
        }
        public void Jumping()
        {
            if (FacingLeft)
                marioSprite.ChangeFrame(7, 7 + 1);
            else
                marioSprite.ChangeFrame(20, 20 + 1);
            State = MarioState.Jumping;
        }
        public void Crouching()
        {
            if (FacingLeft)
                marioSprite.ChangeFrame(12, 12 + 1);
            else
                marioSprite.ChangeFrame(15, 15 + 1);
            State = MarioState.Crouching;
        }
        
        public void Update()
        {
        }
        public bool GetDirection()
        {
            return FacingLeft;
        }
        public Boolean IsWalking()
        {
            if(State == MarioState.Walking)
            {
                return true;
            } else
            {
                return false;
            }
        }
        public Boolean IsJumping()
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
        public Boolean IsIdle()
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
        public Boolean IsCrouching()
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
    }
}
