using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class CameraModel : ICameraModel
    {
        #region Fields
        private readonly CameraSettings cameraSettings;
        #endregion

        #region Getters
        public CameraSettings CameraSettings => cameraSettings;
        #endregion

        #region Core
        public CameraModel()
        {
            cameraSettings = Resources.Load<CameraSettings>("Settings/CameraSettings");
        }
        #endregion
    }
}
