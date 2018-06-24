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
        private int timer;

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
            NewPosY();
        }

        public void NewPosX()
        {
            if (Mario.MovingRight)
            {
                if (xVelocity < velCap)
                {
                    xVelocity += (float)(0.5 * 0.001 * Math.Pow(delta, 2));
                }
                else
                {
                    xVelocity = velCap;
                }
            }
            else if (Mario.MovingLeft)
            {
                if (Math.Abs(xVelocity) < velCap)
                {
                    xVelocity -= (float)(0.5 * 0.001 * Math.Pow(delta, 2));
                }
                else
                {
                    xVelocity = -1*velCap;
                }
            }
            else
            {
                xVelocity = 0;
            }

            Mario.CurrentXPosition += xVelocity;
        }

        public void NewPosY()
        {
            if(Mario.MovingUp)
            {
                yVelocity = -6;
            }
            else if (yVelocity < 0)
            {
                yVelocity += (float)(0.5 * 0.001 * Math.Pow(delta, 2));
            }
            else
            {
                yVelocity = 1;
            }

            prevUp = Mario.MovingUp;
            Mario.CurrentYPosition += yVelocity;
        }


    }
}
