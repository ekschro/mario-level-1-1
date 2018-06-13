using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class Mario : IPlayer
    {
        private static float currentXPosition;
        private static float currentYPosition;
        private Game1 myGame;
        private static int totalMarioColumns = 28;
        private static int totalMarioRows = 3;

        public static ISprite marioSprite;

        public static ISprite MarioSprite { get => marioSprite; set => marioSprite = value; }
        public static float CurrentXPosition { get => currentXPosition; set => currentXPosition = value; }
        public static float CurrentYPosition { get => currentYPosition; set => currentYPosition = value; }
        public static int TotalMarioRows { get => totalMarioRows; set => totalMarioRows = value; }
        public static int TotalMarioColumns { get => totalMarioColumns; set => totalMarioColumns = value; }

        public Mario(Game1 game, Vector2 vector)
        {
            
            myGame = game;
            CurrentXPosition = vector.X;
            CurrentYPosition = vector.Y;
            MarioSprite = new MarioSmallIdleRight(myGame);
        }

        

        public void Draw()
        {
            MarioSprite.Draw();
        }


        public void Update()
        {

        }
        

        

        

        

       

       
    }
}
