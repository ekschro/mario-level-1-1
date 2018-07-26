using System;

namespace Game1
{
    public class CollisionUtilityClass
    {
        private int tileOffset = 16;
        private int mainHeight = 16;
        private int mainWidth = 16;
        private int smallWidth = 6;
        private int fireWidth = 4;
        private int smallHeight = 6;
        private int two = 2;
        private int yMax = 800;
        private int size = 0;
        private int biggerHeight = 32;
        private int eight = 8;
        private int four = 4;
        private int lethalFall = 400;
        private int invulnerabilityFrames = 100;
        private int twentyfour = 24;
        private int one = 1;
        private int invulnerabilityRespondFrames = 1000;
        private int bowserSize = 32;
        private float enemyCollisionFudge = 0.4f;


        public CollisionUtilityClass()
        {
        }

        public int TileOffset { get => tileOffset; }
        public int MainHeight { get => mainHeight; }
        public int MainWidth { get => mainWidth; }
        public int SmallWidth { get => smallWidth; }
        public int SmallHeight { get => smallHeight; }
        public int Two { get => two; }
        public int YMax { get => yMax; }
        public int Size { get => size; }
        public int BiggerHeight { get => biggerHeight; }
        public int Eight { get => eight; }
        public int Four { get => four; }
        public int LethalFall { get => lethalFall; }
        public int InvulnerabilityFrames { get => invulnerabilityFrames; }
        public int Twentyfour { get => twentyfour; }
        public int One { get => one; }
        public int InvulnerabilityRespondFrames { get => invulnerabilityRespondFrames; }
        public int BowserSize { get => bowserSize; }
        public float EnemyCollisionFudge { get => enemyCollisionFudge; }
        public int FireWidth { get => fireWidth; }
    }
}