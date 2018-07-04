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
        private IPlayer player;

        public FireballCommand(Game1 game)
        {
            myGame = game;
            player = game.CurrentLevel.PlayerObject;
        }

        public void Execute()
        {
            if(myGame.CurrentLevel.PlayerObject is Mario)
            {
                ((MarioPhysics)(Mario.physics)).RunningCheck();
            }

            
            bool hasFireball = false;
            if (player.MarioSprite.isFire())
            {
                foreach (IEnemy obj in myGame.CurrentLevel.EnemyObjects)
                {
                    if (obj is MarioFireBall)
                        hasFireball = true;
                }

                if(!hasFireball)
                    myGame.CurrentLevel.EnemyObjects.Add(new MarioFireBall(myGame));
                    
            }else if(myGame.CurrentLevel.PlayerObject is Mario)
            {
                IPhysics physics = Mario.physics;
                ((MarioPhysics)physics).RunningCheck();
            }
        }

    }
}
 