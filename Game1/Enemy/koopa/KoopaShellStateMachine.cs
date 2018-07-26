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
        private EnemyUtilityClass utility;

        public KoopaSStateMachine(IEnemySprite sprite)
        {
            utility = new EnemyUtilityClass();
            koopaSprite = sprite;
        }

        public void ChangeDirection(bool left)
        {
            facingLeft = !facingLeft;
            
        }

        public void BeStomped()
        {
            koopaSprite.ChangeFrame(utility.KoopaShellStompedStartFrame, utility.KoopaShellEndFrame);
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
        public bool Direction => facingLeft;

        public void BeJump()
        {
            throw new NotImplementedException();
        }
    }
}
