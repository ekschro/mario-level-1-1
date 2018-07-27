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
    public class DeadMarioCommand : ICommand
    {
        private Game1 myGame;
        private IPlayer player;

        public DeadMarioCommand(Game1 game)
        {
            myGame = game;
            player = game.CurrentLevel.PlayerObject;
        }

        public void Execute()
        {
            if (!(player.TestMario.StateMachine is TestDeadMarioStateMachine))
                player.TestMario = new TestDeadMario(myGame, (Mario)player);
            myGame.CurrentLevel.PlayerObject.IsStar = false;
        }
    }
}