using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class Mario : IPlayer
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }
        private static float currentXPosition;
        private static float currentYPosition;
        private static float oldXPosition;
        private static float oldYPosition;
        private static bool movingUp;
        private static bool movingRight;
        private static bool movingLeft;
        private static bool movingDown;
        private static Game1 myGame;
        private static int totalMarioColumns = 28;
        private static int totalMarioRows = 3;
        private static bool isStar = false;
        private static bool invulnerability = false;
        private static int currentFrame = 0;
        private static int colorStartingTime;
        private static int deathTimer;
        private static int colorTimer;
        private static ISprite playerSprite;
        private static  IPhysics physics;
        private static Color marioColor;
        private static bool canJump;
        //prvate static bool falling;


        public ISprite MarioSprite { get => playerSprite; set => playerSprite = value; }
        public float CurrentXPosition { get => currentXPosition; set => currentXPosition = value; }
        public float CurrentYPosition { get => currentYPosition; set => currentYPosition = value; }

        public bool Jumping { get; set; }
        public bool Falling { get; set; }
        public bool Bump { get; set; }
        public bool Bounce { get; set; }
        public bool CanJump { get => canJump; set => canJump = value; }

        public bool MovingUp { get => movingUp; set => movingUp = value; }
        public bool MovingRight { get => movingRight; set => movingRight = value; }
        public bool MovingLeft { get => movingLeft; set => movingLeft = value; }
        public bool MovingDown { get => movingDown; set => movingDown = value; }
        
        public int TotalMarioRows { get => totalMarioRows; set => totalMarioRows = value; }
        public int TotalMarioColumns { get => totalMarioColumns; set => totalMarioColumns = value; }
        public bool IsStar { get => isStar; set => isStar = value; }
        public bool Invulnerability { get => invulnerability; set => invulnerability = value; }
        public static int CurrentFrame { get => currentFrame; set => currentFrame = value; }
        public static Game1 MyGame { get => myGame; set => myGame = value; }
        public static float OldXPosition { get => oldXPosition; set => oldXPosition = value; }
        public static float OldYPosition { get => oldYPosition; set => oldYPosition = value; }

        public Color MarioColor { get => marioColor; set => marioColor = value; }

        public Mario(Game1 game, Vector2 vector)
        {
            MyGame = game;
            physics = new MarioPhysics(game,this,2);
            CurrentXPosition = vector.X;
            CurrentYPosition = vector.Y;
            MarioColor = Color.White;
            MarioSprite = new MarioSmallIdleRight(MyGame,this);
            colorStartingTime = 5;
            colorTimer = 0;
            deathTimer = 0;

            MovingUp = false;
            MovingDown = false;
            MovingRight = false;
            MovingLeft = false;
            canJump = true;
            Falling = false;
            Bounce = false;
        }
                

        public void Draw()
        {
            ColorSelect();
            MarioSprite.Draw();
        }


        public void Update()
        {
            if (!(MarioSprite is MarioDead))
            {
                physics.Update();
                if (physics.XVelocity == 0 && MarioSprite is MarioBigWalkRight)
                {
                    MarioSprite = new MarioBigIdleRight(myGame,this);
                } else if (physics.XVelocity == 0 && MarioSprite is MarioBigWalkLeft)
                {
                    MarioSprite = new MarioBigIdleLeft(myGame,this);
                }
                else if (physics.XVelocity == 0 && MarioSprite is MarioSmallWalkRight)
                {
                    MarioSprite = new MarioSmallIdleRight(myGame,this);
                }
                else if (physics.XVelocity == 0 && MarioSprite is MarioSmallWalkLeft)
                {
                    MarioSprite = new MarioSmallIdleLeft(myGame,this);
                }
                else if (physics.XVelocity == 0 && MarioSprite is MarioFireWalkRight)
                {
                    MarioSprite = new MarioFireIdleRight(myGame,this);
                }
                else if (physics.XVelocity == 0 && MarioSprite is MarioFireWalkLeft)
                {
                    MarioSprite = new MarioFireIdleLeft(myGame,this);
                }
            }

            
        }
     
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

        public static Boolean CanGenerateProjectiles()
        {
            //if (MarioSprite.isFire())
            //{
            //    return true;
            //}
            //else
            //{
               return false;
            //}
        }
    }
}
