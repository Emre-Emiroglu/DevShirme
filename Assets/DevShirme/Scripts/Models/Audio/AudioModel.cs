using DevShirme.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    [Serializable]
    public class AudioModel: IAudioModel
    {
        #region Fields
        private Transform audioSourceTransform;
        private AudioSource audioSource;
        #endregion

        #region Getters
        public AudioSource AudioSource => audioSource;
        #endregion

        #region Core
        public void Initialize()
        {
            audioSourceTransform = GameObject.Find("AudioSource").GetComponent<Transform>();
            audioSource = audioSourceTransform?.GetComponent<AudioSource>();
        }
        #endregion
    }
}
