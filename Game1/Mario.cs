using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class Mario : IPlayer
    {
        private IControllerHandler controllerHandler;
        private Game1 myGame;
        private int animationTimer;
        private ITestMario testMario;
        //private static ISprite playerSprite;
        public static IPhysics physics;
        private static Color marioColor;
        private static float currentXPosition;
        private static float currentYPosition;
        private static int totalMarioColumns = 28;
        private static int totalMarioRows = 3;
        private static int colorStartingTime;
        private static int colorTimer;
        private static int fireballTimer;

        private static bool isStar = false;
        private static bool invulnerability = false;

        //public ISprite MarioSprite { get => playerSprite; set => playerSprite = value; }
        public Color MarioColor { get => marioColor; set => marioColor = value; }
        public float CurrentXPos { get => currentXPosition; set => currentXPosition = value; }
        public float CurrentYPos { get => currentYPosition; set => currentYPosition = value; }
        public bool Jumping { get; set; }
        public bool Falling { get; set; }
        public bool Bump { get; set; }
        public bool Bounce { get; set; }
       
        private bool play;

        public bool CanJump { get; set; }
        public bool IsStar { get => isStar; set => isStar = value; }
        public bool Invulnerability { get => invulnerability; set => invulnerability = value; }
        public int TotalMarioRows { get => totalMarioRows; set => totalMarioRows = value; }
        public int TotalMarioColumns { get => totalMarioColumns; set => totalMarioColumns = value; }
        public int FireBallTimer { get => fireballTimer; set => fireballTimer = value; }
        public ITestMario TestMario { get => testMario; set => testMario = value; }

        public Mario(Game1 game, Vector2 vector)
        {
            myGame = game;
            controllerHandler = game.controllerHandler;
            physics = new MarioPhysics(game,this,2);
            CurrentXPos = vector.X;
            CurrentYPos = vector.Y;
            MarioColor = Color.White;
            
            colorStartingTime = 5;
            colorTimer = 0;
            animationTimer = 0;
            fireballTimer = 0;
            testMario = new TestSmallMario(game, vector, this);
            CanJump = true;
            Falling = false;
            Bounce = false;
            play = true;
        }

        public void Draw()
        {
            ColorSelect();
            testMario.Draw();
        }

        public void Update()
        {
            if (!(testMario is TestDeadMario))
            {
                physics.Update();
                if (physics.XVelocity == 0 && testMario.GetStateMachine.IsWalking())
                {
                    testMario.GetStateMachine.ChangeState();
                }
                testMario.Update();
            }

            /*

            if (controllerHandler.MovingDown)
            {
                DownAnimation();
            }
            if (controllerHandler.MovingRight && !controllerHandler.MovingUp)
            {
                RightAnimation();
            }
            if (controllerHandler.MovingLeft && !controllerHandler.MovingUp)
            {
                LeftAnimation();
            }
            if(controllerHandler.MovingUp)
            {
                UpAnimation();
                /* if (play)
                {
                    SoundWarehouse.jump.Play();
                    play = false;
                } * /
            }

            */
           //if (CanJump)
                //play = true;

            if (fireballTimer > 0)
                fireballTimer--;
        }

        /*

        private void RightAnimation()
        {
            if (animationTimer == 5)
            {
                //this.MarioSprite.RightCommandCalled();
                this.TestMario.WalkRight();
                animationTimer = 0;
            } else
            {
                animationTimer++;
            }
        }

        private void UpAnimation()
        {
            if (animationTimer == 5)
            {
                //this.MarioSprite.UpCommandCalled();
                this.TestMario.Jumping();
                animationTimer = 0;
            }
            else
            {
                animationTimer++;
            }
        }

        private void DownAnimation()
        {
            if (animationTimer == 5)
            {
                //this.MarioSprite.DownCommandCalled();
                this.TestMario.Crouching();
                animationTimer = 0;
            }
            else
            {
                animationTimer++;
            }
        }

        private void LeftAnimation()
        {
            if (animationTimer == 5)
            {
                //this.MarioSprite.LeftCommandCalled();
                this.TestMario.WalkLeft();
                animationTimer = 0;
            }
            else
            {
                animationTimer++;
            }
        }

        */

        public Vector2 GetGameObjectLocation()
        {
            return new Vector2(currentXPosition, currentYPosition);
        }

        public void ColorSelect()
        {
            if (isStar && colorTimer == 0)
            {
                if (MarioColor == Color.White)
                    MarioColor = Color.Red;
                else if (MarioColor == Color.Red)
                    MarioColor = Color.LightBlue;
                else if (MarioColor == Color.LightBlue)
                    MarioColor = Color.LimeGreen;
                else if (MarioColor == Color.LimeGreen)
                    MarioColor = Color.Red;

                colorTimer = colorStartingTime;
            }
            else if (Invulnerability && colorTimer == 0)
            {
                if(MarioColor == Color.White)
                    MarioColor = Color.Transparent;
                else
                    MarioColor = Color.White;
                colorTimer = colorStartingTime;
            }
            else if (colorTimer > 0)
                colorTimer--;
            else
            {
                MarioColor = Color.White;
            }
        }
    }
}
