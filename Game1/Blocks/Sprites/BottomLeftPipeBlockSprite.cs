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
    public class BottomLeftPipeBlockSprite : AbstractBlockSprite
    {
        

        public BottomLeftPipeBlockSprite(Game1 game, IBlock bottomLeftPipe) : base(game,bottomLeftPipe)
        {
            utility = new BlockUtilityClass();
            blockObject = (BottomLeftPipeBlock)bottomLeftPipe;
            currentFrame = utility.jumpDistanceOrCurrentFrame;
        }
    }
}