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
        private int cyclePosition = 0;
        private int cycleLength = 16;

        private IPickupSprite starSprite;
        private Game1 myGame;
        private Vector2 pickupLocation;
        private Vector2 pickupOriginalLocation;
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

        public Vector2 GameObjectLocation()
        {
            return pickupLocation;
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
    }
}
