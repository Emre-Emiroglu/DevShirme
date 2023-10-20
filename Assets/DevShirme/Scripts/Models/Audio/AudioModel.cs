using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class AudioModel: IAudioModel
    {
        #region Fields
        private Transform audioSourceTransform;
        private readonly AudioSource audioSource;
        #endregion

        #region Getters
        public AudioSource AudioSource => audioSource;
        #endregion

        #region Core
        public AudioModel()
        {
            audioSourceTransform = GameObject.Find("AudioInstaller").GetComponent<Transform>();
            audioSource = audioSourceTransform?.GetComponent<AudioSource>();
        }
        #endregion
    }
}
