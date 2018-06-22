using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Physics
    {
        private Game1 game;
        //private GameTime delta;

        private int velCap;
        private int xVelocity;
        private int yVelocity;

        private bool prevUp;
        private bool prevRight;
        private bool prevLeft;
        private bool prevDown;

        public Physics(Game1 game,int velCap)
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

        public void Update(GameTime gameTime)
        {
            var delta = gameTime.ElapsedGameTime.TotalSeconds;
        }

        public int NewPosX(int currentX,bool up,bool right,bool left,bool down)
        {
            //xVelocity += 0.5 * 1 * delta ^ 2;

            //return (int)(currentX + delta*xVelocity);
            return 0;
        }

        public int NewPosY(int currentY, bool up, bool right, bool left, bool down)
        {
            return 0;
        }


    }
}
