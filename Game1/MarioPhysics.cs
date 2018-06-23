using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class MarioPhysics
    {
        private Game1 game;
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

        public MarioPhysics(Game1 game,int velCap)
        {
            this.game = game;
            this.velCap = velCap;
            xVelocity = 0;
            yVelocity = 0;

            prevUp = false;
            prevRight = false;
            prevLeft = false;
            prevDown = false;
        }

        public void Update()
        {
            delta = game.delta.ElapsedGameTime.Milliseconds;
            NewPosX();
            Console.WriteLine(Mario.MovingRight);
        }

        public void NewPosX()
        {
            if (Mario.MovingRight)
            {
                xVelocity += (float)(0.5 * 0.01 * Math.Pow(delta, 2));
            }
            if (!Mario.MovingRight)
            {
                xVelocity = 0;
            }

            Mario.CurrentXPosition += xVelocity;
        }

        public int NewPosY()
        {
            return 0;
        }


    }
}
