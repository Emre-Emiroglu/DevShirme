using DevShirme.Interfaces;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Controllers
{
    public class PlaySoundCommand : Command
    {
        #region Injects
        [Inject] public IAudioModel AudioModel { get; set; }
        [Inject] public AudioClip AudioClip { get; set; }
        #endregion

        #region Executes
        public override void Execute()
        {
            playSound();
        }
        #endregion

        #region PlaySound
        private void playSound()
        {
            AudioModel.AudioSource.PlayOneShot(AudioClip);
        }
        #endregion
    }
}
