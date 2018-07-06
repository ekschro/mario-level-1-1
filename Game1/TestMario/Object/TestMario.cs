using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class TestMario : ITestMario
    {
        public float CurrentXPos { get => testMarioLocation.X; set => testMarioLocation.X = value; }
        public float CurrentYPos { get => testMarioLocation.Y; set => testMarioLocation.Y = value; }
        private ITestMarioSprite marioSprite;
        public ITestMarioSprite MarioSprite { get => marioSprite; set => MarioSprite = value; }
        public TestMarioStateMachine stateMachine;
        public ITestMarioStateMachine GetStateMachine { get => stateMachine; }
        private int cyclePosition = 0;
        private int cycleLength = 8;
        private Vector2 testMarioLocation;

        
        private bool dead = false;
        private IPhysics physics;

        public TestMario(Game1 game, Vector2 location)
        {
            testMarioLocation = location;
            marioSprite = new TestSmallMarioSprite(game, this);
            stateMachine = new TestMarioStateMachine(marioSprite);
        }

        public void Upgrade()
        {
            stateMachine.Upgrade();
        }
        public void DownGrade()
        {
            stateMachine.Downgrade();
        }
        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }

        public void Draw()
        {
            MarioSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return testMarioLocation;
        }
        public void SetGameObjectLocation(Vector2 newPos)
        {
            testMarioLocation = newPos;
        }
        
        public void Update()
        {
            physics.Update();
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

        public bool GetDead()
        {
            return dead;
        }

    }
}
