using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public abstract class AbstractTestMario : ITestMario
    {
        public float CurrentXPos { get => character.CurrentXPos; set => character.CurrentXPos = value; }
        public float CurrentYPos { get => character.CurrentYPos; set => character.CurrentYPos = value; }
        internal Vector2 testMarioLocation;
        
        internal ITestMarioSprite marioSprite;
        public ITestMarioSprite MarioSprite { get => marioSprite; set => marioSprite = value; }

        internal ITestMarioStateMachine stateMachine;
        public ITestMarioStateMachine StateMachine { get => stateMachine; set => stateMachine = value; }

        private int cyclePosition;
        private int cycleLength;

        private int timer = 400;
        private float pipeDistance = 0;
        //internal bool dead = false;

        private bool isEndSequence = false;
        protected bool isPipeSequence = false;

        protected bool pipeIsPositive;
        protected bool pipeIsHorizontal;

        protected MarioUtility utility;
        protected Game1 myGame;
        protected Mario character;

        protected AbstractTestMario(Game1 game, Vector2 location, Mario mario)
        {
            utility = new MarioUtility();
            myGame = game;

            character = mario;
            cyclePosition = utility.CyclePosition;
            cycleLength = utility.CycleLength;
        }

        protected AbstractTestMario(Game1 game)
        {
            myGame = game;
        }

        public abstract void Upgrade();
        public abstract void Downgrade();
        public void ChangeDirection(bool left)
        {
            stateMachine.ChangeDirection(left);
        }
        /*
        public void WalkLeft()
        {
            testMarioLocation.X -= 1;
        }
        public void WalkRight()
        {
            testMarioLocation.X = +1;
        }
        */
        public Vector2 GetGameObjectLocation()
        {
            return testMarioLocation;
        }
        public void SetGameObjectLocation(Vector2 newPos)
        {
            testMarioLocation = newPos;
        }
        /*
        public bool GetDead()
        {
            return dead;
        }
        */
        public void Idle()
        {
            stateMachine.Idle();
        }
        public void Walking()
        {
            stateMachine.Walking();
        }
        public void Jumping()
        {
            stateMachine.Jumping();
        }
        public void Crouching()
        {
            stateMachine.Crouching();
        }
        public void Update()
        {
            if (isEndSequence)
            {
                EndSequence();
            }
            else
            {
                cyclePosition++;

                if (cyclePosition == cycleLength)
                {
                    stateMachine.Update();
                    MarioSprite.Update();
                    cyclePosition = utility.CyclePosition;
                }
                else if (myGame.controllerHandler.MovingUp || (myGame.controllerHandler.MovingUp && myGame.controllerHandler.MovingLeft))
                    stateMachine.Jumping();
                else if (myGame.controllerHandler.MovingDown || (myGame.controllerHandler.MovingDown && myGame.controllerHandler.MovingRight))
                    stateMachine.Crouching();
                else if (myGame.controllerHandler.MovingLeft)
                {
                    stateMachine.ChangeDirection(true);
                    stateMachine.Walking();
                }
                else if (myGame.controllerHandler.MovingRight)
                {
                    stateMachine.ChangeDirection(false);
                    stateMachine.Walking();
                }
                else
                    Idle();
            }
            
        }

        public void Draw()
        {
            if (isPipeSequence)
                PipeSequence(pipeIsPositive, pipeIsHorizontal);
            else
                MarioSprite.Draw();
        }

        public void Flag()
        {
            isEndSequence = true;
            character.Falling = false;
            character.Stop();
        }
        public void Pipe(bool isPositive, bool isHorizontal)
        {
            myGame.AllowControllerResponse = false;
            isPipeSequence = true;
            character.Falling = false;
            character.Stop();
            pipeIsPositive = isPositive;
            pipeIsHorizontal = isHorizontal;
        }

        public void EndSequence()
        {
            if (timer != 0)
            {
                timer--;
            }
            else if (character.CurrentYPos < 140)
            {
            }
            else if (character.CurrentXPos < myGame.CurrentLevel.EndLocation)
            {
                Walking();
                cyclePosition++; if (cyclePosition == cycleLength)
                {
                    stateMachine.Update();
                    MarioSprite.Update();
                    cyclePosition = 0;
                }
                character.CurrentXPos += 0.5f;
            }
        }

        public void PipeSequence(bool isPositive, bool isHorizontal)
        {
            if (pipeDistance < 48)
            {
                int offset = (int)pipeDistance;

                if (!pipeIsPositive)
                    offset = -offset;

                if (pipeIsHorizontal)
                    marioSprite.Draw(offset, 0);
                else
                    marioSprite.Draw(0, offset);

                pipeDistance++;
            }
            else
            {
                isPipeSequence = false;
                pipeDistance = 0;
                myGame.AllowControllerResponse = true;
                Warp(isPositive, isHorizontal);
            }
        }
        protected void Warp(bool isPositive, bool isHorizontal)
        {
            if (isPositive && !isHorizontal)
                ((PlatformerLevel)myGame.CurrentLevel).WarpToSecret();
            else if (isHorizontal)
            {
                ((PlatformerLevel)myGame.CurrentLevel).WarpFromSecret();
                Pipe(false, false);
            }
        }
    }
}
