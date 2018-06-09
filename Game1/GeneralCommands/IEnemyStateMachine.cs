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
    
    
}
