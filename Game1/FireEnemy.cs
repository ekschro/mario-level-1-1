using System;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class FireEnemy : IEnemy
    {
        Vector2 location2;
        Vector2 originalLocation;
        //Game1 myGame;
        float radius2;
        double angle;
        IEnemySprite fireEnemySprite;
        public FireEnemy(Game1 game, Vector2 location, float radius)
        {
            location2 = location;
            
            location2.X = location2.X + radius + 6;
            location2.Y = location2.Y + 6;
            originalLocation = new Vector2(location.X, location.Y);
            radius2 = radius;
            angle = 0;
            fireEnemySprite = new FireEnemySprite(game, this);
        }
        private bool movingRight = true;
        public bool MovingRight { get => movingRight; set => movingRight = value; }

        public IEnemyStateMachine StateMachine { get; }

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

        public bool Dead => true;

        public Vector2 GameObjectLocation => new Vector2(CurrentXPos, CurrentYPos);

        public void SetGameObjectLocation(Vector2 x)
        {
            location2 = x;
        }

        public void Update()
        {
            angle = angle + 0.015;
            location2.X = (float)(originalLocation.X + 4 + radius2 * Math.Cos(angle));
            location2.Y = (float)(originalLocation.Y + 4 + radius2 * Math.Sin(angle));
            
            fireEnemySprite.Update();

        }

        public void ChangeDirection(bool faceLeft)
        {
            throw new NotImplementedException();
        }
    }
}
