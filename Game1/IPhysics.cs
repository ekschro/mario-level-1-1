using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public interface IPhysics
    {
        void Update();
        void NewPosX();
        void NewPosY();
        float XVelocity { get; }
    }
}
