using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class EnemyUtilityClass
    {
        private int goombaColumn = 4;
        private int goombaStartFrame = 0;
        private int goombaEndFrame = 2;
        private int goombaStompedStartFrame = 2;
        private int goombaStompedEndFrame = 3;

        private int koopaColumn = 6;

        private int koopaShellStartFrame = 4;
        private int koopaShellEndFrame = 6;
        private int koopaLeftStartFrame = 2;
        private int koopaLeftEndFrame = 4;
        private int koopaRightStartFrame = 0;
        private int koopaRightEndFrame = 2;

        private int cyclePosition = 0;
        private int cycleLength = 8;


        public EnemyUtilityClass()
        {

        }
        public int GoombaColumn { get => goombaColumn; }

        public int GoombaStartFrame{ get => goombaStartFrame; }
        public int GoombaEndFrame { get => goombaEndFrame; }
        public int GoombaStompedStartFrame { get => goombaStompedStartFrame; }
        public int GoombaStompedEndFrame { get => goombaStompedEndFrame; }

        public int KoopaColumn { get => koopaColumn; }
        public int KoopaShellStartFrame { get => koopaShellStartFrame; }
        public int KoopaShellEndFrame { get => koopaShellEndFrame; }
        public int KoopaLeftStartFrame { get => koopaLeftStartFrame; }
        public int KoopaLeftEndFrame { get => koopaLeftEndFrame; }
        public int KoopaRightStartFrame { get => koopaRightStartFrame; }
        public int KoopaRightEndFrame { get => koopaRightEndFrame; }

        public int EnemyupCyclePosition { get => cyclePosition; set => cyclePosition = value; }
        public int EnemyCycleLength { get => cycleLength; }
    }
}
