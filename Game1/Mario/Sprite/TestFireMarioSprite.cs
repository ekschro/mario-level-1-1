using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class TestFireMarioSprite : AbstractTestMarioSprite
    {
        public TestFireMarioSprite(Game1 game, TestFireMario Mario, IPlayer player) : base(game, Mario, player)
        {
        }
    }
}
