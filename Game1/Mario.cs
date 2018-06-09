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

        public ISprite MarioSprite;
        public Mario(Game1 game, Vector2 vector)
        {
            up = false;
            down = false;
            right = false;
            left = false;
            myGame = game;
            currentXPositon = vector.X;
            currentYPosition = vector.Y;
            MarioSprite = new MarioSmallIdleRight(myGame, this);
        }

        public void DownHeld()
        {
            up = false;
            down = true;
            
        }

        public void Draw()
        {
            MarioSprite.Draw();
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
        }

        public void RightHeld()
        {
            right = true;
            left = false;
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
            if (up && right)
            {
                SetCurrentXPositon(GetCurrentXPosition() + 1);
                SetCurrentYPosition(GetCurrentYPosition() - 1);
            } else if (up && left)
            {
                SetCurrentXPositon(GetCurrentXPosition() - 1);
                SetCurrentYPosition(GetCurrentYPosition() - 1);
            } else if(down && right)
            {
                SetCurrentXPositon(GetCurrentXPosition() + 1);
                SetCurrentYPosition(GetCurrentYPosition() + 1);
            } else if (down && left)
            {
                SetCurrentXPositon(GetCurrentXPosition() - 1);
                SetCurrentYPosition(GetCurrentYPosition() + 1);
            }
        }

        public void UpdHeld()
        {
            up = true;
            down = false;
        }
    }
}
