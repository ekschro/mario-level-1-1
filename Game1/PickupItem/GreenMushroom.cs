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
        private static IPickupSprite greenMushroomSprite;

        public static IPickupSprite GreenMushroomSprite { get => greenMushroomSprite; set => greenMushroomSprite = value; }

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
            GreenMushroomSprite.Draw();
        }

        public Vector2 GetCurrentLocation()
        {
            return pickupLocation;
        }

        public void Update()
        {
            GreenMushroomSprite.Update();
        }
        public void Picked()
        {
            GreenMushroomSprite = new EmptyPickupSprite(myGame, new EmptyPickup(myGame, pickupLocation));
        }
    }
}
