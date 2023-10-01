using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class CameraModel : ICameraModel
    {
        private readonly CameraSettings cameraSettings;

        public CameraSettings CameraSettings => cameraSettings;

        public CameraModel()
        {
            cameraSettings = Resources.Load<CameraSettings>("Settings/CameraSettings");
        }
    }
}
