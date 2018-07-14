﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class GoombaStateMachine : IEnemyStateMachine
    {
        private IEnemySprite goombaSprite;
        private bool facingLeft = false;
        private enum GoombaHealth { Normal, Stomped, Flipped };
        private GoombaHealth health = GoombaHealth.Normal;
        private EnemyUtilityClass utility;

        public GoombaStateMachine(IEnemySprite sprite)
        {
            utility = new EnemyUtilityClass();
            goombaSprite = sprite;
        }

        public void ChangeDirection()
        {
            facingLeft = !facingLeft;
        }

        public void BeStomped()
        {
            //goombaSprite.ChangeFrame(2, 3);
            // goombaSprite.ChangeFrame(3, 4);
            goombaSprite.ChangeFrame(utility.GoombaStompedStartFrame, utility.GoombaStompedEndFrame);
            if (health != GoombaHealth.Stomped) 
            {
                health = GoombaHealth.Stomped;

            }
        }

        public void BeFlipped()
        {
            goombaSprite.FlipSprite();
            if (health != GoombaHealth.Flipped) 
            {
                health = GoombaHealth.Flipped;
            }
        }

        public void Update()
        {
        }
        public bool GetDirection()
        {
            return facingLeft;
        }

    }
}
