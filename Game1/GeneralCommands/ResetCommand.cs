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
    public class ResetCommand : ICommand
    {
        private Game1 myGame;
        private IPlayer player;

        public ResetCommand(Game1 game)
        {
            myGame = game;
            player = game.CurrentLevel.PlayerObject;
        }

        public void Execute()
        {
            myGame.Reset();
            player.MovingDown = false;
            player.MovingUp = false;
            player.MovingRight = false;
            player.MovingLeft = false;
        }
    }
}