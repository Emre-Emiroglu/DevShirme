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
        #region Getters
        public AudioSource AudioSource { get; private set;}
        #endregion

        #region Core
        public void Initialize()
        {
            AudioSource = UnityEngine.Object.FindAnyObjectByType<AudioSource>();
        }
        #endregion
    }
}
