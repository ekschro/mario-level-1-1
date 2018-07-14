using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class CoinPickup : IPickup
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        public bool IsFalling { get; set; }

        private IPickupSprite coinPickupSprite;
        private Game1 myGame;
        private Vector2 pickupLocation;
        private Vector2 pickupOriginalLocation;
        private PickupUtilityClass utility;

        public CoinPickup(Game1 game, Vector2 location)
        {
            coinPickupSprite = new CoinPickupSprite(game, this);
            myGame = game;
            pickupLocation = location;
            pickupOriginalLocation = location;
            utility = new PickupUtilityClass();
        }

        public void Draw()
        {
            coinPickupSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return pickupLocation;
        }

        public void SetGameObjectLocation(Vector2 value)
        {
            pickupLocation = value;
        }

        public void Update()
        {
            utility.PickpupCyclePosition++;
            if (utility.PickpupCyclePosition == utility.PickpupCycleLength)
            {
                coinPickupSprite.Update();
                utility.PickpupCyclePosition = 0;
            }
        }

        public void Collide()
        {
        }

        public bool MovingRight()
        {
            return false;
        }
    }
}
