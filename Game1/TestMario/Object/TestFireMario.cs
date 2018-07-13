﻿using System;
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

        private ITestMarioSprite marioSprite;
        public ITestMarioSprite MarioSprite { get => marioSprite; set => MarioSprite = value; }

        private ITestMarioStateMachine stateMachine;
        public ITestMarioStateMachine GetStateMachine { get => stateMachine; }

        private int cyclePosition = 0;
        private int cycleLength = 8;

        private bool dead = false;
        
        Mario character;
        Game1 myGame;
        public TestFireMario(Game1 game, Vector2 location, Mario mario)
        {
            testMarioLocation = location;
            marioSprite = new TestFireMarioSprite(game, this, mario);
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
