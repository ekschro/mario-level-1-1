using System;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class MarioFireBall : IEnemy
    {
        private Game1 myGame;
        private bool falling;
        public bool IsFalling { get => falling; set => falling = value; }
        public IEnemyStateMachine GetStateMachine { get; }
        private int currentFrame;
        public bool IsStomped { get; set; }

        public MarioFireBall(Game1 game)
        {
            myGame = game;
            
            
            if (Mario.MovingRight)
            {
                currentFrame = 2;
                MovingRight = true;
                MovingLeft = false;
                xPos = Mario.CurrentXPosition + 20;
                yPos = Mario.CurrentYPosition + 16;
            } else
            {
                currentFrame = 3;
                MovingLeft = true;
                MovingRight = false;
                xPos = Mario.CurrentXPosition - 20;
                yPos = Mario.CurrentYPosition + 16;
            }
            MovingUp = false;
            MovingDown = false;
            fire = new FireBallPhysics(myGame, 2, this);
        }
        FireBallPhysics fire;
        private float xPos;
        private float yPos;
        private bool movingRight;
        private bool movingLeft;
        private bool movingUp;
        private bool movingDown;
        private int xVelocity;
        private int velCap;

        public float CurrentXPos { get => xPos; set => xPos = value; }
        public float CurrentYPos { get => yPos; set => yPos = value; }
        public bool MovingRight { get => movingRight; set => movingRight = value; }
        public bool MovingLeft { get => movingLeft; set => movingLeft = value; }
        public bool MovingUp { get => movingUp; set => movingUp = value; }
        public bool MovingDown { get => movingDown; set => movingDown = value; }

        public void Draw()
        {
            int width = TextureWareHouse.fireballs.Width / 4;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(CurrentXPos);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)CurrentYPos, width, TextureWareHouse.fireballs.Height);


            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }

        public Vector2 GameObjectLocation()
        {
            return new Vector2(xPos, yPos);
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == 3)
            {
               currentFrame = 0;
            }
            fire.Update();
        }
        

        public Vector2 GameOriginalLocation()
        {
            return new Vector2(this.CurrentXPos, this.CurrentYPos);
        }

        public void ChangeDirection()
        {
           
        }

        public void BeStomped()
        {
           
        }

        public void BeFlipped()
        {
            
        }

        public void Running()
        {
            
        }

        public void ReachGround()
        {
            
        }

        public void Falling()
        {
            
        }
        public void SetGameObjectLocation(Vector2 vector)
        {
            CurrentXPos = vector.X;
            CurrentYPos = vector.Y;
        }
        public bool GetDead()
        {
            return false;
        }
        public Vector2 GetGameObjectLocation()
        {
            return new Vector2(CurrentXPos, CurrentYPos);
        }
    }
}
