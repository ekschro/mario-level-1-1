﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class GreenMushroom : IPickup
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private bool falling;
        public bool IsFalling { get => falling; set => falling = value; }

        private IPickupSprite greenMushroomSprite;
        private Game1 myGame;
        private Vector2 pickupLocation;
        private Vector2 pickupOriginalLocation;
        private IPhysics physics;
        private bool movingRight;
        private bool moving;
        private PickupUtilityClass utility;

        public GreenMushroom(Game1 game, Vector2 location)
        {
            greenMushroomSprite = new GreenMushroomSprite(game, this);
            myGame = game;
            pickupLocation = location;
            pickupOriginalLocation = location;

            physics = new PickupPhysics(myGame, this, 2);
            utility = new PickupUtilityClass();
        }

        public void Draw()
        {
            greenMushroomSprite.Draw();
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
            greenMushroomSprite.Update();
            if (pickupLocation.Y > pickupOriginalLocation.Y - utility.BlockSize && !moving)
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
        public void Picked()
        {
            //greenMushroomSprite = new EmptyPickupSprite(myGame, new EmptyPickup(myGame, pickupLocation));
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
