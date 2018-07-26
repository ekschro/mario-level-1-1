using System;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class BowserFireBall : IEnemy
    {
        Vector2 location2;
        Vector2 originalLocation;
        //Game1 myGame;
        IEnemySprite fireEnemySprite;
        Bowser bowser2;
        private int currentFrame;
        bool facingRight;
        private bool dummyBool;
        public BowserFireBall(Game1 game, Bowser bowser)
        {
            bowser2 = bowser;
            location2 = new Vector2(bowser2.CurrentXPos - 34, bowser2.CurrentYPos);
            originalLocation = new Vector2(bowser2.CurrentXPos - 34, bowser2.CurrentYPos);
            facingRight = bowser2.StateMachine.Direction;           
           // myGame = game;
            CurrentFrame = 0;

            Console.WriteLine("Fire!");

            SoundWarehouse.bowserFire.Play();

            fireEnemySprite = new BowserFireEnemySprite(game, this);
            if (facingRight)
            {
                fireEnemySprite.ChangeSpriteEffects(Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipHorizontally);
                location2 = new Vector2(bowser2.CurrentXPos + 67, bowser2.CurrentYPos);
                originalLocation = new Vector2(bowser2.CurrentXPos + 67, bowser2.CurrentYPos);
            }
        }
        private bool movingRight = true;
        public bool MovingRight { get => movingRight; set => movingRight = value; }

        public IEnemyStateMachine StateMachine { get; }

        public bool IsFalling { get => false; set => dummyBool = value; }
        public bool IsStomped { get => false; set => dummyBool = value; }
        public float CurrentXPos { get => location2.X; set => location2.X = value; }
        public float CurrentYPos { get => location2.Y; set => location2.Y = value; }

        public bool IsJumping => false;

        public int CurrentFrame { get => currentFrame; set => currentFrame = value; }

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
            return originalLocation;
        }

        public bool Dead => false;

        public Vector2 GameObjectLocation => new Vector2(CurrentXPos, CurrentYPos);

        public void SetGameObjectLocation(Vector2 x)
        {
            
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
            CurrentFrame++;
            if (CurrentFrame == 2)
            {
                CurrentFrame = 0;
            }
            fireEnemySprite.Update();

        }

        public void ChangeDirection(bool faceLeft)
        {
            
        }
    }
}
