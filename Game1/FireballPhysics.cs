﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class FireballPhysics : IPhysics
    {
        private Game1 game;
        private IEnemy obj;
        private float delta;
        
        private float xVelocity;
        private float yVelocity;

        public float XVelocity { get => xVelocity; }

        public FireballPhysics(Game1 game, IEnemy obj)
        {
            this.game = game;
            this.obj = obj;

           
            xVelocity = (float)5;
            yVelocity = (float)-3;

            obj.IsFalling = true;
        }

        public void Update()
        {
            delta = game.Delta.ElapsedGameTime.Milliseconds;
            NewPosX();
            NewPosY();
        }

        public void NewPosX()
        {
            if (obj.MovingRight)
                obj.SetGameObjectLocation(new Vector2(obj.GameObjectLocation.X + xVelocity, obj.GameObjectLocation.Y));
            else
                obj.SetGameObjectLocation(new Vector2(obj.GameObjectLocation.X - xVelocity, obj.GameObjectLocation.Y));
        }

        public void NewPosY()
        {
            if (obj.IsFalling)
            {
                yVelocity += (float)(0.5 * 0.005 * Math.Pow(delta, 2));
            }
            else
            {
                yVelocity = (float)-4.5;
                obj.IsFalling = true;
            }

            obj.SetGameObjectLocation(new Vector2(obj.GameObjectLocation.X, obj.GameObjectLocation.Y + yVelocity));
        }
    }
}
