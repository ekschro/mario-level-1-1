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
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private int cyclePosition = 0;
        private int cycleLength = 16;
        private IPickupSprite coinSprite;
        private Game1 myGame;
        private Vector2 pickupLocation;

        public Coin(Game1 game, Vector2 location)
        {
            coinSprite = new CoinSprite(game, this);
            myGame = game;
            pickupLocation = location;
        }

        public void Draw()
        {
            coinSprite.Draw();
        }

        public Vector2 GameObjectLocation()
        {
            return pickupLocation;
        }

        public void Update()
        {
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                cyclePosition = 0;
                coinSprite.Update();
            }
        }
        public void Picked()
        {
            coinSprite = new EmptyPickupSprite(myGame, new EmptyPickup(myGame,pickupLocation));
        }
    }
}
