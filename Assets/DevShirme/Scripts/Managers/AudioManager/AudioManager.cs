using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Managers.AudioManager
{
    public class AudioManager : Manager
    {
        #region Fields
        private readonly AudioManagerSettings amSettings;
        private readonly AudioSource audioSource;
        #endregion

        #region Core
        public AudioManager(AudioManagerSettings amSettings, AudioSource audioSource) : base()
        {
            this.amSettings = amSettings;
            this.audioSource = audioSource;
        }
        #endregion

        #region PlaySound
        public void PlaySound(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }
        #endregion

        #region Updates
        public override void Tick()
        {
        }
        public override void FixedTick()
        {
        }
        public override void LateTick()
        {
        }
        #endregion
    }
}
