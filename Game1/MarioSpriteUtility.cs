using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class MarioSpriteUtility
    {
        private int bigMarioLeftIdleStart = 13;
        private int bigMarioLeftIdleEnd = 12;
        private int bigMarioRightIdleStart = 14;
        private int bigMarioRightIdleEnd = 15;

        private int bigMarioLeftWalkingStart = 11;
        private int bigMarioLeftWalkingEnd = 8;
        private int bigMarioRightWalkingStart = 16;
        private int bigMarioRightWalkingEnd = 19;

        private int bigMarioLeftJumpingStart = 7;
        private int bigMarioLeftJumpingEnd = 6;
        private int bigMarioRightJumpingStart = 20;
        private int bigMarioRightJumpingEnd = 21;

        private int bigMarioLeftCrounchingStart = 12;
        private int bigMarioLeftCrounchingEnd = 11;
        private int bigMarioRightCrounchingStart = 15;
        private int bigMarioRightCrounchingEnd = 16;
        private int two = 2;

        private int turnSmallMario = 28;

        private int turnFireMario = 56;

        private int deadMario = 40;

        public int BigMarioLeftIdleStart { get => bigMarioLeftIdleStart; }
        public int BigMarioLeftIdleEnd { get => bigMarioLeftIdleEnd; }
        public int BigMarioRightIdleStart { get => bigMarioRightIdleStart; }
        public int BigMarioRightIdleEnd { get => bigMarioRightIdleEnd; }
        public int BigMarioLeftWalkingStart { get => bigMarioLeftWalkingStart; }
        public int BigMarioLeftWalkingEnd { get => bigMarioLeftWalkingEnd; }
        public int BigMarioRightWalkingStart { get => bigMarioRightWalkingStart; }
        public int BigMarioRightWalkingEnd { get => bigMarioRightWalkingEnd; }
        public int BigMarioLeftJumpingStart { get => bigMarioLeftJumpingStart; }
        public int BigMarioLeftJumpingEnd { get => bigMarioLeftJumpingEnd; }
        public int BigMarioRightJumpingStart { get => bigMarioRightJumpingStart; }
        public int BigMarioRightJumpingEnd { get => bigMarioRightJumpingEnd; }
        public int BigMarioLeftCrounchingStart { get => bigMarioLeftCrounchingStart; }
        public int BigMarioLeftCrounchingEnd { get => bigMarioLeftCrounchingEnd; }
        public int BigMarioRightCrounchingStart { get => bigMarioRightCrounchingStart; }
        public int BigMarioRightCrounchingEnd { get => bigMarioRightCrounchingEnd; }

        public int SmallMarioLeftIdleStart { get => ( bigMarioLeftIdleStart+ turnSmallMario); }
        public int SmallMarioLeftIdleEnd { get => ( bigMarioLeftIdleEnd+ turnSmallMario); }
        public int SmallMarioRightIdleStart { get => ( bigMarioRightIdleStart+ turnSmallMario); }
        public int SmallMarioRightIdleEnd { get => ( bigMarioRightIdleEnd+ turnSmallMario); }
        public int SmallMarioLeftWalkingStart { get => ( bigMarioLeftWalkingStart+ turnSmallMario); }
        public int SmallMarioLeftWalkingEnd { get => ( bigMarioLeftWalkingEnd+ turnSmallMario); }
        public int SmallMarioRightWalkingStart { get => ( bigMarioRightWalkingStart+ turnSmallMario); }
        public int SmallMarioRightWalkingEnd { get => ( bigMarioRightWalkingEnd+ turnSmallMario); }
        public int SmallMarioLeftJumpingStart { get => (bigMarioLeftJumpingStart + turnSmallMario); }
        public int SmallMarioLeftJumpingEnd { get => ( bigMarioLeftJumpingEnd+ turnSmallMario); }
        public int SmallMarioRightJumpingStart { get => ( bigMarioRightJumpingStart+ turnSmallMario); }
        public int SmallMarioRightJumpingEnd { get => ( bigMarioRightJumpingEnd+ turnSmallMario); }
        
        public int FireMarioLeftIdleStart { get => (bigMarioLeftIdleStart + turnFireMario); }
        public int FireMarioLeftIdleEnd { get => (bigMarioLeftIdleEnd + turnFireMario); }
        public int FireMarioRightIdleStart { get => (bigMarioRightIdleStart + turnFireMario); }
        public int FireMarioRightIdleEnd { get => (bigMarioRightIdleEnd + turnFireMario); }
        public int FireMarioLeftWalkingStart { get => (bigMarioLeftWalkingStart + turnFireMario); }
        public int FireMarioLeftWalkingEnd { get => (bigMarioLeftWalkingEnd + turnFireMario); }
        public int FireMarioRightWalkingStart { get => (bigMarioRightWalkingStart + turnFireMario); }
        public int FireMarioRightWalkingEnd { get => (bigMarioRightWalkingEnd + turnFireMario); }
        public int FireMarioLeftJumpingStart { get => (bigMarioLeftJumpingStart + turnFireMario); }
        public int FireMarioLeftJumpingEnd { get => (bigMarioLeftJumpingEnd + turnFireMario); }
        public int FireMarioRightJumpingStart { get => (bigMarioRightJumpingStart + turnFireMario); }
        public int FireMarioRightJumpingEnd { get => (bigMarioRightJumpingEnd + turnFireMario); }
        public int FireMarioLeftCrounchingStart { get => (bigMarioLeftCrounchingStart + turnFireMario); }
        public int FireMarioLeftCrounchingEnd { get => (bigMarioLeftCrounchingEnd + turnFireMario); }
        public int FireMarioRightCrounchingStart { get => (bigMarioRightCrounchingStart + turnFireMario); }
        public int FireMarioRightCrounchingEnd { get => (bigMarioRightCrounchingEnd + turnFireMario); }

        public int DeadMario { get => deadMario; }

    }
}
