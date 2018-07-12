﻿using System;
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
        public void ChangeDirection(bool left)
        {
            //facingLeft = !facingLeft;
            facingLeft = left;
        }
        public void Idle()
        {
            if (FacingLeft)
                marioSprite.ChangeFrame(13,12);
            else
                marioSprite.ChangeFrame(14,15);
            State = MarioState.Idle;
        }
        public void Walking()
        {
            if (FacingLeft)
                marioSprite.ChangeFrame(11 , 8 );
            else
                marioSprite.ChangeFrame(16, 19 );
            State = MarioState.Walking;
        }

        public void Jumping()
        {
            if (FacingLeft)
                marioSprite.ChangeFrame(7, 6);
            else
                marioSprite.ChangeFrame(20, 20 + 1);
            State = MarioState.Jumping;
        }
        public void Crouching()
        {
            if (FacingLeft)
                marioSprite.ChangeFrame(12, 11);
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

        bool ITestMarioStateMachine.FacingLeft()
        {
            if (facingLeft)
            {
                return true;
            } else
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
