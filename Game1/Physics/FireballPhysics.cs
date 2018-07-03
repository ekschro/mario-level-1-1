using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace Game1
{
    class FireBallPhysics
    {
        //private const int JUMPCALLS = 17;

        private Game1 game;
        private float delta;
        private int velCap;
        private float xVelocity;
        private float yVelocity;
        private int counter;
        private MarioFireBall fire;

        public FireBallPhysics(Game1 game, int velCap, MarioFireBall fireball)
        {
            this.game = game;
            this.velCap = velCap;
            xVelocity = 0;
            yVelocity = 0;
            //counter = JUMPCALLS;
            fire = fireball;
            fireball.MovingUp = false;
        }

        public void Update()
        {
            delta = game.delta.ElapsedGameTime.Milliseconds;
            NewPosX();
            NewPosY();
        }

        public void NewPosX()
        {
            if (fire.MovingRight)
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
            else if (fire.MovingLeft)
            {
                if (Math.Abs(xVelocity) < velCap)
                {
                    xVelocity -= (float)(0.5 * 0.001 * Math.Pow(delta, 2));
                }
                else
                {
                    xVelocity = velCap;
                }
            }
            

            fire.CurrentXPos += xVelocity;
        }

        public void NewPosY()
        {
            if (fire.MovingUp)
            {
                yVelocity = (float)-4.5;
                fire.MovingUp = false;

            }
            else if (yVelocity < 3.5)
            {
                yVelocity += (float)(0.5 * 0.001 * Math.Pow(delta, 2));
            }


            fire.CurrentYPos += yVelocity;
            
        }
    }
}
*/