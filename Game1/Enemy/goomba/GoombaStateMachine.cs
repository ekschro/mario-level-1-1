using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class GoombaStateMachine : IEnemyStateMachine
    {
        private IEnemySprite goombaSprite;
        private bool facingLeft = false;
        private enum GoombaHealth { Normal, Stomped, Flipped };
        private GoombaHealth health = GoombaHealth.Normal;
        private EnemyUtilityClass utility;

        public GoombaStateMachine(IEnemySprite sprite)
        {
            utility = new EnemyUtilityClass();
            goombaSprite = sprite;
        }

        public void ChangeDirection(bool left)
        {
            facingLeft = !facingLeft;
        }

        public void BeStomped()
        {
           
            goombaSprite.ChangeFrame(utility.GoombaStompedStartFrame, utility.GoombaStompedEndFrame);
            if (health != GoombaHealth.Stomped) 
            {
                health = GoombaHealth.Stomped;

            }
        }

        public void BeFlipped()
        {
           
            goombaSprite.ChangeSpriteEffects(SpriteEffects.FlipVertically);
            if (health != GoombaHealth.Flipped) 
            {
                health = GoombaHealth.Flipped;
            }
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
