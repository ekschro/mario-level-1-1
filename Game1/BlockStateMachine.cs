using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class BlockStateMachine
    {
        // brick to nothing
        // hidden to used
        // question to used
        
        private enum BlockState { Used, Empty, };
        private GoombaHealth health = GoombaHealth.Normal;
        public void ToUsed()
        {
            if (BlockState != GoombaHealth.Stomped)
            {
                health = GoombaHealth.Stomped;

            }
        }
        public void ToEmpty()
        {

        }
    }
}
