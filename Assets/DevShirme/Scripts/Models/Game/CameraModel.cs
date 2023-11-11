using DevShirme.Interfaces.Game;
using System;
using UnityEngine;

namespace DevShirme.Models.Game
{
    [Serializable]
    public class CameraModel : ICameraModel
    {
        #region Fields
        [Header("Camera Model Settings")]
        [Range(0f, 1f)][SerializeField] private float amplitudeGain = 1f;
        [Range(0f, 1f)][SerializeField] private float frequencyGain = 1f;
        [Range(0f, 1f)][SerializeField] private float shakeDuration = 1f;
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
