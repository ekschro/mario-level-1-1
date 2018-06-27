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

        private static IPickupSprite redMushroomSprite;

        private Game1 myGame;
        private Vector2 pickupLocation;
        private Vector2 pickupOriginalLocation;

        public RedMushroom(Game1 game, Vector2 location)
        {
            redMushroomSprite = new RedMushroomSprite(game, this);
            myGame = game;
            pickupLocation = location;
            pickupOriginalLocation = location;
        }

        public void Draw()
        {
            redMushroomSprite.Draw();  
        }

        public Vector2 GameObjectLocation()
        {
            return pickupLocation;
        }

        public void Update()
        {
            redMushroomSprite.Update();
            if (pickupLocation.Y > pickupOriginalLocation.Y - 16)
            {
                pickupLocation.Y -= 1;
            }
        }
        public void Picked()
        {
            redMushroomSprite = new EmptyPickupSprite(myGame, new EmptyPickup(myGame, pickupLocation));
        }

        public void Collide()
        {
            throw new NotImplementedException();
        }
    }
}
