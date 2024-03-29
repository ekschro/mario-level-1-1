﻿using System;
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
        private float levelEnd;

        public float CameraPosition { get => cameraPosition; set => cameraPosition = value; }
        public float CameraOffset { get => cameraOffset; set => cameraOffset = value; }

        public Camera(ILevel level)
        {
            cameraPosition = 0;
            cameraOffset = 200;
            gameLevel = level;
            levelEnd = 2960;
        }

        public void Update()
        {
            if (gameLevel.PlayerObject.GameObjectLocation.X > CameraPosition + cameraOffset && CameraPosition < levelEnd)
                CameraPosition += (gameLevel.PlayerObject.GameObjectLocation.X - CameraPosition) - cameraOffset;
        }

        public float PositionRelativeToCamera(float objectPosition)
        {
            return objectPosition - CameraPosition;
        }
    }
}
