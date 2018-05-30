using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class Koopa : IEnemy
    {
        private KoopaStateMachine stateMachine;
        private Game1 myGame;
        private int currentFrame;
        private int cyclePosition = 0;
        private int cycleLength = 8;
        private bool direction = true;
        private int startFrame;
        private int endFrame;
        public Vector2 location;
        public Koopa(Game1 game)
        {
            stateMachine = new KoopaStateMachine();
            myGame = game;
            startFrame = 2;
            endFrame = 4;
            currentFrame = startFrame;
            location = new Vector2(400, 100);
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }

        public void BeStomped()
        {
            startFrame = 4;
            endFrame = 6;
            stateMachine.BeStomped();
            startFrame = 5;
            endFrame = 6;
            stateMachine.BeStomped();
            location.X += 1;
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
                startFrame = 2;
                endFrame = 3;
                currentFrame = startFrame;
                location.X += 1;
                if (location.X == 420)
                    direction = false;
                cyclePosition = 0;

                currentFrame++;
                if (currentFrame == endFrame)
                    currentFrame = startFrame;
            }
            else if (cyclePosition == cycleLength && direction == false)
            {
                startFrame = 0;
                endFrame = 1;
                currentFrame = startFrame;
                location.X -= 1;
                if (location.X == 380)
                    direction = true;
                cyclePosition = 0;

                currentFrame++;
                if (currentFrame == endFrame)
                    currentFrame = startFrame;
            }
        }

        public void Draw()
        {
            int width = myGame.koopaTexture.Width / 6;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.koopaTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, myGame.koopaTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.koopaTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }
}
