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
        private int leftStartFrame;
        private int leftEndFrame;
        public Vector2 koopaLocation;
        public Koopa(Game1 game, Vector2 location)
        {
            stateMachine = new KoopaStateMachine();
            myGame = game;
            startFrame = 2;
            endFrame = 4;
            leftStartFrame = 0;
            leftEndFrame = 2;
            currentFrame = startFrame;
            koopaLocation = location;
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }

        public void BeStomped()
        {
            startFrame = leftStartFrame = 4;
            endFrame = leftEndFrame = 6;
            stateMachine.BeStomped();
            startFrame = leftStartFrame = 5;
            endFrame = leftEndFrame = 6;
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
                koopaLocation.X += 1;
                if (koopaLocation.X == 420)
                {
                    direction = false;
                    currentFrame = leftStartFrame;
                }
                cyclePosition = 0;
                currentFrame++;
                if (currentFrame == endFrame)
                    currentFrame = startFrame;
            }
            else if (cyclePosition == cycleLength && direction == false)
            {
                koopaLocation.X -= 1;
                if (koopaLocation.X == 380)
                    direction = true;
                cyclePosition = 0;
                currentFrame++;
                if (currentFrame == leftEndFrame)
                    currentFrame = leftStartFrame;
            }
            
        }

        public void Draw()
        {
            int width = myGame.koopaTexture.Width / 6;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.koopaTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)koopaLocation.X, (int)koopaLocation.Y, width, myGame.koopaTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.koopaTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }
}
