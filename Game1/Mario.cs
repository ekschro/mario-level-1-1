using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class Mario : IPlayer
    {
        private IControllerHandler controllerHandler;
        private Game1 myGame;
        private int animationTimer;

        private static ISprite playerSprite;
        private static IPhysics physics;
        private static Color marioColor;
        private static float currentXPosition;
        private static float currentYPosition;
        private static int totalMarioColumns = 28;
        private static int totalMarioRows = 3;
        private static int colorStartingTime;
        private static int colorTimer;
        private static bool isStar = false;
        private static bool invulnerability = false;

        public ISprite MarioSprite { get => playerSprite; set => playerSprite = value; }
        public Color MarioColor { get => marioColor; set => marioColor = value; }
        public float CurrentXPos { get => currentXPosition; set => currentXPosition = value; }
        public float CurrentYPos { get => currentYPosition; set => currentYPosition = value; }
        public bool Jumping { get; set; }
        public bool Falling { get; set; }
        public bool Bump { get; set; }
        public bool Bounce { get; set; }
        public bool CanJump { get; set; }
        public bool IsStar { get => isStar; set => isStar = value; }
        public bool Invulnerability { get => invulnerability; set => invulnerability = value; }
        public int TotalMarioRows { get => totalMarioRows; set => totalMarioRows = value; }
        public int TotalMarioColumns { get => totalMarioColumns; set => totalMarioColumns = value; }

        public Mario(Game1 game, Vector2 vector)
        {
            myGame = game;
            controllerHandler = game.controllerHandler;
            physics = new MarioPhysics(game,this,2);
            CurrentXPos = vector.X;
            CurrentYPos = vector.Y;
            MarioColor = Color.White;
            MarioSprite = new MarioSmallIdleRight(game,this);
            colorStartingTime = 5;
            colorTimer = 0;
            animationTimer = 0;

            CanJump = true;
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
            }
        }

        private void RightAnimation()
        {
            if (animationTimer == 5)
            {
                this.MarioSprite.RightCommandCalled();
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
                this.MarioSprite.UpCommandCalled();
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
                this.MarioSprite.DownCommandCalled();
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
                this.MarioSprite.LeftCommandCalled();
                animationTimer = 0;
            }
            else
            {
                animationTimer++;
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
