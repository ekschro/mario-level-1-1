using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class TestDeadMario : ITestMario
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
        private IPhysics physics;

        public TestDeadMario(Game1 game, Vector2 location)
        {
            testMarioLocation = location;
            marioSprite = new TestDeadMarioSprite(game, this);
            stateMachine = new TestDeadMarioStateMachine(marioSprite);
        }

        public void Upgrade()
        { }
        public void Downgrade()
        { }
        public void ChangeDirection()
        { }
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
        { }
        public void Walking()
        { }
        public void Jumping()
        { }
        public void Crouching()
        { }
        public void Update()
        {
            physics.Update();
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
