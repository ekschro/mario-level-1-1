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
    public class FireballCommand : ICommand
    {
        //private int timer;
        private Game1 myGame;


        public FireballCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            IEnemy fireball = new MarioFireBall(myGame);
            myGame.CurrentLevel.EnemyObjects.Add(fireball);
        }
    }
}