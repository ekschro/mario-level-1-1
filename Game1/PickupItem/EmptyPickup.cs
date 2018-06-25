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
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IPickupSprite emptySprite;

        //private Game1 myGame;
        private Vector2 pickupLocation;

        public EmptyPickup(Game1 game, Vector2 location)
        {
            emptySprite = new EmptyPickupSprite(game, this);
            //myGame = game;
            pickupLocation = location;
        }

        public void Draw()
        {
            emptySprite.Draw();
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
