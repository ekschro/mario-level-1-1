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
            lives = 0;
            points = 0;
            coins = 0;
        }

        public int Lives { get => lives;  }
        public int Points { get => points; }
        public int Coins { get => coins; }

        public void Draw()
        {

        }
        
        public void EnemyStompedPoints()
        {
            points += 100;
        }
    }
}
