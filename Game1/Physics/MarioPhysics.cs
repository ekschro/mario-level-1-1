using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class MarioPhysics : IPhysics
    {

        private Game1 game;
        private IControllerHandler controllerHandler;
        private float delta;
        private int velCap;
        private IPlayer player;
        private float xVelocity;
        private float yVelocity;

        private int runVelCap;
        private int walkVelCap;
        private bool isRunning;

        public float XVelocity { get => xVelocity; }

        public MarioPhysics(Game1 game, Mario player, int velCap)
        {
            this.game = game;
            controllerHandler = game.controllerHandler;
            this.velCap = velCap;
            this.player = player;
            xVelocity = 0;
            yVelocity = 0;

            walkVelCap = velCap;
            runVelCap = velCap * 2;
        }

        public void Update()
        {
            delta = game.delta.ElapsedGameTime.Milliseconds;
            NewPosX();
            NewPosY();
            RunningHandler();
        }

        public void NewPosX()
        {
            if (controllerHandler.MovingRight && !controllerHandler.MovingDown)
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
            else if (controllerHandler.MovingLeft && !controllerHandler.MovingDown)
            {
                if (Math.Abs(xVelocity) < velCap)
                {
                    xVelocity -= (float)(0.5 * 0.001 * Math.Pow(delta, 2));
                }
                else
                {
                    xVelocity = -1 * velCap;
                }

                if (player.CurrentXPos < (game.CurrentLevel.LevelCamera.CameraPosition + 4))
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

            player.CurrentXPos += xVelocity;
        }

        public void NewPosY()
        {
            if (controllerHandler.MovingUp && player.CanJump && !player.Falling)
            {
                yVelocity = (float)-6.5;
                player.CanJump = false;
            }
            else if (!controllerHandler.MovingUp && !player.Falling)
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
            player.CurrentYPos += yVelocity;
        }

        public void RunningHandler()
        {
            velCap = walkVelCap;
        }

        public void RunningCheck()
        {
            velCap = runVelCap;
        }
    }
}
