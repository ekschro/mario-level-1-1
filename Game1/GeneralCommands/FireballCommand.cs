using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Game1
{
    public class FireballCommand : ICommand
    {
        private Game1 myGame;
        private IControllerHandler controllerHandler;
        private IPlayer player;
        private bool buttonDown = false;

        public FireballCommand(Game1 game)
        {
            myGame = game;
            controllerHandler = game.controllerHandler;
        }

        public void Execute()
        {
            controllerHandler.FireBallHeld = true;
            //if (myGame.CurrentLevel.PlayerObject is Mario)
            //{
            //    ((MarioPhysics)(Mario.physics)).RunningCheck();
            //}
            
            //if (player.TestMario.StateMachine is TestFireMarioStateMachine)
            //{
            //    if (((Mario)player).FireBallTimer == 0 && !buttonDown) {
            //        myGame.CurrentLevel.EnemyObjects.Add(new MarioFireBall(myGame));
            //        ((Mario)player).FireBallTimer = 10;
            //        buttonDown = true;
            //    }
            //}
        }

    }
}
 