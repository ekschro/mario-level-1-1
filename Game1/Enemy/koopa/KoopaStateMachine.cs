using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class KoopaStateMachine : IEnemyStateMachine
    {
        //private IEnemySprite koopaSprite;
        private bool facingLeft = true;
        private enum KoopaHealth { Normal, Stomped, Flipped };
        private KoopaHealth health = KoopaHealth.Normal;


        public void ChangeDirection()
        {
            facingLeft = !facingLeft;
        }


        public void BeStomped()
        {
            //koopaSprite.ChangeFrame(4, 6);
            //koopaSprite.ChangeFrame(5, 6);
            if (health != KoopaHealth.Stomped) 
            {
                health = KoopaHealth.Stomped;
            }
        }

        public void BeFlipped()
        {
            if (health != KoopaHealth.Flipped)
            {
                health = KoopaHealth.Flipped;
            }
        }

        public void Update()
        {
            if (health == KoopaHealth.Flipped)
            {
                ChangeDirection();
                health = KoopaHealth.Normal;
            }
            if (health == KoopaHealth.Stomped)
            {

            }
        }
    }
}
