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
    public class BottomRightPipeBlockSprite : AbstractBlockSprite
    {
        public BottomRightPipeBlockSprite(Game1 game, IBlock bottomRightPipe):base(game,bottomRightPipe)
        {
            utility = new BlockUtilityClass();
            blockObject = (BottomRightPipeBlock)bottomRightPipe;
            currentFrame = utility.CurrentFrame;
        }
    }
}