using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class TestFireMario : ITestMario
    {
        public float CurrentXPos { get => character.CurrentXPos; set => character.CurrentXPos = value; }
        public float CurrentYPos { get => character.CurrentYPos; set => character.CurrentYPos = value; }
        private Vector2 testMarioLocation;

        private TestFireMarioSprite marioSprite;
        public TestFireMarioSprite MarioSprite { get => marioSprite; set => MarioSprite = value; }

        private ITestMarioStateMachine stateMachine;
        public ITestMarioStateMachine GetStateMachine { get => stateMachine; }

        private int cyclePosition;
        private int cycleLength;
        private MarioUtility utility;
        private bool dead = false;
      

        private bool endSequence;

        Mario character;
        Game1 myGame;
        public TestFireMario(Game1 game, Vector2 location, Mario mario)
        {
            utility = new MarioUtility();
            testMarioLocation = location;
            marioSprite = new TestFireMarioSprite(game, this, mario);
            stateMachine = new TestFireMarioStateMachine(marioSprite);
            character = mario;
            myGame = game;
            cyclePosition = utility.CyclePosition;
            cycleLength = utility.CycleLength;
            endSequence = false;
        }

        public void Upgrade()
        {
            
        }
        public void Downgrade()
        {
            character.TestMario = new TestBigMario(myGame, testMarioLocation, character);
        }
        /*
        public void ChangeDirection(bool left)
        {
            stateMachine.ChangeDirection(left);
        }
        */
        public Vector2 GetGameObjectLocation()
        {
            return testMarioLocation;
        }
        /*
        public void SetGameObjectLocation(Vector2 newPos)
        {
            testMarioLocation = newPos;
        }
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
            if (endSequence)
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
                Jumping();
            else if (myGame.controllerHandler.MovingDown || (myGame.controllerHandler.MovingDown && myGame.controllerHandler.MovingRight))
                Crouching();
            else if (myGame.controllerHandler.MovingLeft)
            {
                stateMachine.ChangeDirection(true);
                Walking();
            }
            else if (myGame.controllerHandler.MovingRight)
            {
                stateMachine.ChangeDirection(false);
                Walking();

                }

                else
                    Idle();
            }
        }
        public void Draw()
        {
            MarioSprite.Draw();
        }
        public void Flag()
        {
            endSequence = true;
        }
        public void EndSequence()
        {

        }
    }
}
