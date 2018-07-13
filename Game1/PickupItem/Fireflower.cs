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
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        public bool IsFalling { get; set; }

        //private int cyclePosition = 0;
        //private int cycleLength = 16;

        private IPickupSprite fireflowerSprite;
        private Game1 myGame;
        private Vector2 pickupLocation;
        private Vector2 pickupOriginalLocation;
        private PickupUtilityClass utility;

        public Fireflower(Game1 game, Vector2 location)
        {
            fireflowerSprite = new FireflowerSprite(game, this);
            myGame = game;
            pickupLocation = location;
            pickupOriginalLocation = location;
            utility = new PickupUtilityClass();
        }

        public void Draw()
        {
            fireflowerSprite.Draw();
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
            if (utility.PickpupCyclePosition==utility.PickpupCycleLength)
            {
                fireflowerSprite.Update();
                utility.PickpupCyclePosition = 0;
            }
            if (pickupLocation.Y > pickupOriginalLocation.Y - utility.BlockSize)
            {
                pickupLocation.Y--;
            }
        }
        public void Picked()
        {
            //fireflowerSprite = new EmptyPickupSprite(myGame, new EmptyPickup(myGame, pickupLocation));
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
