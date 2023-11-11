using DevShirme.Interfaces.Audio;
using System;
using UnityEngine;
using Zenject;

namespace DevShirme.Models.Audio
{
    [Serializable]
    public class AudioModel: IAudioModel, IInitializable
    {
        #region Fields
        private AudioSource playerAudioSource;
        private AudioSource inGameAudioSource;
        private AudioSource musicAudioSource;
        private AudioSource uiAudioSource;
        #endregion

        #region Getters
        public AudioSource PlayerAudioSource => playerAudioSource;
        public AudioSource InGameAudioSource => inGameAudioSource;
        public AudioSource MusicAudioSource => musicAudioSource;
        public AudioSource UIAudioSource => uiAudioSource;
        #endregion

        #region Core
        public void Initialize()
        {
            Transform parent = GameObject.Find("AudioSources").transform;

            CreateAudioSources(parent, "PlayerAudioSource", out playerAudioSource);
            CreateAudioSources(parent, "InGameAudioSource", out inGameAudioSource);
            CreateAudioSources(parent, "MusicAudioSource", out musicAudioSource);
            CreateAudioSources(parent, "UIAudioSource", out uiAudioSource);
        }
        #endregion

        #region Creates
        private void CreateAudioSources(Transform parent, string name, out AudioSource audioSource)
        {
            GameObject obj = UnityEngine.Object.Instantiate(new GameObject(), parent.transform);
            obj.name = name;
            audioSource = obj.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.loop = false;
        }
        #endregion
    }
}
