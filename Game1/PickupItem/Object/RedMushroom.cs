using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class RedMushroom : IPickup
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private bool falling;
        public bool IsFalling { get => falling; set => falling = value; }

        private static IPickupSprite redMushroomSprite;

        private Game1 myGame;
        private Vector2 pickupLocation;
        private Vector2 pickupOriginalLocation;
        private IPhysics physics;
        private bool moving = false;
        private bool movingRight;

        public RedMushroom(Game1 game, Vector2 location)
        {
            redMushroomSprite = new RedMushroomSprite(game, this);
            myGame = game;
            pickupLocation = location;
            pickupOriginalLocation = location;
            physics = new PickupPhysics(myGame, this);
        }

        public void Draw()
        {
            redMushroomSprite.Draw();  
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
            redMushroomSprite.Update();
            if (pickupLocation.Y > pickupOriginalLocation.Y - 16 && !moving)
            {
                pickupLocation.Y -= (float)1;
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
