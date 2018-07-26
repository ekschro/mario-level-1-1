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
       
        private enum MarioState { Idle, Walking, Jumping, Crouching };
        
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
           
            facingLeft = left;
        }
        public void Idle()
        {
            if (facingLeft)
                
                marioSprite.ChangeFrame(spriteUtility.FireMarioLeftIdleStart,spriteUtility.FireMarioLeftIdleEnd);
            else
                
                marioSprite.ChangeFrame(spriteUtility.FireMarioRightIdleStart, spriteUtility.FireMarioRightIdleEnd);
            State = MarioState.Idle;
        }
        public void Walking()
        {
            State = MarioState.Walking;
            if (facingLeft)
                
                marioSprite.ChangeFrame(spriteUtility.FireMarioLeftWalkingStart, spriteUtility.FireMarioLeftWalkingEnd);
            else
               
                marioSprite.ChangeFrame(spriteUtility.FireMarioRightWalkingStart, spriteUtility.FireMarioRightWalkingEnd);
        }
        public void Jumping()
        {

            if (facingLeft)
               
                marioSprite.ChangeFrame(spriteUtility.FireMarioLeftJumpingStart, spriteUtility.FireMarioLeftJumpingEnd);
            else
                
                marioSprite.ChangeFrame(spriteUtility.FireMarioRightJumpingStart, spriteUtility.FireMarioRightJumpingEnd);
            State = MarioState.Jumping;
        }
        public void Crouching()
        {
            if (facingLeft)
                
                marioSprite.ChangeFrame(spriteUtility.FireMarioLeftCrounchingStart, spriteUtility.FireMarioLeftCrounchingEnd);
            else
               
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
        public bool Direction => facingLeft;

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
