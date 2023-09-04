using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.CameraModule
{
    [CreateAssetMenu(fileName = "CameraSettings", menuName = "DevShirme/Settings/ModuleSettings/CameraSettings", order = 1)]
    public class CameraSettings : ScriptableObject
    {
        #region Fields
        [Header("Included Controllers")]
        [SerializeField] private Enums.CameraModuleControllerType controllers;
        [Header("Controllers Settings")]
        [SerializeField] private ScriptableObject[] controllersSettings;
        [Header("Shake Settings")]
        [Range(0f, 1f)][SerializeField] private float amplitudeGain = 1f;
        [Range(0f, 1f)][SerializeField] private float frequencyGain = 1f;
        [Range(0f, 1f)][SerializeField] private float shakeDuration = 1f;
        [Header("Fov Change Settings")]
        [Range(0f, 1f)][SerializeField] private float fovChangeDuration = 1f;
        #endregion

        #region Getters
        public Enums.CameraModuleControllerType Controllers => controllers;
        public ScriptableObject[] ControllersSettings => controllersSettings;
        public float AmplitudeGain => amplitudeGain;
        public float FrequencyGain => frequencyGain;
        public float ShakeDuration => shakeDuration;
        public float FovChangeDuration => fovChangeDuration;
        #endregion
    }
}
