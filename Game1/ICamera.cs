using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    interface ICamera
    {
        float CameraPosition { get; set; }
        float CameraOffset { get; set; }
        void Update();
    }
}
