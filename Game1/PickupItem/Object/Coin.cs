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
        
        private Vector2 pickupLocation;
       
        private PickupUtilityClass utility;

        public CoinPickup(Game1 game, Vector2 location)
        {
            coinPickupSprite = new CoinPickupSprite(game, this);
            
            pickupLocation = location;
            
            utility = new PickupUtilityClass();
        }

        public void Draw()
        {
            coinPickupSprite.Draw();
        }

        public Vector2 GameObjectLocation => pickupLocation;

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
