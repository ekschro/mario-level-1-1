using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class BowserStateMachine : IEnemyStateMachine
    {
        private IEnemySprite bowserSprite;
        private bool facingRight = false;
        public enum BowserHealth { Normal, Flipped, Jump, Fire };
        public BowserHealth health = BowserHealth.Normal;
        private EnemyUtilityClass utility;

        public BowserStateMachine(IEnemySprite sprite)
        {
            utility = new EnemyUtilityClass();
            bowserSprite = sprite;
        }

        public void ChangeDirection(bool right)
        {
            facingRight = right;
            if (facingRight)
                bowserSprite.ChangeSpriteEffects(SpriteEffects.FlipHorizontally);
            else
                bowserSprite.ChangeSpriteEffects(SpriteEffects.None);
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
            //bowserSprite.FlipSprite();
            bowserSprite.ChangeSpriteEffects(SpriteEffects.FlipVertically);
            if (health != BowserHealth.Flipped)
            {
                health = BowserHealth.Flipped;
            }
        }
        public void BeJump()
        {
            if (health != BowserHealth.Jump)
            {
                health = BowserHealth.Jump;
            }
        }

        public void Update()
        {
        }
        public bool GetDirection()
        {
            return facingRight;
        }
    }
}
