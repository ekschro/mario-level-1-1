using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class TestSmallMario
    {
        public float CurrentXPos { get => testMarioLocation.X; set => testMarioLocation.X = value; }
        public float CurrentYPos { get => testMarioLocation.Y; set => testMarioLocation.Y = value; }
        private ITestMarioSprite marioSprite;
        //private IEnemySprite goombaSprite;
        public ItestMarioSprite MarioSprite { get => marioSprite; set => MarioSprite = value; }
        //public IEnemySprite GoombaSprite { get => goombaSprite; set => goombaSprite = value; }
        public TestSmallMarioStateMachine stateMachine;
        //public GoombaStateMachine stateMachine;
        public ITestMarioStateMachine GetStateMachine { get => stateMachine; }
        //public IEnemyStateMachine GetStateMachine { get => stateMachine; }
        private int cyclePosition = 0;
        private int cycleLength = 8;
        private Vector2 testMarioLocation;
        //private Vector2 goombaLocation;
        //private Vector2 goombaOriginalLocation;
        
        private bool dead = false;
        private IPhysics physics;

        public TestSmallMario(Game1 game, Vector2 location)
        {
            testMarioLocation = location;
            //goombaOriginalLocation = location;
            marioSprite = new TestSmallMarioSprite(game, this);
            stateMachine = new TestSmallMarioStateMachine(TestSmallMarioSprite);
            physics = new MarioPhysics(game, this, 1);
            
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
                    //goombaLocation.Y += 1;
                }
            }
        }

        public bool GetDead()
        {
            return dead;
        }

    }
}
