using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Camera : ICamera
    {
        private float cameraPosition;
        private float cameraOffset;
        private ILevel gameLevel;

        public float CameraPosition { get => cameraPosition; set => cameraPosition = value; }
        public float CameraOffset { get => cameraOffset; set => cameraOffset = value; }

        public Camera(ILevel level)
        {
            cameraPosition = 0;
            cameraOffset = 200;
            gameLevel = level;
        }

        public void Update()
        {
            if (gameLevel.PlayerObject.CurrentXPos > CameraPosition + cameraOffset)
                CameraPosition += (gameLevel.PlayerObject.CurrentXPos - CameraPosition) - cameraOffset;
        }
    }
}
