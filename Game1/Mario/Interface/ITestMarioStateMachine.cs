using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public interface ITestMarioStateMachine
    {
        void ChangeDirection(bool left);
        void Idle();
        void Walking();
        void Jumping();
        void Crouching();
        void Update();
        bool GetDirection();
        bool FacingLeft();
        Boolean IsWalking();
        Boolean IsJumping();
        Boolean IsIdle();
        Boolean IsCrouching();
        void ChangeState();

    }
}
