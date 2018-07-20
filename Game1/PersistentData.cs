using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class PersistentData
    {
        private Game1 game;
        private int lives;
        private int points;
        private int coins;

        public PersistentData(Game1 game)
        {
            this.game = game;

            lives = 3;
            points = 0;
            coins = 0;
        }

        public void Draw(int value, Vector2 loc)
        {
            Vector2 location = new Vector2(loc.X,loc.Y);
            game.SpriteBatch.Begin();

            //game.SpriteBatch.DrawString(game.SpriteFont, value.ToString(), location, Color.White); //need to update

            //Not the way, create new HUD object and update draw from there... Will continue tomorrow

            game.SpriteBatch.End();
        }

        public int Lives { get => lives;  }
        public int Points { get => points; }
        public int Coins { get => coins; }

        public void PowerUpCollectPoints(Vector2 loc)
        {
            points += 1000;
            Draw(1000, loc);
        }

        public void CoinCollectedPoints(Vector2 loc)
        {
            points += 200;
            coins += 1;
            Draw(200, loc);
        }

        public void BlockDestroyPoints(Vector2 loc)
        {
            points += 50;
            Draw(50, loc);
        }
        
        public void EnemyStompedPoints(int combo, Vector2 loc)
        {
            int amount = 0;

            if (combo == 1)
            {
                amount = 100;
            }
            else if (combo == 2)
            {
                amount = 200;
            }
            else if (combo == 3)
            {
                amount = 400;
            }
            else if (combo == 4)
            {
                amount = 500;
            }
            else if (combo == 5)
            {
                amount = 800;
            }
            else if (combo == 6)
            {
                amount = 1000;
            }
            else if (combo == 7)
            {
                amount = 2000;
            }
            else if (combo == 8)
            {
                amount = 4000;
            }
            else if (combo == 9)
            {
                amount = 5000;
            }
            else if (combo == 10)
            {
                amount = 8000;
            }
            else if (combo >= 11)
            {
                OneUpLives(loc);
            }

            points += amount;
            Draw(amount, loc);
        }

        public void KoopaFireOrStarPoints(Vector2 loc)
        {
            points += 200;
            Draw(200, loc);
        }

        public void KoopaShell(KoopaShell shell, Vector2 loc)
        {
            int amount = 0;

            if (shell.KilledNum == 1)
            {
                amount = 500;
            }
            else if (shell.KilledNum == 2)
            {
                amount = 800;
            }
            else if (shell.KilledNum == 3)
            {
                amount = 1000;
            }
            else if (shell.KilledNum == 4)
            {
                amount = 2000;
            }
            else if (shell.KilledNum == 5)
            {
                amount = 4000;
            }
            else if (shell.KilledNum == 6)
            {
                amount = 5000;
            }
            else if (shell.KilledNum == 7)
            {
                amount = 8000;
            }
            else if (shell.KilledNum >= 8)
            {
                OneUpLives(loc);
                Draw(1, loc);
            }

            points += amount;
            Draw(amount, loc);
        }

        public void OneUpLives(Vector2 loc)
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
