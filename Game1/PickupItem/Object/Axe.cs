using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class AxePickup : IPickup
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        public bool IsFalling { get; set; }

        private IPickupSprite axePickupSprite;
        private Vector2 pickupLocation;

        public AxePickup(Game1 game, Vector2 location)
        {
            axePickupSprite = new AxePickupSprite(game, this);
            pickupLocation = location;
        }

        public void Draw()
        {
            axePickupSprite.Draw();
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
