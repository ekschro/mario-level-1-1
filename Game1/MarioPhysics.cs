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

        public float XVelocity { get => xVelocity; set => xVelocity = value; }

        public MarioPhysics(Game1 game,int velCap)
        {
            this.game = game;
            this.velCap = velCap;
            XVelocity = 0;
            yVelocity = 0;
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
                if (XVelocity < velCap)
                {
                    XVelocity += (float)(0.5 * 0.001 * Math.Pow(delta, 2));
                }
                else
                {
                    XVelocity = velCap;
                }
            }
            else if (Mario.MovingLeft)
            {
                if (Math.Abs(XVelocity) < velCap)
                {
                    XVelocity -= (float)(0.5 * 0.001 * Math.Pow(delta, 2));
                }
                else
                {
                    XVelocity = -1 * velCap;
                }

                if (Mario.CurrentXPosition < (game.CurrentLevel.LevelCamera.CameraPosition + 4))
                    XVelocity = 0;
            }
            else
            {
                if (Math.Abs(XVelocity) < 0.2)
                {
                    XVelocity = 0;
                }
                else if (XVelocity < 0)
                {
                    XVelocity += (float)(0.5 * 0.001 * Math.Pow(delta, 2));
                }
                else if (XVelocity > 0)
                {
                    XVelocity -= (float)(0.5 * 0.001 * Math.Pow(delta, 2));
                }

            }

            Mario.CurrentXPosition += XVelocity;
        }

        public void NewPosY()
        {
            if (Mario.MovingUp && Mario.CanJump && !Mario.Falling)
            {
                yVelocity = (float)-6.5;
                Mario.CanJump = false;
            }
            else if (!Mario.MovingUp && !Mario.Falling)
            {
                yVelocity = 1;
                Mario.Falling = true;
            }

            if (Mario.Bounce)
            {
                yVelocity = (float)-3.5;
                Mario.Bounce = false;
            }

            if (Mario.Bump)
            {
                yVelocity = 0;
                Mario.Falling = true;
                Mario.Bump = false;
            }
                

            yVelocity += (float)(0.5 * 0.002 * Math.Pow(delta, 2));
            Mario.CurrentYPosition += yVelocity;
        }
    }
}
