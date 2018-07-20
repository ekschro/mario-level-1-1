using System;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class FireEnemyChain : IEnemy
    {
        Vector2 location2;
        Game1 myGame;
        float radius2 = 0;
        IEnemy []fireEnemy = new IEnemy[5];
        public FireEnemyChain(Game1 game, Vector2 location)
        {
            for(int i = 0; i < 5; i++)
            {
                fireEnemy[i] = new FireEnemy(game, location, radius2);
                radius2 = radius2 + 2;
            }
        }
        private bool movingRight = true;
        public bool MovingRight { get => movingRight; set => movingRight = value; }

        public IEnemyStateMachine StateMachine => throw new NotImplementedException();

        public bool IsFalling { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsStomped { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float CurrentXPos { get => location2.X; set => location2.X = value; }
        public float CurrentYPos { get => location2.Y; set => location2.Y = value; }

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
            throw new NotImplementedException();
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
            for(int i = 0; i < 5; i++)
            {
                fireEnemy[i].Update();
            }
        }
    }
}
