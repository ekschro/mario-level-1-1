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

        private static IPickupSprite starSprite;

        public static IPickupSprite StarSprite { get => starSprite; set => starSprite = value; }

        private Game1 myGame;
        public Vector2 pickupLocation;

        public Star(Game1 game, Vector2 location)
        {
            StarSprite = new StarSprite(game, this);
            myGame = game;
            pickupLocation = location;
        }

        public void Draw()
        {
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                cyclePosition = 0;
                StarSprite.Draw();
            }
        }

        public Vector2 GetCurrentLocation()
        {
            return pickupLocation;
        }

        public void Update()
        {
            StarSprite.Update();
        }
    }
}
