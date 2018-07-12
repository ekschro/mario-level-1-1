using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class TestFireMarioStateMachine : ITestMarioStateMachine
    {
        /*private ITestMarioSprite marioSprite;
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
                marioSprite.ChangeFrame(71, 72);
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
        }*/
        private ITestMarioSprite marioSprite;
        private bool facingLeft = false;
        private enum MarioSize { Small, Big, Fire, Dead };
        private enum MarioState { Idle, Walking, Jumping, Crouching };
        private MarioSize size = MarioSize.Small;
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
                marioSprite.ChangeFrame(69, 68);
            else
                marioSprite.ChangeFrame(70, 71);
            State = MarioState.Idle;
        }
        public void Walking()
        {
            State = MarioState.Walking;
            if (facingLeft)
                marioSprite.ChangeFrame(11 + 28 + 28, 8 + 28 + 28);
            else
                marioSprite.ChangeFrame(16 + 28 + 28, 19 + 28 + 28);

        }
        public void Jumping()
        {

            if (facingLeft)
                marioSprite.ChangeFrame(7 + 28 + 28, 7 + 28 - 1 + 28);
            else
                marioSprite.ChangeFrame(20 + 28 + 28, 20 + 28 + 1 + 28);
            State = MarioState.Jumping;
        }
        public void Crouching()
        {
            if (facingLeft)
                marioSprite.ChangeFrame(12 + 56, 11 + 56);
            else
                marioSprite.ChangeFrame(15 + 56, 15 + 1 + 56);
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
