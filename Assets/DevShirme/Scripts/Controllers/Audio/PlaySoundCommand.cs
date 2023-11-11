using DevShirme.Models.Audio;
using DevShirme.Utils.Enums;
using DevShirme.Utils.Structs;
using UnityEngine;

namespace DevShirme.Controllers.Audio
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
        public void PlaySound(Structs.OnPlaySound onPlaySound)
        {
            AudioSource source = null;

            switch (onPlaySound.AudioSourceType)
            {
                case Enums.AudioSourceTypes.PlayerAudioSource:
                    source = audioModel.PlayerAudioSource;
                    break;
                case Enums.AudioSourceTypes.InGameAudioSource:
                    source = audioModel.InGameAudioSource;
                    break;
                case Enums.AudioSourceTypes.MusicAudioSource:
                    source = audioModel.MusicAudioSource;
                    break;
                case Enums.AudioSourceTypes.UIAudioSource:
                    source = audioModel.UIAudioSource;
                    break;
            }

            source.PlayOneShot(onPlaySound.AudioClip);
        }
        #endregion
    }
}
