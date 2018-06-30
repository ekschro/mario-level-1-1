using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class StarPhysics
    {
        private Game1 game;
        private IPickup obj;
        private float delta;
        private int velCap;
        private float xVelocity;
        private float yVelocity;

        public StarPhysics(Game1 game, IPickup obj, int velCap)
        {
            this.game = game;
            this.obj = obj;

            this.velCap = velCap;
            xVelocity = (float)1;
            yVelocity = (float)-5;

            obj.IsFalling = true;
        }

        public void Update()
        {
            delta = game.delta.ElapsedGameTime.Milliseconds;
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
            {
                yVelocity += (float)(0.5 * 0.002 * Math.Pow(delta, 2));
            }
            else
            {
                yVelocity = (float)-4;
                obj.IsFalling = true;
            }

            obj.SetGameObjectLocation(new Vector2(obj.GetGameObjectLocation().X, obj.GetGameObjectLocation().Y + yVelocity));
        }
    }
}
