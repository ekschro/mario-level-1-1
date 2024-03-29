﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class EnemyPhysics : IPhysics
    {
        private Game1 game;
        private IEnemy obj;
        private float delta;
       
        private float xVelocity;
        private float yVelocity;

        public float XVelocity { get => xVelocity; }

        public EnemyPhysics(Game1 game,IEnemy obj,int velCap)
        {
            this.game = game;
            this.obj = obj;

           
            xVelocity = (float)0.5 * velCap;
            yVelocity = (float)0.5 * velCap;
        }

        public void Update()
        {
            delta = game.Delta.ElapsedGameTime.Milliseconds;
            NewPosX();
            NewPosY();
        }
        public void UpdateYPosition()
        {
            delta = game.Delta.ElapsedGameTime.Milliseconds;
            if (obj.IsFalling)
                yVelocity += (float)(0.5 * 0.002 * Math.Pow(delta, 2));
            obj.SetGameObjectLocation(new Vector2(obj.GameObjectLocation.X, obj.GameObjectLocation.Y));
        }

        public void NewPosX()
        {
            if (obj.StateMachine.Direction)
                obj.SetGameObjectLocation(new Vector2(obj.GameObjectLocation.X + xVelocity, obj.GameObjectLocation.Y));
            else
                obj.SetGameObjectLocation(new Vector2(obj.GameObjectLocation.X - xVelocity, obj.GameObjectLocation.Y));
        }

        public void NewPosY()
        {
            if (obj.IsFalling)
            {
                if (obj is Bowser)
                {
                    yVelocity += (float)(0.5 * 0.001 * Math.Pow(delta, 2));
                }
                else
                {
                yVelocity += (float)(0.5 * 0.002 * Math.Pow(delta, 2));
                }
            }
            else if (obj.IsJumping)
            {
                if (obj is Bowser)
                {
                    yVelocity = (float)-3;
                }
                else
                {
                    yVelocity = (float)-4.5;
                    yVelocity -= (float)(0.5 * 0.002 * Math.Pow(delta, 2));
                }
            }
            else
                yVelocity = (float)0;

            obj.SetGameObjectLocation(new Vector2(obj.GameObjectLocation.X,obj.GameObjectLocation.Y + yVelocity));
        }
    }
}
