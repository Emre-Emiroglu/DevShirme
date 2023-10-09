using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Controllers
{
    public class PlaySoundCommand
    {
        #region Fields
        private readonly AudioSource audioSource;
        #endregion

        #region Core
        public PlaySoundCommand(AudioSource audioSource)
        {
            this.audioSource = audioSource;
        }
        #endregion

        #region PlaySound
        public void PlaySound(Structs.OnPlaySound onPlaySound) => audioSource.PlayOneShot(onPlaySound.AudioClip);
        #endregion
    }
}
