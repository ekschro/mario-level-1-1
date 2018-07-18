using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class CameraStatic : ICamera
    {
        private float cameraPosition;
        private float cameraOffset;
        //private ILevel gameLevel;

        public float CameraPosition { get => cameraPosition; set => cameraPosition = value; }
        public float CameraOffset { get => cameraOffset; set => cameraOffset = value; }

        public CameraStatic(ILevel level, int position)
        {
            cameraPosition = position;
            //gameLevel = level;
        }

        public void Update()
        {
        }

        public float PositionRelativeToCamera(float objectPosition)
        {
            return objectPosition - CameraPosition;
        }
    }
}
