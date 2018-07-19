using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class BowserStateMachine : IEnemyStateMachine
    {
        private IEnemySprite bowserSprite;
        private bool facingLeft = false;
        private enum BowserHealth { Normal, Flipped, Jump, Fire };
        private BowserHealth health = BowserHealth.Normal;
        private EnemyUtilityClass utility;

        public BowserStateMachine(IEnemySprite sprite)
        {
            utility = new EnemyUtilityClass();
            bowserSprite = sprite;
        }

        public void ChangeDirection()
        {
            facingLeft = !facingLeft;
            bowserSprite.ChangeDirectionSprite();
        }

        public void BeStomped()
        {
            /*
            bowserSprite.ChangeFrame(utility.BowserStompedStartFrame, utility.BowserStompedEndFrame);
            if (health != BowserHealth.Stomped)
            {
                health = BowserHealth.Stomped;

            }
            */
        }

        public void BeFlipped()
        {
            bowserSprite.FlipSprite();
            if (health != BowserHealth.Flipped)
            {
                health = BowserHealth.Flipped;
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
