using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class NoCommand : ICommand
    {
        private IPlayer player;

        public NoCommand(Game1 game)
        {
            player = game.CurrentLevel.PlayerObject;
        }

        public void Execute()
        {
            player.MovingDown = false;
            player.MovingUp = false;
            player.MovingRight = false;
            player.MovingLeft = false;
        }
    }
}
