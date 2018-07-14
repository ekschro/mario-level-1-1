using Microsoft.Xna.Framework;
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
            lives = 3;
            points = 0;
            coins = 0;
        }

        public int Lives { get => lives;  }
        public int Points { get => points; }
        public int Coins { get => coins; }

        public void PowerUpCollectPoints()
        {
            points += 1000;
        }

        public void CoinCollectedPoints()
        {
            points += 200;
            coins += 1;
        }

        public void BlockDestroyPoints()
        {
            points += 50;
        }
        
        public void EnemyStompedPoints(int combo)
        {
            if (combo == 1)
            {
                points += 100;
            }
            else if (combo == 2)
            {
                points += 200;
            }
            else if (combo == 3)
            {
                points += 400;
            }
            else if (combo == 4)
            {
                points += 500;
            }
            else if (combo == 5)
            {
                points += 800;
            }
            else if (combo == 6)
            {
                points += 1000;
            }
            else if (combo == 7)
            {
                points += 2000;
            }
            else if (combo == 8)
            {
                points += 4000;
            }
            else if (combo == 9)
            {
                points += 5000;
            }
            else if (combo == 10)
            {
                points += 8000;
            }
            else if (combo >= 11)
            {
                OneUpLives();
            }
        }

        public void KoopaFireOrStarPoints()
        {
            points += 200;
        }

        public void KoopaShell(KoopaShell shell)
        {
            if (shell.KilledNum == 1)
            {
                points += 500;
            }
            else if (shell.KilledNum == 2)
            {
                points += 800;
            }
            else if (shell.KilledNum == 3)
            {
                points += 1000;
            }
            else if (shell.KilledNum == 4)
            {
                points += 2000;
            }
            else if (shell.KilledNum == 5)
            {
                points += 4000;
            }
            else if (shell.KilledNum == 6)
            {
                points += 5000;
            }
            else if (shell.KilledNum == 7)
            {
                points += 8000;
            }
            else if (shell.KilledNum >= 8)
            {
                OneUpLives();
            }
        }

        public void OneUpLives()
        {
            lives += 1;
        }

        public void DockLife()
        {
            lives -= 1;
        }

        public void Reset()
        {
            lives = 3;
            points = 0;
            coins = 0;
        }
    }
}
