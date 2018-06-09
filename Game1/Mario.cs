using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class Mario : IPlayer
    {
        private float currentXPositon;
        private float currentYPosition;
        private Game1 myGame;
        private Boolean up;
        private Boolean right;
        private Boolean left;
        private Boolean down;
        public Mario(Game1 game, Vector2 vector)
        {
            up = false;
            down = false;
            right = false;
            left = false;
            myGame = game;
            currentXPositon = vector.X;
            currentYPosition = vector.Y;
        }

        public void DownHeld()
        {
            up = false;
            down = true;
            right = false;
            left = false;
            
        }

        public void Draw()
        {
            myGame.marioSprite.Draw();
        }

        public float GetCurrentXPosition()
        {
            return currentXPositon;
        }

        public float GetCurrentYPosition() 
        {
            return currentYPosition;
        }

        public void LeftHeld()
        {
            right = false;
            left = true;
            up = false;
            down = false;
        }

        public void RightHeld()
        {
            right = true;
            left = false;
            up = false;
            down = false;
        }

        public void SetCurrentXPositon(float x)
        {
            currentXPositon = x;
        }

        public void SetCurrentYPosition(float y)
        {
            currentYPosition = y;
        }

        public void Update()
        {
            if (up)
            {
                
                SetCurrentYPosition(GetCurrentYPosition() - 1);
            } else if (down)
            {
                
                SetCurrentYPosition(GetCurrentYPosition() + 1);
            } else if(right)
            {
                SetCurrentXPositon(GetCurrentXPosition() + 1);
                
            } else if (left)
            {
                SetCurrentXPositon(GetCurrentXPosition() - 1);
                
            }
        }

        public void UpHeld()
        {
            up = true;
            down = false;
            right = false;
            left = false;
        }
    }
}
