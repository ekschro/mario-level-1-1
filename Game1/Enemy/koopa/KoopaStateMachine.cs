using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

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

        public void ChangeDirection(bool left)
        {
            if (health == KoopaHealth.Flipped)
            {
                facingLeft = !facingLeft;
                if (facingLeft == false)
                    koopaSprite.ChangeFrame(utility.KoopaRightStartFrame, utility.KoopaRightEndFrame);
                else
                    koopaSprite.ChangeFrame(utility.KoopaLeftStartFrame, utility.KoopaLeftEndFrame);
                health = KoopaHealth.Normal;
            }


            facingLeft = !facingLeft; 
            
        }

        public void BeStomped()
        {
            koopaSprite.ChangeFrame(utility.KoopaShellStartFrame, utility.KoopaShellEndFrame);
            koopaSprite.ChangeFrame(5, utility.KoopaShellEndFrame);
            if (health != KoopaHealth.Stomped) 
            {
                health = KoopaHealth.Stomped;
            }
        }

        public void BeFlipped()
        {
            //koopaSprite.FlipSprite();
            koopaSprite.ChangeSpriteEffects(SpriteEffects.FlipVertically);
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

        public void BeJump()
        {
            throw new NotImplementedException();
        }
    }
}
