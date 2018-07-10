using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class PersistentData
    {
        private int lives;
        private int points;
        private int coins;

        public PersistentData()
        {
            lives = 4;
            points = 0;
            coins = 0;
        }

        public int Lives { get => lives;  }
        public int Points { get => points; }
        public int Coins { get => coins; }

        public void Draw()
        {

        }

        private void testPrint(int x)
        {
            Console.WriteLine(x);
            Console.WriteLine(points);
        }

        public void PowerUpCollectPoints()
        {
            points += 1000;
            testPrint(1000);
        }

        public void CoinCollectedPoints()
        {
            points += 200;
            testPrint(200);
        }

        public void BlockDestroyPoints()
        {
            points += 50;
            testPrint(50);
        }
        
        public void EnemyStompedPoints()
        {
            points += 100;
            testPrint(100);
        }

        public void KoopaFireOrStarPoints()
        {
            points += 200;
            testPrint(200);
        }
    }
}
