using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class GreenMushroom : IPickup
    {
        private int cyclePosition = 0;
        private int cycleLength = 16;

        public static GreenMushroomSprite greenMushroomSprite;

        public static GreenMushroomSprite GreenMushroomSprite { get => greenMushroomSprite; set => greenMushroomSprite = value; }

        private Game1 myGame;
        public Vector2 pickupLocation;

        public GreenMushroom(Game1 game, Vector2 location)
        {
            GreenMushroomSprite = new GreenMushroomSprite(game, this);
            myGame = game;
            pickupLocation = location;
        }

        public void Draw()
        {
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                cyclePosition = 0;
                GreenMushroomSprite.Draw();
            }
        }

        public Vector2 GetCurrentLocation()
        {
            return pickupLocation;
        }

        public void Update()
        {
            GreenMushroomSprite.Update();
        }
    }
}
