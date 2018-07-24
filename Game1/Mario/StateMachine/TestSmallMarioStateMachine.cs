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
        private bool facingLeft = false;
        
        private enum MarioState {Idle, Walking, Jumping, Crouching};
       
        private MarioState state = MarioState.Idle;
        private MarioSpriteUtility spriteUtility;

        private MarioState State { get => state; set => state = value; }

        public TestSmallMarioStateMachine(ITestMarioSprite sprite)
        {
            spriteUtility = new MarioSpriteUtility();
            marioSprite = sprite;
            
        }
        public void ChangeDirection(bool left)
        {
           
            facingLeft = left;
        }
        public void Idle()
        {
            if (facingLeft)
                
                marioSprite.ChangeFrame(spriteUtility.SmallMarioLeftIdleStart, spriteUtility.SmallMarioLeftIdleEnd);
            else
                
                marioSprite.ChangeFrame(spriteUtility.SmallMarioRightIdleStart, spriteUtility.SmallMarioRightIdleEnd);
            State = MarioState.Idle;
        }
        public void Walking()
        {
            State = MarioState.Walking;
            if (facingLeft)
                
                marioSprite.ChangeFrame(spriteUtility.SmallMarioLeftWalkingStart, spriteUtility.SmallMarioLeftWalkingEnd);
            else
                
                marioSprite.ChangeFrame(spriteUtility.SmallMarioRightWalkingStart, spriteUtility.SmallMarioRightWalkingEnd);
        }
        public void Jumping()
        {
            if (facingLeft)
                
                marioSprite.ChangeFrame(spriteUtility.SmallMarioLeftJumpingStart, spriteUtility.SmallMarioLeftJumpingEnd);
            else
                
                marioSprite.ChangeFrame(spriteUtility.SmallMarioRightJumpingStart, spriteUtility.SmallMarioRightJumpingEnd);
                State = MarioState.Jumping;
        }
        public void Crouching()
        {
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
