using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class Goomba : IEnemy
    {
        private GoombaStateMachine stateMachine;
        private Game1 myGame;
        private int currentFrame;
        private int cyclePosition = 0;
        private int cycleLength = 8;
        private bool direction = true;
        private int startFrame;
        private int endFrame;
        public Vector2 location;

        public Goomba(Game1 game)
        {
            stateMachine = new GoombaStateMachine();
            myGame = game;
            startFrame = 0;
            endFrame = 2;
            currentFrame = startFrame;
            location = new Vector2(450, 100);
        }
        public void ChangeDirection()
        {

            stateMachine.ChangeDirection();
        }

        public void BeStomped()
        {
            startFrame = 2;
            endFrame = 3;
            stateMachine.BeStomped();
            startFrame = 3;
            endFrame = 4;
            stateMachine.BeStomped();
        }

        public void BeFlipped()
        {
            stateMachine.BeFlipped();
        }
        public void Update()
        {
            stateMachine.Update();
            cyclePosition++;
            if (cyclePosition == cycleLength && direction == true)
            {
                location.X += 1;
                if (location.X == 500)
                    direction = false;
                cyclePosition = 0;
                currentFrame++;
                if (currentFrame == endFrame)
                    currentFrame = startFrame;
            }
            else if (cyclePosition == cycleLength && direction == false)
            {
                location.X -= 1;
                if (location.X == 400)
                    direction = true;
                cyclePosition = 0;
                currentFrame++;
                if (currentFrame == endFrame)
                    currentFrame = startFrame;
            }
        }

        public void Draw()
        {
            int width = myGame.goombaTexture.Width / 4;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.goombaTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, myGame.goombaTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.goombaTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }
}
