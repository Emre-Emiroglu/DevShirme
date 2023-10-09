using DevShirme.Interfaces;
using strange.extensions.context.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class AudioModel: IAudioModel
    {
        #region Injects
        [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextView { get; set; }
        #endregion

        #region Fields
        private readonly Settings.AudioSettings audioSettings;
        private AudioSource audioSource;
        #endregion

        #region Getters
        public Settings.AudioSettings AudioSettings => audioSettings;
        public AudioSource AudioSource => audioSource;
        #endregion

        #region Core
        public AudioModel()
        {
            audioSettings = Resources.Load<Settings.AudioSettings>("Settings/AudioSettings");
        }
        [PostConstruct]
        public void PostConstruct()
        {
            audioSource = ContextView.GetComponent<AudioSource>();
        }
        #endregion
    }
}
