using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class BowserThinking
    {
        private IPlayer player;
        private Bowser bowser;
        public BowserThinking()
        { }

        public void Update()
        {
            if (player.Jumping)
            {
                bowser.BeJumped();
            }
            else if (player.CurrentXPos > bowser.CurrentXPos)
            {
                bowser.ChangeDirection(true);
            }
        }
    }
}
