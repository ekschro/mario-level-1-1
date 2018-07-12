using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class TestBigMario : ITestMario
    {
        public float CurrentXPos { get => character.CurrentXPos; set => character.CurrentXPos = value; }
        public float CurrentYPos { get => character.CurrentYPos; set => character.CurrentYPos = value; }
        private Vector2 testMarioLocation;
        
        private ITestMarioSprite marioSprite;
        public ITestMarioSprite MarioSprite { get => marioSprite; set => MarioSprite = value; }

        public ITestMarioStateMachine stateMachine;
        public ITestMarioStateMachine GetStateMachine { get => stateMachine; }
        ITestMarioStateMachine ITestMario.GetStateMachine { get => stateMachine;}

        private int cyclePosition = 0;
        private int cycleLength = 8;

        private bool dead = false;
        
        private Game1 myGame;
        Mario character;

        public TestBigMario(Game1 game, Vector2 location, Mario mario)
        {
            
            myGame = game;
            marioSprite = new TestBigMarioSprite(game, this,mario);
            stateMachine = new TestBigMarioStateMachine(marioSprite);
            character = mario;
        }

        public void Upgrade()
        {
            character.TestMario = new TestFireMario(myGame, testMarioLocation, character);
        }
        public void Downgrade()
        {
            character.TestMario = new TestSmallMario(myGame, testMarioLocation, character);
        }
        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }
        public void WalkLeft()
        {
            testMarioLocation.X -= 1;
        }
        public void WalkRight()
        {
            testMarioLocation.X = +1;
        }
        public Vector2 GetGameObjectLocation()
        {
            return testMarioLocation;
        }
        public void SetGameObjectLocation(Vector2 newPos)
        {
            testMarioLocation = newPos;
        }
        public bool GetDead()
        {
            return dead;
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
                cyclePosition = 0;
                stateMachine.Update();
                MarioSprite.Update();
            }
            

        }
        public void Draw()
        {
            MarioSprite.Draw();
        }

        
    }
}
