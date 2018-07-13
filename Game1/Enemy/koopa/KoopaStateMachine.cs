using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class KoopaStateMachine : IEnemyStateMachine
    {
        private IEnemySprite koopaSprite;
        private bool facingLeft = false;
        private enum KoopaHealth { Normal, Stomped, Flipped };
        private KoopaHealth health = KoopaHealth.Normal;
        private EnemyUtilityClass utility;
        public KoopaStateMachine(IEnemySprite sprite)
        {
            utility = new EnemyUtilityClass();
            koopaSprite = sprite;
        }

        public void ChangeDirection()
        {
            if (health == KoopaHealth.Flipped)
            {
                facingLeft = !facingLeft;
                if (facingLeft == false)
                    //koopaSprite.ChangeFrame(0, 2);
                    koopaSprite.ChangeFrame(utility.KoopaRightStartFrame, utility.KoopaRightEndFrame);
                else
                    //koopaSprite.ChangeFrame(2, 4);
                    koopaSprite.ChangeFrame(utility.KoopaLeftStartFrame, utility.KoopaLeftEndFrame);
                health = KoopaHealth.Normal;
            }


            facingLeft = !facingLeft; 
            
        }

        public void BeStomped()
        {
            //koopaSprite.ChangeFrame(4, 6);
            koopaSprite.ChangeFrame(utility.KoopaShellStartFrame, utility.KoopaShellEndFrame);
            //koopaSprite.ChangeFrame(5, 6);
            koopaSprite.ChangeFrame(5, utility.KoopaShellEndFrame);
            if (health != KoopaHealth.Stomped) 
            {
                health = KoopaHealth.Stomped;
            }
        }

        public void BeFlipped()
        {
            koopaSprite.FlipSprite();
            if (health != KoopaHealth.Flipped)
            {
                health = KoopaHealth.Flipped;
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
