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
        public float CurrentXPos { get => character.CurrentXPos; set => character.CurrentXPos = value; }
        public float CurrentYPos { get => character.CurrentYPos; set => character.CurrentYPos = value; }
        private Vector2 testMarioLocation;

        private TestDeadMarioSprite marioSprite;
        public TestDeadMarioSprite MarioSprite { get => marioSprite; set => MarioSprite = value; }

        public ITestMarioStateMachine GetStateMachine { get => stateMachine;}

        private ITestMarioStateMachine stateMachine;
        private float bouncePosition;
        private float bounceVelocity;
        private float bounceGravity;
        private float bounceTimer;

        private int cyclePosition;
        private int cycleLength;
        private Mario character;
        //private bool dead = false;
        private MarioUtility utility;

        private bool endSequence;
        
        public TestDeadMario(Game1 game, Vector2 location, Mario mario)
        {
            utility = new MarioUtility();
            cyclePosition = utility.CyclePosition;
            cycleLength = utility.CycleLength;
            testMarioLocation = location;
            marioSprite = new TestDeadMarioSprite(game, this, mario);
            stateMachine = new TestDeadMarioStateMachine(marioSprite);
            character = mario;
            game.Pause = true;
            endSequence = false;
        }

        public void Upgrade()
        { }
        public void Downgrade()
        { }
        public Vector2 GetGameObjectLocation()
        {
            return testMarioLocation;
        }
        public void SetGameObjectLocation(Vector2 newPos)
        {
            testMarioLocation = newPos;
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
            stateMachine.Update();
            MarioSprite.Update();
        }
        public void Draw()
        {
            MarioSprite.Draw();
        }

        public void Flag()
        {
            endSequence = true;
        }
    }
}
