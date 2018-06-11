using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class Mario : IPlayer
    {
        public static float currentXPosition;
        public static float currentYPosition;
        private Game1 myGame;
        public static Boolean up;
        public static Boolean right;
        public static Boolean left;
        public static Boolean down;

       public static ISprite marioSprite;

        public static ISprite MarioSprite { get => marioSprite; set => marioSprite = value; }

        public Mario(Game1 game, Vector2 vector)
        {
            up = false;
            down = false;
            right = false;
            left = false;
            myGame = game;
            currentXPosition = vector.X;
            currentYPosition = vector.Y;
            MarioSprite = new MarioSmallIdleRight(myGame, this);
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
