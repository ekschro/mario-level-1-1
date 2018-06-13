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
        private static IPickupSprite redMushroomSprite;

        public static IPickupSprite RedMushroomSprite { get => redMushroomSprite; set => redMushroomSprite = value; }

        private Game1 myGame;
        public Vector2 pickupLocation;

        public RedMushroom(Game1 game, Vector2 location)
        {
            RedMushroomSprite = new RedMushroomSprite(game, this);
            myGame = game;
            pickupLocation = location;
        }

        public void Draw()
        {
            RedMushroomSprite.Draw();  
        }

        public Vector2 GetCurrentLocation()
        {
            return pickupLocation;
        }

        public void Update()
        {
            RedMushroomSprite.Update();
        }
    }
}
