using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class Mario : IPlayer
    {
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
        private static int currentFrame = 0;


        private static ISprite playerSprite;

        public static ISprite MarioSprite { get => playerSprite; set => playerSprite = value; }
        public static float CurrentXPosition { get => currentXPosition; set => currentXPosition = value; }
        public static float CurrentYPosition { get => currentYPosition; set => currentYPosition = value; }
        public static int TotalMarioRows { get => totalMarioRows; set => totalMarioRows = value; }
        public static int TotalMarioColumns { get => totalMarioColumns; set => totalMarioColumns = value; }
        public bool IsStar { get => isStar; set => isStar = value; }
        public static int CurrentFrame { get => currentFrame; set => currentFrame = value; }
        public static Game1 MyGame { get => myGame; set => myGame = value; }
        public static float OldXPosition { get => oldXPosition; set => oldXPosition = value; }
        public static float OldYPosition { get => oldYPosition; set => oldYPosition = value; }
        public static bool MovingUp { get => movingUp; set => movingUp = value; }
        public static bool MovingRight { get => movingRight; set => movingRight = value; }
        public static bool MovingLeft { get => movingLeft; set => movingLeft = value; }
        public static bool MovingDown { get => movingDown; set => movingDown = value; }
        public static Color MarioColor { get => marioColor; set => marioColor = value; }

        private static Color marioColor;
        private int colorTimer;
        private int colorStartingTime;
        //public Color MarioColor { get => marioColor; set => marioColor = value; }

        public Mario(Game1 game, Vector2 vector)
        {
            MyGame = game;
            CurrentXPosition = vector.X;
            CurrentYPosition = vector.Y;
            MarioColor = Color.White;
            MarioSprite = new MarioSmallIdleRight(MyGame);
            colorStartingTime = 5;
            colorTimer = 0;
            MovingUp = false;
            MovingDown = false;
            MovingRight = false;
            MovingLeft = false;

        }

        

        public void Draw()
        {
            ColorSelect();
            MarioSprite.Draw();
        }


        public void Update()
        {

        }
        
        public Vector2 GameObjectLocation()
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
            else if (isStar && colorTimer > 0)
                colorTimer--;
            else
            {
                MarioColor = Color.White;
            }
        }








    }
}
