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
        private
            BowserHealth health = BowserHealth.Normal;
       

        public BowserStateMachine(IEnemySprite sprite)
        {
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
        
        }
        public void BeFlipped()
        {
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
