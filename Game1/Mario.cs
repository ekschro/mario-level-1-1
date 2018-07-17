using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
namespace Game1
{
    public class Mario : IPlayer
    {
        private IControllerHandler controllerHandler;
        private Game1 myGame;
        //private int animationTimer;
        private int killedNum = 0;
        private ITestMario testMario;
        //private static ISprite playerSprite;
        public static MarioPhysics physics;
        private static Color marioColor;
        private static float currentXPosition;
        private static float currentYPosition;
        private static int totalMarioColumns = 28;
        private static int totalMarioRows = 3;
        private static int colorStartingTime;
        private static int colorTimer;
        private int fireballTimer;
        private bool isStar = false;
        private bool invulnerability = false;

        //public ISprite MarioSprite { get => playerSprite; set => playerSprite = value; }
        public Color MarioColor { get => marioColor; set => marioColor = value; }
        public float CurrentXPos { get => currentXPosition; set => currentXPosition = value; }
        public float CurrentYPos { get => currentYPosition; set => currentYPosition = value; }
        public bool Jumping { get; set; }
        public bool Falling { get; set; }
        public bool Bump { get; set; }
        public bool Bounce { get; set; }
        private bool play;
        private bool starStopped = false;

        public bool CanJump { get; set; }
        public bool IsStar { get => isStar; set => isStar = value; }
        public bool Invulnerability { get => invulnerability; set => invulnerability = value; }
        public int TotalMarioRows { get => totalMarioRows; set => totalMarioRows = value; }
        public int TotalMarioColumns { get => totalMarioColumns; set => totalMarioColumns = value; }
        public int FireBallTimer { get => fireballTimer; set => fireballTimer = value; }
        public int KilledNum { get => killedNum; set => killedNum = value; }
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
            //animationTimer = 0;
            fireballTimer = 0;
            testMario = new TestSmallMario(game, vector, this);
            CanJump = true;
            Falling = false;
            Bounce = false;
            //play = true;
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
                testMario.Update();
                physics.Update();
                if (physics.XVelocity == 0 && testMario.StateMachine.IsWalking())
                {
                    testMario.StateMachine.ChangeState();
                }
                testMario.Update();
            }

            if (controllerHandler.MovingUp)
            {
                if (play)
                {
                    var j = SoundWarehouse.jump.CreateInstance();
                    j.Volume = 0.07f;
                    j.Play();
                    play = false;
                }
            }

            if (CanJump)
                play = true;

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

            /*
        public void Pipe(bool enter)
        {
            testMario.Pipe(enter);
        }
        public void EnterSidePipe(bool left)
        {
            testMario.SidePipe(left);
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
                starStopped = true;
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
               
                if (MarioColor == Color.White)
                    MarioColor = Color.Transparent;
                else
                    MarioColor = Color.White;
                colorTimer = colorStartingTime;
            }
            else if (colorTimer > 0)
                colorTimer--;
            else if (!isStar && colorTimer == 0 && starStopped)
            {
                MediaPlayer.Play(SoundWarehouse.main_theme);
                starStopped = false;
            }
            else
            {
                MarioColor = Color.White;
            }
        }

        public void Stop()
        {
            physics.XVelocity = 0;
            physics.YVelocity = 0;
        }
    }
}
