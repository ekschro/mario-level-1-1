﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public interface ITestMarioStateMachine
    {
        void ChangeDirection();
        void Upgrade();
        void Downgrade();
        void Update();
        bool GetDirection();
    }
}