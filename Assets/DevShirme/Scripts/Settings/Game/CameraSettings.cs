using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Settings
{
    [CreateAssetMenu(fileName = "CameraSettings", menuName = "DevShirme/Settings/CameraSettings", order = 1)]
    public class CameraSettings : ScriptableObject
    {
        #region Fields
        [Header("Shake Settings")]
        [Range(0f, 1f)][SerializeField] private float amplitudeGain = 1f;
        [Range(0f, 1f)][SerializeField] private float frequencyGain = 1f;
        [Range(0f, 1f)][SerializeField] private float shakeDuration = 1f;
        [Header("Fov Change Settings")]
        [Range(0f, 1f)][SerializeField] private float changeFovDuration = 1f;
        #endregion

        #region Getters
        public float AmplitudeGain => amplitudeGain;
        public float FrequencyGain => frequencyGain;
        public float ShakeDuration => shakeDuration;
        public float ChangeFovDuration => changeFovDuration;
        #endregion
    }
}
