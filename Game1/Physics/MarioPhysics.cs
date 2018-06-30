using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class MarioPhysics : IPhysics
    {

        private Game1 game;
        private float delta;
        private int velCap;
        private IPlayer player;
        private float xVelocity;
        private float yVelocity;

        public float XVelocity { get => xVelocity; }

        public MarioPhysics(Game1 game,int velCap)
        {
            this.game = game;
            this.velCap = velCap;
            player = game.CurrentLevel.PlayerObject;
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
            if (player.MovingRight)
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
            else if (player.MovingLeft)
            {
                if (Math.Abs(xVelocity) < velCap)
                {
                    xVelocity -= (float)(0.5 * 0.001 * Math.Pow(delta, 2));
                }
                else
                {
                    xVelocity = -1 * velCap;
                }

                if (player.CurrentXPosition < (game.CurrentLevel.LevelCamera.CameraPosition + 4))
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

            player.CurrentXPosition += xVelocity;
        }

        public void NewPosY()
        {
            if (player.MovingUp && player.CanJump && !player.Falling)
            {
                yVelocity = (float)-6.5;
                player.CanJump = false;
            }
            else if (!player.MovingUp && !player.Falling)
            {
                yVelocity = 1;
                player.Falling = true;
            }

            if (player.Bounce)
            {
                yVelocity = (float)-3.5;
                player.Bounce = false;
            }

            if (player.Bump)
            {
                yVelocity = 0;
                player.Falling = true;
                player.Bump = false;
            }
                

            yVelocity += (float)(0.5 * 0.002 * Math.Pow(delta, 2));
            player.CurrentYPosition += yVelocity;
        }
    }
}
