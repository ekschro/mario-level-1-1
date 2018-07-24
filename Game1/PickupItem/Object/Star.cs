using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class Star : IPickup
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private bool falling;
        public bool IsFalling { get => falling; set => falling = value; }

       

        private IPickupSprite starSprite;
        private Game1 myGame;
        private Vector2 pickupLocation;
        private Vector2 pickupOriginalLocation;
        private IPhysics physics;
        private bool movingRight;
        private bool moving;
        private PickupUtilityClass utility;

        public Star(Game1 game, Vector2 location)
        {
            starSprite = new StarSprite(game, this);
            myGame = game;
            pickupLocation = location;
            pickupOriginalLocation = location;
            physics = new StarPhysics(myGame,this/*,0*/);
            utility = new PickupUtilityClass();
        }

        public void Draw()
        {
            starSprite.Draw();
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
                starSprite.Update();
               
                utility.PickpupCyclePosition = 0;
            }
            if (pickupLocation.Y > pickupOriginalLocation.Y - /*17*/utility.BlockSize && !moving)
            {
                pickupLocation.Y --;
                IsFalling = true;
            }
            else
            {
                moving = true;
                physics.Update();
                falling = true;
            }
        }


        public void Collide()
        {
            movingRight = !movingRight;
        }

        public bool MovingRight()
        {
            return movingRight;
        }
    }
}
