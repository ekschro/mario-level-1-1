using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class EmptyPickup : IPickup
    {
        private static IPickupSprite emptySprite;

        public static IPickupSprite EmptySprite { get => emptySprite; set => emptySprite = value; }

        private Game1 myGame;
        public Vector2 pickupLocation;

        public EmptyPickup(Game1 game, Vector2 location)
        {
            EmptySprite = new EmptyPickupSprite(game, this);
            myGame = game;
            pickupLocation = location;
        }

        public void Draw()
        {
            EmptySprite.Draw();
        }

        public Vector2 GameObjectLocation()
        {
            return pickupLocation;
        }

        public void Update()
        {
        }
        public void Picked()
        { }
    }
}
