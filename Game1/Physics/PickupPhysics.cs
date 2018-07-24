using Microsoft.Xna.Framework;
using System;

namespace Game1
{
        class PickupPhysics : IPhysics
    {
            private Game1 game;
            private IPickup obj;
            private float delta;
            
            private float xVelocity;
            private float yVelocity;

        public float XVelocity { get => xVelocity; }

        public PickupPhysics(Game1 game, IPickup obj)
            {
                this.game = game;
                this.obj = obj;

               
                xVelocity = (float)1;
                yVelocity = (float)0;
            }

            public void Update()
            {
                delta = game.Delta.ElapsedGameTime.Milliseconds;
                NewPosX();
                NewPosY();
            }

            public void NewPosX()
            {
                if (obj.MovingRight())
                    obj.SetGameObjectLocation(new Vector2(obj.GetGameObjectLocation().X - xVelocity, obj.GetGameObjectLocation().Y));
                else
                    obj.SetGameObjectLocation(new Vector2(obj.GetGameObjectLocation().X + xVelocity, obj.GetGameObjectLocation().Y));
            }

            public void NewPosY()
            {
                if (obj.IsFalling)
                    yVelocity += (float)(0.5 * 0.002 * Math.Pow(delta, 2));
                else
                    yVelocity = (float)0;

                obj.SetGameObjectLocation(new Vector2(obj.GetGameObjectLocation().X, obj.GetGameObjectLocation().Y + yVelocity));
            }
        }
    }
