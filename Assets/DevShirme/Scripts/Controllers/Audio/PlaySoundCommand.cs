using DevShirme.Models;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Controllers
{
    public class PlaySoundCommand
    {
        #region Fields
        private readonly AudioModel audioModel;
        #endregion

        #region Core
        public PlaySoundCommand(AudioModel audioModel)
        {
            this.audioModel = audioModel;
        }
        #endregion

        #region PlaySound
        public void PlaySound(Structs.OnPlaySound onPlaySound) => audioModel.AudioSource.PlayOneShot(onPlaySound.AudioClip);
        #endregion
    }
}
