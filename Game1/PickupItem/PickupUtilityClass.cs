using System;
namespace Game1
{
    public class PickupUtilityClass
    {
        private int column = 15;
        private int cyclePosition = 0;
        private int cycleLength = 16;
        private int coinStartFrame = 10;
        private int coinEndFrame = 14;
        private int fireflowerStartFrame = 2;
        private int fireflowerEndFrame = 6;
        private int greenMushroomFrame = 1;
        private int redMushroomFrame = 0;
        private int starStartFrame = 6;
        private int starEndFrame = 10;
        private int blockSize = 16;

        public PickupUtilityClass()
        {

        }
        public int PickupColumn { get => column; }
        public int PickpupCyclePosition { get => cyclePosition; set => cyclePosition = value; }
        public int PickpupCycleLength { get => cycleLength; }
        public int CoinStartFrame { get => coinStartFrame; }
        public int CoinEndFrame { get => coinEndFrame; }
        public int FireflowerStartFrame { get => fireflowerStartFrame; }
        public int FireflowerEndFrame { get => fireflowerEndFrame; }
        public int GreenMushroomFrame { get => greenMushroomFrame; }
        public int RedMushroomFrame { get => redMushroomFrame; }
        public int StarStartFrame { get => starStartFrame; }
        public int StarEndFrame { get => starEndFrame; }
        public int BlockSize { get => blockSize; }
    }
}