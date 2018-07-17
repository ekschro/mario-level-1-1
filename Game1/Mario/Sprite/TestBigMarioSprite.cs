using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class TestBigMarioSprite : AbstractTestMarioSprite
    {

        public TestBigMarioSprite(Game1 game, TestBigMario Mario, IPlayer player) : base(game, Mario, player)
        {
        }
    }
}
