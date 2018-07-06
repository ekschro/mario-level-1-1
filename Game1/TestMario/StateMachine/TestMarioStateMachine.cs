using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class TestMarioStateMachine : ITestMarioStateMachine
    {
        private ITestMarioSprite marioSprite;
        private bool facingLeft = false;
        private enum MarioSize { Small, Big, Fire};
        private enum MarioState {Idle, Walking, Jumping, Crouching};
        private MarioSize size = MarioSize.Small;
        private MarioState state = MarioState.Idle;
        public TestMarioStateMachine(ITestMarioSprite sprite)
        {
            marioSprite = sprite;
        }
        public void ChangeDirection()
        {
            facingLeft = !facingLeft;
        }
        public void Upgrade()
        {
            if (size == MarioSize.Small)
            {
                size = MarioSize.Big;
            }
            else if (size == MarioSize.Big)
            {
                size = MarioSize.Fire;
            }
            else { size = MarioSize.Fire; }
        }
        public void Downgrade()
        {
            if (size == MarioSize.Fire)
            {
                size = MarioSize.Big;
            }
            else if (size == MarioSize.Big)
            {
                size = MarioSize.Small;
            }
            else
            {
                size = MarioSize.Small;
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
