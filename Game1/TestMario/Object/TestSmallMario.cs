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
        //private Vector2 testMarioLocation;

        private ITestMarioSprite marioSprite;
        public ITestMarioSprite MarioSprite { get => marioSprite; set => MarioSprite = value; }

        public ITestMarioStateMachine stateMachine;
        public ITestMarioStateMachine GetStateMachine { get => stateMachine; }

        private int cyclePosition = 0;
        private int cycleLength = 8;
        
        //private bool dead = false;
       
        private IPlayer player;
        Mario character;
        Game1 myGame;
        public TestSmallMario(Game1 game, Vector2 location, Mario mario)
        {
            testMarioLocation = location;
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
        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }
        public Vector2 GetGameObjectLocation()
        {
            return new Vector2(character.CurrentXPos,character.CurrentYPos);
        }
        public void SetGameObjectLocation(Vector2 newPos)
        {
            //testMarioLocation = newPos;
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
        public void WalkLeft()
        {
            testMarioLocation.X -= 1;
        }
        public void WalkRight()
        {
            testMarioLocation.X = +1;
        }

    }
}
