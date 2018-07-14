﻿using System;
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
        
        private TestBigMarioSprite marioSprite;
        public TestBigMarioSprite MarioSprite { get => marioSprite; set => MarioSprite = value; }

        private ITestMarioStateMachine stateMachine;
        public ITestMarioStateMachine GetStateMachine { get => stateMachine; }
        ITestMarioStateMachine ITestMario.GetStateMachine { get => stateMachine;}

        private int cyclePosition;
        private int cycleLength;

        private bool dead = false;
        private MarioUtility utility;
        private Game1 myGame;
        Mario character;

        public TestBigMario(Game1 game, Vector2 location, Mario mario)
        {
            utility = new MarioUtility();
            myGame = game;
            marioSprite = new TestBigMarioSprite(game, this,mario);
            stateMachine = new TestBigMarioStateMachine(marioSprite);
            character = mario;
            cyclePosition = utility.CyclePosition;
            cycleLength = utility.CycleLength;
        }

        public void Upgrade()
        {
            character.TestMario = new TestFireMario(myGame, testMarioLocation, character);
        }
        public void Downgrade()
        {
            character.TestMario = new TestSmallMario(myGame, testMarioLocation, character);
        }
        public void ChangeDirection(bool left)
        {
            stateMachine.ChangeDirection(left);
        }
        /*
        public void WalkLeft()
        {
            testMarioLocation.X -= 1;
        }
        public void WalkRight()
        {
            testMarioLocation.X = +1;
        }
        */
        public Vector2 GetGameObjectLocation()
        {
            return testMarioLocation;
        }
        public void SetGameObjectLocation(Vector2 newPos)
        {
            testMarioLocation = newPos;
        }
        /*
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
                cyclePosition = utility.CyclePosition;
            }
            else if (myGame.controllerHandler.MovingUp || (myGame.controllerHandler.MovingUp && myGame.controllerHandler.MovingLeft))
                stateMachine.Jumping();
            else if (myGame.controllerHandler.MovingDown || (myGame.controllerHandler.MovingDown && myGame.controllerHandler.MovingRight))
                stateMachine.Crouching();
            else if (myGame.controllerHandler.MovingLeft)
            {
                stateMachine.ChangeDirection(true);
                stateMachine.Walking();
            }
            else if (myGame.controllerHandler.MovingRight)
            {
                stateMachine.ChangeDirection(false);
                stateMachine.Walking();
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