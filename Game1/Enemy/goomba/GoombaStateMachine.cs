using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class GoombaStateMachine : IEnemyStateMachine
    {
        private IEnemySprite goombaSprite;
        private bool facingLeft = true;
        private enum GoombaHealth { Normal, Stomped, Flipped };
        private GoombaHealth health = GoombaHealth.Normal;

        public GoombaStateMachine(IEnemySprite sprite)
        {
            goombaSprite = sprite;
        }

        public void ChangeDirection()
        {
            facingLeft = !facingLeft;

        }

        public void BeStomped()
        {
            goombaSprite.ChangeFrame(2, 3);
            goombaSprite.ChangeFrame(3, 4);
            if (health != GoombaHealth.Stomped) 
            {
                health = GoombaHealth.Stomped;

            }
        }

        public void BeFlipped()
        {
            if (health != GoombaHealth.Flipped) 
            {
                health = GoombaHealth.Flipped;

            }
        }

        public void Update()
        {
            if (health == GoombaHealth.Flipped)
            {
                ChangeDirection();
                health = GoombaHealth.Normal;
            }
        }
    }
}
