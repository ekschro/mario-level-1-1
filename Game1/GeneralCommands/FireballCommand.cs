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
            bool hasFireball = false;
            if (Mario.MarioSprite.isFire())
            {
                foreach (IEnemy obj in myGame.CurrentLevel.EnemyObjects)
                {
                    if (obj is MarioFireBall)
                        hasFireball = true;
                }

                if(!hasFireball)
                    myGame.CurrentLevel.EnemyObjects.Add(new MarioFireBall(myGame));
            }
        }

    }
}