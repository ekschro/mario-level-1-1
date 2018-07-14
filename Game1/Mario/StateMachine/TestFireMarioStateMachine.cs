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
        //private enum MarioSize { Small, Big, Fire, Dead };
        private enum MarioState { Idle, Walking, Jumping, Crouching };
        //private MarioSize size = MarioSize.Small;
        private MarioState state = MarioState.Idle;
        private MarioSpriteUtility spriteUtility;

        private MarioState State { get => state; set => state = value; }

        public TestFireMarioStateMachine(ITestMarioSprite sprite)
        {
            spriteUtility = new MarioSpriteUtility();   
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
                //marioSprite.ChangeFrame(69, 68);
                marioSprite.ChangeFrame(spriteUtility.FireMarioLeftIdleStart,spriteUtility.FireMarioLeftIdleEnd);
            else
                //marioSprite.ChangeFrame(70, 71);
                marioSprite.ChangeFrame(spriteUtility.FireMarioRightIdleStart, spriteUtility.FireMarioRightIdleEnd);
            State = MarioState.Idle;
        }
        public void Walking()
        {
            State = MarioState.Walking;
            if (facingLeft)
                //marioSprite.ChangeFrame(11 + 28 + 28, 8 + 28 + 28);
                marioSprite.ChangeFrame(spriteUtility.FireMarioLeftWalkingStart, spriteUtility.FireMarioLeftWalkingEnd);
            else
                //marioSprite.ChangeFrame(16 + 28 + 28, 19 + 28 + 28);
                marioSprite.ChangeFrame(spriteUtility.FireMarioRightWalkingStart, spriteUtility.FireMarioRightWalkingEnd);
        }
        public void Jumping()
        {

            if (facingLeft)
                //marioSprite.ChangeFrame(7 + 28 + 28, 7 + 28 - 1 + 28);
                marioSprite.ChangeFrame(spriteUtility.FireMarioLeftJumpingStart, spriteUtility.FireMarioLeftJumpingEnd);
            else
                //marioSprite.ChangeFrame(20 + 28 + 28, 20 + 28 + 1 + 28);
                marioSprite.ChangeFrame(spriteUtility.FireMarioRightJumpingStart, spriteUtility.FireMarioRightJumpingEnd);
            State = MarioState.Jumping;
        }
        public void Crouching()
        {
            if (facingLeft)
                //marioSprite.ChangeFrame(12 + 56, 11 + 56);
                marioSprite.ChangeFrame(spriteUtility.FireMarioLeftCrounchingStart, spriteUtility.FireMarioLeftCrounchingEnd);
            else
                //marioSprite.ChangeFrame(15 + 56, 15 + 1 + 56);
                marioSprite.ChangeFrame(spriteUtility.FireMarioRightCrounchingStart, spriteUtility.FireMarioRightCrounchingEnd);
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
