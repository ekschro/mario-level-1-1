using System;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class MarioFireBall : IEnemy
    {
        private Game1 myGame;
        private int currentFrame;
        public MarioFireBall(Game1 game)
        {
            myGame = game;
            xPos = Mario.CurrentXPosition;
            yPos = Mario.CurrentYPosition;
            if (Mario.MovingRight)
            {
                currentFrame = 2;
                MovingRight = true;
                MovingLeft = false;
            } else
            {
                currentFrame = 3;
                MovingLeft = true;
                MovingRight = false;
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
            fire.NewPosX();
            fire.NewPosY();
        }

        public Vector2 GameOriginalLocation()
        {
            throw new NotImplementedException();
        }

        public void ChangeDirection()
        {
            throw new NotImplementedException();
        }

        public void BeStomped()
        {
            throw new NotImplementedException();
        }

        public void BeFlipped()
        {
            throw new NotImplementedException();
        }

        public void Running()
        {
            throw new NotImplementedException();
        }

        public void ReachGround()
        {
            throw new NotImplementedException();
        }

        public void Falling()
        {
            throw new NotImplementedException();
        }

        public void SetGameObjectLocation(Vector2 x)
        {
            throw new NotImplementedException();
        }

        public bool GetDead()
        {
            throw new NotImplementedException();
        }

        public Vector2 GetGameObjectLocation()
        {
            throw new NotImplementedException();
        }
    }
}
