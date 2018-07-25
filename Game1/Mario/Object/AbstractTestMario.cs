using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

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

        private int timer = -1;
        private float pipeDistance = 0;
        //internal bool dead = false;

        private bool isFlagSequence = false;
        private bool isAxeSequence = false;
        private bool isPipeSequence = false;

        private bool pipeIsPositive;
        private bool pipeIsHorizontal;

        internal MarioUtility utility;
        internal Game1 myGame;
        internal Mario character;

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
        public void GoDie()
        {
            character.TestMario = new TestDeadMario(myGame, new Vector2(character.CurrentXPos, character.CurrentYPos), character);
        }
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
            if (isFlagSequence)
            {
                EndSequence(140, myGame.CurrentLevel.EndLocation);
            }
            else if (isAxeSequence)
            {
                MediaPlayer.Play(SoundWarehouse.castle_complete_theme);
                EndSequence(0, myGame.CurrentLevel.EndLocation);
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
                else if (myGame.controllerHandler.MovingUp && myGame.controllerHandler.MovingLeft || (myGame.controllerHandler.MovingUp && myGame.controllerHandler.MovingLeft))
                {
                    stateMachine.ChangeDirection(true);
                    stateMachine.Jumping();
                }
                else if (myGame.controllerHandler.MovingUp && myGame.controllerHandler.MovingRight || (myGame.controllerHandler.MovingUp && myGame.controllerHandler.MovingLeft))
                {
                    stateMachine.ChangeDirection(false);
                    stateMachine.Jumping();
                }
                else if (myGame.controllerHandler.MovingUp || (myGame.controllerHandler.MovingUp && myGame.controllerHandler.MovingLeft))
                {
                    stateMachine.Jumping();
                }
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
            isFlagSequence = true;
            character.Falling = false;
            character.Stop();

            if(timer == -1)
                timer = 400;
        }

        public void Axe()
        {
            isAxeSequence = true;
            timer = 0;
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

        public void EndSequence(int yConstraint, int xConstraint)
        {
            if (timer > 0)
            {
                timer--;
            }
            else if (character.CurrentYPos < yConstraint)
            {
            }
            else if (character.CurrentXPos < xConstraint)
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
            else
            {
                Idle();
            }
        }

        public void PipeSequence(bool isPositive, bool isHorizontal)
        {
            if (pipeDistance < 48)
            {
                int offset = (int)pipeDistance;

                if (!pipeIsPositive)
                    offset = -offset + 48;

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
