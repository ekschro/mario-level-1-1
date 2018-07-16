using System;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class MarioFireBall : IEnemy
    {
        private Game1 myGame;
        //private IControllerHandler controllerHandler;
        private IPlayer player;
        private bool falling;

        public bool IsFalling { get => falling; set => falling = value; }
        private int currentFrame;
        public MarioFireBall(Game1 game)
        {
            myGame = game;
            //controllerHandler = game.controllerHandler;
            player = game.CurrentLevel.PlayerObject;
            falling = true;
            SoundWarehouse.fireball.Play();

            if (!player.TestMario.GetStateMachine.FacingLeft())
            {
                currentFrame = 2;
                MovingRight = true;
                MovingLeft = false;
                xPos = player.CurrentXPos + 20;
                yPos = player.CurrentYPos + 8;
            } else
            {
                currentFrame = 3;
                MovingLeft = true;
                MovingRight = false;
                xPos = player.CurrentXPos - 4;
                yPos = player.CurrentYPos + 8;
            }
            yPosMax = yPos;
            MovingUp = true;
            MovingDown = false;

            physics = new FireballPhysics(game, this, 0);
           
        }
       
        private float xPos;
        private float yPos;
        private bool movingRight;
        private bool movingLeft;
        private bool movingUp;
        private bool movingDown;
        //private int xVelocity;
        //private int velCap;
        private float yPosMax;

        public float CurrentXPos { get => xPos; set => xPos = value; }
        public float CurrentYPos { get => yPos; set => yPos = value; }
        public bool MovingRight { get => movingRight; set => movingRight = value; }
        public bool MovingLeft { get => movingLeft; set => movingLeft = value; }
        public bool MovingUp { get => movingUp; set => movingUp = value; }
        public bool MovingDown { get => movingDown; set => movingDown = value; }

        private FireballPhysics physics;

        public IEnemyStateMachine GetStateMachine => throw new NotImplementedException();

        public bool IsStomped { get => true; set => stomped = value; }
        private bool stomped;
        public void Draw()
        {
            int width = TextureWarehouse.fireballs.Width / 4;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(CurrentXPos);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.fireballs.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)CurrentYPos, width, TextureWarehouse.fireballs.Height);


            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.fireballs, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
        /*
        public Vector2 GameObjectLocation()
        {
            return new Vector2(xPos, yPos);
        }
        */
        public void Update()
        {
            physics.Update();

            currentFrame++;
            if (currentFrame == 3)
            {
               currentFrame = 0;
            }
            if (yPos - yPosMax == -3)
                MovingUp = false;
            else
                MovingUp = true;
            
            /*if (MovingUp)
            {
                yPos = yPos - 1;
            } else
            {
                yPos = yPos + 1;
            }

            if (movingRight)
            {
                xPos = xPos + 5;
            } else
            {
                xPos = xPos - 5;
            }*/
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
        /*
        public void Running()
        {
            
        }
        
        public void ReachGround()
        {
            
        }

        public void Falling()
        {
            
        }
        */
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
