using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Settings
{
    [CreateAssetMenu(fileName = "AudioSettings", menuName = "DevShirme/Settings/AudioSettings", order = 0)]
    public class AudioSettings : ScriptableObject
    {
        #region Fields
        [SerializeField] private AudioSource audioSource;
        #endregion

        #region Getters
        public AudioSource AudioSource => audioSource;
        #endregion
    }
}
