﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public interface IEnemy
    {
        void ChangeDirection();
        void BeStomped();
        void BeFlipped();
        void Update();
        void Draw();
    }
    public class Koopa : IEnemy
    {
        private KoopaStateMachine stateMachine;
        private Game1 myGame;
        private int currentFrame;
        private int cyclePosition = 0;
        private int cycleLength = 16;
        private int startFrame;
        private int endFrame;

        public Koopa(Game1 game)
        {
            stateMachine = new KoopaStateMachine();
            myGame = game;
            startFrame = 2;
            endFrame = 4;
            currentFrame = startFrame;
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
        }

        public void BeFlipped()
        {
            stateMachine.BeFlipped();
        }
        public void Update()
        {
            stateMachine.Update();
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
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
            Rectangle destinationRectangle = new Rectangle((int)400, (int)100, width, myGame.koopaTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.koopaTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }
    public class Goomba : IEnemy
    {
        private GoombaStateMachine stateMachine;
        private Game1 myGame;
        private int currentFrame;
        private int cyclePosition = 0;
        private int cycleLength = 16;
        private int startFrame;
        private int endFrame;

        public Goomba(Game1 game)
        {
            stateMachine = new GoombaStateMachine();
            myGame = game;
            startFrame = 0;
            endFrame = 2;
            currentFrame = startFrame;
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
        }

        public void BeFlipped()
        {
            stateMachine.BeFlipped();
        }
        public void Update()
        {
            stateMachine.Update();
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                cyclePosition = 0;
                currentFrame++;
                if (currentFrame == endFrame)
                    currentFrame = startFrame;
            }
            
        }

        public void Draw()
        {
            int width = myGame.goombaTexture.Width / 3;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.goombaTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)450, (int)100, width, myGame.goombaTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.goombaTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }
    
}