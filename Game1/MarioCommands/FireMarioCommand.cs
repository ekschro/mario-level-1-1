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
    public class FireMarioCommand : ICommand
    {
        private Game1 myGame;
        

        public FireMarioCommand(Game1 game)
        {
            myGame = game;
            
        }

        public void Execute()
        {
            Mario.marioSprite.FireMarioCommandCalled();
        }
    }
}