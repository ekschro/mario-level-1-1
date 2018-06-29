﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class Goomba : IEnemy
    {
        public float CurrentXPos { get => goombaLocation.X; set => goombaLocation.X = value; }
        public float CurrentYPos { get => goombaLocation.Y; set => goombaLocation.Y = value; }
        private bool falling;
        public bool IsFalling { get => falling; set => falling = value; }
        private IEnemySprite goombaSprite;
        public IEnemySprite GoombaSprite { get => goombaSprite; set => goombaSprite = value; }
        public GoombaStateMachine stateMachine;
        public IEnemyStateMachine GetStateMachine { get => stateMachine; }
        private int cyclePosition = 0;
        private int cycleLength = 8;
        private Vector2 goombaLocation;
        private Vector2 goombaOriginalLocation;
        public bool IsStomped { get; set; }

        private bool dead = false;
        private GeneralPhysics physics;

        public Goomba(Game1 game, Vector2 location)
        {
            goombaLocation = location;
            goombaOriginalLocation = location;
            GoombaSprite = new GoombaSprite(game, this);
            stateMachine = new GoombaStateMachine(GoombaSprite);
            physics = new GeneralPhysics(game,this,1);
            falling = true;
        }

        public void BeFlipped()
        {
            stateMachine.BeFlipped();
            dead = true;
        }
        public void BeStomped()
        {
            stateMachine.BeStomped();
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection(); 
        }

        public void Draw()
        {
            GoombaSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return goombaLocation;
        }
        public void SetGameObjectLocation(Vector2 newPos)
        {
            goombaLocation = newPos;
        }

        public Vector2 GameOriginalLocation()
        {
            return goombaOriginalLocation;
        }
        public void Update()
        {
            physics.Update();
            falling = true;
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                cyclePosition = 0;
                stateMachine.Update();
                GoombaSprite.Update();
                if (dead)
                {
                    //goombaLocation.Y += 1;
                }
            }
        }

        public bool GetDead()
        {
            return dead;
        }

    }
}
