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

        private int cyclePosition = 0;
        private int cycleLength = 16;

        private IPickupSprite starSprite;
        private Game1 myGame;
        private Vector2 pickupLocation;
        private Vector2 pickupOriginalLocation;
        private bool movingRight;

        public Star(Game1 game, Vector2 location)
        {
            starSprite = new StarSprite(game, this);
            myGame = game;
            pickupLocation = location;
            pickupOriginalLocation = location;
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
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                starSprite.Update();
                cyclePosition = 0;
            }
            if (pickupLocation.Y > pickupOriginalLocation.Y - 16)
            {
                pickupLocation.Y -= 1;
            }
        }
        public void Picked()
        {
            starSprite = new EmptyPickupSprite(myGame, new EmptyPickup(myGame, pickupLocation));
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
