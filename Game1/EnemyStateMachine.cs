using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public interface IEnemyStateMachine
    {
        void ChangeDirection();
        void BeStomped();
        void BeFlipped();
        void Update();
    }
    public class GoombaStateMachine :IEnemyStateMachine
    {
        private bool facingLeft = true;
        private enum GoombaHealth { Normal, Stomped, Flipped };
        private GoombaHealth health = GoombaHealth.Normal;


        public void ChangeDirection()
        {
            facingLeft = !facingLeft;
        }

        public void BeStomped()
        {
            if (health != GoombaHealth.Stomped) // Note: the if is needed so we only do the transition once
            {
                health = GoombaHealth.Stomped;
                // Compute and construct goomba sprite - requires if-else logic with value of health
            }
        }

        public void BeFlipped()
        {
            if (health != GoombaHealth.Flipped) // Note: the if is needed so we only do the transition once
            {
                health = GoombaHealth.Flipped;
                // Compute and construct goomba sprite - requires if-else logic with value of health
            }
        }

        public void Update()
        {
            if (health == GoombaHealth.Flipped)
            {
                ChangeDirection();
                health = GoombaHealth.Normal;
            }
            // if-else logic based on the current values of facingLeft and health to determine how to move
        }
    }
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
            if (health != KoopaHealth.Stomped) // Note: the if is needed so we only do the transition once
            {
                health = KoopaHealth.Stomped;
                // Compute and construct goomba sprite - requires if-else logic with value of health
            }
        }

        public void BeFlipped()
        {
            if (health != KoopaHealth.Flipped) // Note: the if is needed so we only do the transition once
            {
                health = KoopaHealth.Flipped;
                // Compute and construct goomba sprite - requires if-else logic with value of health
            }
        }

        public void Update()
        {
            if (health == KoopaHealth.Flipped)
            {
                ChangeDirection();
                health = KoopaHealth.Normal;
            }
            // if-else logic based on the current values of facingLeft and health to determine how to move
        }
    }
}
