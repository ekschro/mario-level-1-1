﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public interface ITestMario : IGameObject
    {
        void Idle();
        void Walking();
        void Jumping();
        void Crouching();
        void Upgrade();
        void Downgrade();
        ITestMarioStateMachine StateMachine { get; }
        void Flag();
        void Pipe(bool isPositive, bool isHorizontal);
    }
}
