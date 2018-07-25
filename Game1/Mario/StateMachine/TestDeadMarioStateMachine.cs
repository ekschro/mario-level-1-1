using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class TestDeadMarioStateMachine : ITestMarioStateMachine
    {
        private bool facingLeft = true;
       
        private enum MarioState { Idle, Walking, Jumping, Crouching };
        
        private MarioState state = MarioState.Idle;

        public TestDeadMarioStateMachine(ITestMarioSprite sprite)
        {
        }
        public void ChangeDirection(bool left)
        {
           
            facingLeft = left;
        }
        public void Idle()
        {

        }
        public void Walking()
        {

        }
        public void Jumping()
        {

        }
        public void Crouching()
        {

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
            return false;
        }

        public bool IsJumping()
        {
            return false;
        }

        public bool IsIdle()
        {
            return false;
        }

        public bool IsCrouching()
        {
            return false;
        }
        public void ChangeState()
        {
            state = MarioState.Idle;
        }
    }
}
