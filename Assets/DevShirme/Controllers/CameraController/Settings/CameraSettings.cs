using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.CameraModule
{
    [CreateAssetMenu(fileName = "Camera Settings", menuName = "DevShirme/Settings/Camera Settings", order = 1)]
    public class CameraSettings : DevSettings
    {
        #region Fields
        [Header("Camera Settings Fields")]
        [SerializeField] private float duration;
        [SerializeField] private AnimationCurve curve;
        #endregion

        #region Getters
        public float Duration => duration;
        public AnimationCurve Curve => curve;
        #endregion
    }
}

