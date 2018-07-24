using System;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class FireEnemy : IEnemy
    {
        Vector2 location2;
        Vector2 originalLocation;
        Game1 myGame;
        float radius2;
        double angle;
        IEnemySprite fireEnemySprite;
        public FireEnemy(Game1 game, Vector2 location, float radius)
        {
            location2 = location;
            originalLocation = location;
            location2.X = location2.X + radius;
            myGame = game;
            radius2 = radius;
            angle = 0;
            fireEnemySprite = new FireEnemySprite(game, this);
        }
        private bool movingRight = true;
        public bool MovingRight { get => movingRight; set => movingRight = value; }

        public IEnemyStateMachine StateMachine => throw new NotImplementedException();

        public bool IsFalling { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsStomped { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float CurrentXPos { get => location2.X; set => location2.X = value; }
        public float CurrentYPos { get => location2.Y; set => location2.Y = value; }

        public bool IsJumping => throw new NotImplementedException();

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
            throw new NotImplementedException();
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
            angle = angle + 0.01;
            location2.X = (float)(originalLocation.X + radius2 * Math.Cos(angle));
            location2.Y = (float)(originalLocation.Y + radius2 * Math.Sin(angle));
            if (angle > 2 * Math.PI)
            {
                angle = 0;
                location2 = originalLocation;
            }
            fireEnemySprite.Update();

        }

        public void ChangeDirection(bool faceLeft)
        {
            throw new NotImplementedException();
        }
    }
}
