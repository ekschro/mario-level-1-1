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
        public float CurrentXPos { get => testMarioLocation.X; set => testMarioLocation.X = value; }
        public float CurrentYPos { get => testMarioLocation.Y; set => testMarioLocation.Y = value; }
        private Vector2 testMarioLocation;

        private ITestMarioSprite marioSprite;
        public ITestMarioSprite MarioSprite { get => marioSprite; set => MarioSprite = value; }

        public ITestMarioStateMachine stateMachine;
        public ITestMarioStateMachine GetStateMachine { get => stateMachine; }

        private int cyclePosition = 0;
        private int cycleLength = 8;

        private bool dead = false;
        
        Mario character;
        Game1 myGame;
        public TestFireMario(Game1 game, Vector2 location, Mario mario)
        {
            testMarioLocation = location;
            marioSprite = new TestFireMarioSprite(game, this, (IPlayer) mario);
            stateMachine = new TestFireMarioStateMachine(marioSprite);
            character = mario;
            myGame = game;
        }

        public void Upgrade()
        {
            
        }
        public void Downgrade()
        {
            character.TestMario = new TestBigMario(myGame, testMarioLocation, character);
        }
        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
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
                if (dead)
                {
                }
            }
        }
        public void Draw()
        {
            MarioSprite.Draw();
        }
    }
}
