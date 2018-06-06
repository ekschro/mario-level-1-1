using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class KoopaStateMachine : IEnemyStateMachine
    {
        private bool facingLeft = true;
        private enum KoopaHealth { Normal, Stomped, Flipped };
        private KoopaHealth health = KoopaHealth.Normal;


        public void ChangeDirection()
        {
            facingLeft = !facingLeft;
        }


        public void BeStomped()
        {
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
