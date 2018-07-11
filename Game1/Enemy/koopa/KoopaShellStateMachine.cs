using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class KoopaSStateMachine : IEnemyStateMachine
    {
        private IEnemySprite koopaSprite;
        private bool facingLeft = true;
        private enum KoopaHealth { Normal, Stomped };
        private KoopaHealth health = KoopaHealth.Normal;
        public KoopaSStateMachine(IEnemySprite sprite)
        {
            koopaSprite = sprite;
        }

        public void ChangeDirection()
        {
            facingLeft = !facingLeft;
            
        }

        public void BeStomped()
        {
            koopaSprite.ChangeFrame(5, 6);
            if (health != KoopaHealth.Stomped) 
            {
                health = KoopaHealth.Stomped;
            }
        }

        public void BeFlipped()
        {

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
