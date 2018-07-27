using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
namespace Game1
{
    public class Mario : IPlayer
    {
        private IControllerHandler controllerHandler;
        private Game1 myGame;
        
        private int killedNum = 0;
        private ITestMario testMario;
        private static MarioPhysics physics;
        private static Color marioColor;
        private static float currentXPosition;
        private static float currentYPosition;
        private static int totalMarioColumns = 28;
        private static int totalMarioRows = 3;
        private static int colorStartingTime;
        private static int colorTimer;
        private bool isStar = false;
        private bool invulnerability = false;
        public Color MarioColor { get => marioColor; set => marioColor = value; }
        public float CurrentXPos { get => currentXPosition; set => currentXPosition = value; }
        public float CurrentYPos { get => currentYPosition; set => currentYPosition = value; }
        public bool Jumping { get; set; }
        public bool Falling { get; set; }
        public bool Bump { get; set; }
        public bool Bounce { get; set; }
        private bool starStopped = false;
        private bool fireButton;

        public bool CanJump { get; set; }
        public bool IsStar { get => isStar; set => isStar = value; }
        public bool Invulnerability { get => invulnerability; set => invulnerability = value; }
        public int TotalMarioRows { get => totalMarioRows; set => totalMarioRows = value; }
        public int TotalMarioColumns { get => totalMarioColumns; set => totalMarioColumns = value; }
        public int KilledNum { get => killedNum; set => killedNum = value; }
        public ITestMario TestMario { get => testMario; set => testMario = value; }

        public Mario(Game1 game, Vector2 vector,int state)
        {
            myGame = game;
            controllerHandler = game.ControllerHandler;
            physics = new MarioPhysics(game,this,2);
            CurrentXPos = vector.X;
            CurrentYPos = vector.Y;
            MarioColor = Color.White;
            colorStartingTime = 5;
            colorTimer = 0;
            if (state == 1)
                testMario = new TestSmallMario(game, this);
            else if (state == 2)
                testMario = new TestBigMario(game, this);
            else if (state == 3)
                testMario = new TestFireMario(game, this);
            else
                testMario = new TestSmallMario(game, this);

            CanJump = true;
            Falling = false;
            Bounce = false;
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

            if (controllerHandler.FireBallHeld)
                fireBall();
            else
                fireButton = false;
        }

        public Vector2 GameObjectLocation => new Vector2(currentXPosition, currentYPosition);

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

        private void fireBall()
        {
            physics.RunningCheck();

            if (this.TestMario.StateMachine is TestFireMarioStateMachine)
            {
                if (!fireButton)
                {
                    myGame.CurrentLevel.EnemyObjects.Add(new MarioFireBall(myGame));
                    fireButton = true;
                }
            }
        }

        public void Stop()
        {
            physics.XVelocity = 0;
            physics.YVelocity = 0;
        }
    }
}
