﻿using System;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class BowserFireBall : IEnemy
    {
        Vector2 location2;
        Vector2 originalLocation;
        Game1 myGame;
        float radius2;
        double angle;
        IEnemySprite fireEnemySprite;
        Bowser bowser2;
        bool facingRight;
        public BowserFireBall(Game1 game, Bowser bowser)
        {
            bowser2 = bowser;
            location2 = new Vector2(bowser2.CurrentXPos, bowser2.CurrentYPos);
            originalLocation = new Vector2(bowser2.CurrentXPos, bowser2.CurrentYPos);
            facingRight = bowser2.StateMachine.GetDirection();           
            myGame = game;
            
            
            fireEnemySprite = new BowserFireEnemySprite(game, this);
        }
        private bool movingRight = true;
        public bool MovingRight { get => movingRight; set => movingRight = value; }

        public IEnemyStateMachine StateMachine => throw new NotImplementedException();

        public bool IsFalling { get => false; set => throw new NotImplementedException(); }
        public bool IsStomped { get => false; set => throw new NotImplementedException(); }
        public float CurrentXPos { get => location2.X; set => location2.X = value; }
        public float CurrentYPos { get => location2.Y; set => location2.Y = value; }

        public bool IsJumping => false;

        public void BeFlipped()
        {

        }

        public void BeStomped()
        {

        }

        public void ChangeDirection()
        {

        }

        public void Draw()
        {
            fireEnemySprite.Draw();
        }

        public Vector2 GameOriginalLocation()
        {
            throw new NotImplementedException();
        }

        public bool GetDead()
        {
            return true;
        }

        public Vector2 GetGameObjectLocation()
        {
            return new Vector2(CurrentXPos, CurrentYPos);
        }

        public void SetGameObjectLocation(Vector2 x)
        {
            location2 = x;
        }

        public void Update()
        {
            if (facingRight)
            {
                location2.X = location2.X + 1;
            } else
            {
                location2.X = location2.X - 1;
            }
           
            fireEnemySprite.Update();

        }

        public void ChangeDirection(bool faceLeft)
        {
            throw new NotImplementedException();
        }
    }
}
