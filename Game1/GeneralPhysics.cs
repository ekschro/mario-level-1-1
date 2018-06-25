using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class GeneralPhysics
    {
        private Game1 game;
        private IPlayer obj;
        private float delta;
        private int velCap;
        private float xVelocity;
        private float yVelocity;
        private float currentX;
        private float currentY;

        private bool prevUp;
        private bool prevRight;
        private bool prevLeft;
        private bool prevDown;

        public GeneralPhysics(Game1 game,IPlayer obj,int velCap)
        {
            this.game = game;
            this.obj = obj;

            this.velCap = velCap;
            xVelocity = 0;
            yVelocity = 0;

            prevUp = false;
            prevRight = false;
            prevLeft = false;
            prevDown = false;
        }

        public void Update(bool up, bool right, bool left, bool down)
        {
            delta = game.delta.ElapsedGameTime.Milliseconds;
            NewPosX(up, right, left, down);
        }

        public void NewPosX(bool up,bool right,bool left,bool down)
        {
            if (right)
            {
                xVelocity += (float)(0.5 * 0.01 * Math.Pow(delta, 2));
            }
            else
            {
                xVelocity = 0;
            }

            obj.CurrentXPos += xVelocity;
        }

        public int NewPosY(int currentY, bool up, bool right, bool left, bool down)
        {
            return 0;
        }


    }
}
