﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class KoopaStateMachine : IEnemyStateMachine
    {
        private IEnemySprite koopaSprite;
        private bool facingLeft = true;
        private enum KoopaHealth { Normal, Stomped, Flipped };
        private KoopaHealth health = KoopaHealth.Normal;
        public KoopaStateMachine(IEnemySprite sprite)
        {
            koopaSprite = sprite;
        }

        public void ChangeDirection()
        {
            if (health == KoopaHealth.Flipped)
            {
                facingLeft = !facingLeft;
                if (facingLeft == true)
                    koopaSprite.ChangeFrame(2, 4);
                else
                    koopaSprite.ChangeFrame(0, 2);
                health = KoopaHealth.Normal;
            }
            else
            { facingLeft = !facingLeft; }
            
        }

        public void BeStomped()
        {
            koopaSprite.ChangeFrame(4, 6);
            koopaSprite.ChangeFrame(5, 6);
            if (health != KoopaHealth.Stomped) 
            {
                health = KoopaHealth.Stomped;
            }
        }

        public void BeFlipped()
        {
            if (health == KoopaHealth.Normal || health == KoopaHealth.Flipped)
            {
                health = KoopaHealth.Flipped;
            }
            else 
            {
                ChangeDirection();
            }
        }

        public void Update()
        {
            if (health == KoopaHealth.Flipped)
            {
                //health = KoopaHealth.Normal;
                ChangeDirection();
            }
        }
        public bool GetDirection()
        {
            return facingLeft;
        }

    }
}
