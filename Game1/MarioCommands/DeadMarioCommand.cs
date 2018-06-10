﻿using System;

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
        private Mario marioObject;

        public DeadMarioCommand(Game1 game, Mario mario)
        {
            myGame = game;
            marioObject = mario;
        }

        public void Execute()
        {
            marioObject.marioSprite.DeadMarioCommandCalled();
        }
    }
}