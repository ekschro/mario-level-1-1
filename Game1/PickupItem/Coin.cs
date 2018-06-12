using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class Coin : IPickup
    {
        private int cyclePosition = 0;
        private int cycleLength = 16;

        public static CoinSprite coinSprite;

        public static CoinSprite CoinSprite { get => coinSprite; set => coinSprite = value; }

        private Game1 myGame;
        public Vector2 pickupLocation;

        public Coin(Game1 game, Vector2 location)
        {
            CoinSprite = new CoinSprite(game, this);
            myGame = game;
            pickupLocation = location;
        }

        public void Draw()
        {
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                cyclePosition = 0;
                CoinSprite.Draw();
            }
        }

        public Vector2 GetCurrentLocation()
        {
            return pickupLocation;
        }

        public void Update()
        {
            CoinSprite.Update();
        }
    }
}
