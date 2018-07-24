using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class CameraSliding : ICamera
    {
        private float cameraPosition;
        private float cameraOffset;
        private float finalPosition;

        public float CameraPosition { get => cameraPosition; set => cameraPosition = value; }
        public float CameraOffset { get => cameraOffset; set => cameraOffset = value; }

        public CameraSliding(ILevel level, int startPosition, int endPosition)
        {
            cameraPosition = startPosition;
            finalPosition = endPosition;
        }

        public void Update()
        {
            if (cameraPosition < finalPosition)
                cameraPosition++;
        }

        public float PositionRelativeToCamera(float objectPosition)
        {
            return objectPosition - CameraPosition;
        }
    }
}
