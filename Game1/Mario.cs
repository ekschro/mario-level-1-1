using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class Mario : IPlayer
    {
        private static float currentXPosition;
        private static float currentYPosition;
        private static Game1 myGame;
        private static int totalMarioColumns = 28;
        private static int totalMarioRows = 3;
        private static bool isStar = false;
        private static int currentFrame = 0;


        public static ISprite marioSprite;

        public static ISprite MarioSprite { get => marioSprite; set => marioSprite = value; }
        public static float CurrentXPosition { get => currentXPosition; set => currentXPosition = value; }
        public static float CurrentYPosition { get => currentYPosition; set => currentYPosition = value; }
        public static int TotalMarioRows { get => totalMarioRows; set => totalMarioRows = value; }
        public static int TotalMarioColumns { get => totalMarioColumns; set => totalMarioColumns = value; }
        public bool IsStar { get => isStar; set => isStar = value; }
        public static int CurrentFrame { get => currentFrame; set => currentFrame = value; }
        public static Game1 MyGame { get => myGame; set => myGame = value; }

        public Mario(Game1 game, Vector2 vector)
        {
            MyGame = game;
            CurrentXPosition = vector.X;
            CurrentYPosition = vector.Y;
            MarioSprite = new MarioSmallIdleRight(MyGame);
        }

        

        public void Draw()
        {
            MarioSprite.Draw();
        }


        public void Update()
        {

        }
        
        public Vector2 GameObjectLocation()
        {
            return new Vector2(currentXPosition, currentYPosition);
        }

        //public bool IsStar()
        //{
        //    return isStar;
        //}
        

        

        

       

       
    }
}
