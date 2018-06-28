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

        public MarioPhysics(Game1 game,int velCap)
        {
            this.game = game;
            this.velCap = velCap;
            xVelocity = 0;
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
                    xVelocity = -1 * velCap;
                }

                if (Mario.CurrentXPosition < (game.CurrentLevel.LevelCamera.CameraPosition + 4))
                    xVelocity = 0;
            }
            else
            {
                if (Math.Abs(xVelocity) < 0.2)
                {
                    xVelocity = 0;
                }
                else if (xVelocity < 0)
                {
                    xVelocity += (float)(0.5 * 0.001 * Math.Pow(delta, 2));
                }
                else if (xVelocity > 0)
                {
                    xVelocity -= (float)(0.5 * 0.001 * Math.Pow(delta, 2));
                }

            }

            Mario.CurrentXPosition += xVelocity;
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

            yVelocity += (float)(0.5 * 0.002 * Math.Pow(delta, 2));
            Mario.CurrentYPosition += yVelocity;
        }
    }
}
