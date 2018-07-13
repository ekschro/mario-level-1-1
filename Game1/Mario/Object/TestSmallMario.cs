using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class TestSmallMario : ITestMario
    {
        public float CurrentXPos { get => character.CurrentXPos; set => character.CurrentXPos = value; }
        public float CurrentYPos { get => character.CurrentYPos; set => character.CurrentYPos = value; }
        private Vector2 testMarioLocation;

        private TestSmallMarioSprite marioSprite;
        public TestSmallMarioSprite MarioSprite { get => marioSprite; set => MarioSprite = value; }

        private ITestMarioStateMachine stateMachine;
        public ITestMarioStateMachine GetStateMachine { get => stateMachine; }

        private int cyclePosition = 0;
        private int cycleLength = 8;
        
        //private bool dead = false;
       
        //private IPlayer player;
        Mario character;
        Game1 myGame;
        public TestSmallMario(Game1 game, Vector2 location, Mario mario)
        {
            
            marioSprite = new TestSmallMarioSprite(game, this, mario);
            stateMachine = new TestSmallMarioStateMachine(marioSprite);
            character = mario;
            myGame = game;
        }

        public void Upgrade()
        {
            character.TestMario = new TestBigMario(myGame, new Vector2(character.CurrentXPos, character.CurrentYPos), character);
        }
        public void Downgrade()
        {
            character.TestMario = new TestDeadMario(myGame, new Vector2(character.CurrentXPos, character.CurrentYPos), character);
        }
        public Vector2 GetGameObjectLocation()
        {
            return testMarioLocation;
            //return new Vector2(character.CurrentXPos,character.CurrentYPos);
        }
        public void SetGameObjectLocation(Vector2 newPos)
        {
            testMarioLocation = newPos;
        }

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
            cyclePosition++;
            
             if (cyclePosition == cycleLength)
            {
                stateMachine.Update();
                MarioSprite.Update();
                cyclePosition = 0;
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
        public void Draw()
        {
            MarioSprite.Draw();
        }
    }
}
