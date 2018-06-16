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

        public IPickupSprite starSprite;

        //public static IPickupSprite StarSprite { get => starSprite; set => starSprite = value; }

        private Game1 myGame;
        public Vector2 pickupLocation;

        public Star(Game1 game, Vector2 location)
        {
            starSprite = new StarSprite(game, this);
            myGame = game;
            pickupLocation = location;
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
        }
        public void Picked()
        {
            starSprite = new EmptyPickupSprite(myGame, new EmptyPickup(myGame, pickupLocation));
        }
    }
}
