using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class Fireflower : IPickup
    {
        private int cyclePosition = 0;
        private int cycleLength = 16;

        private static IPickupSprite fireflowerSprite;

        public static IPickupSprite FireflowerSprite { get => fireflowerSprite; set => fireflowerSprite = value; }

        private Game1 myGame;
        public Vector2 pickupLocation;

        public Fireflower(Game1 game, Vector2 location)
        {
            FireflowerSprite = new FireflowerSprite(game, this);
            myGame = game;
            pickupLocation = location;
        }

        public void Draw()
        {
            FireflowerSprite.Draw();
        }

        public Vector2 GetCurrentLocation()
        {
            return pickupLocation;
        }

        public void Update()
        {
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                FireflowerSprite.Update();
                cyclePosition = 0;
            }
        }
    }
}
