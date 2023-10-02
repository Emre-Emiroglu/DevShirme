using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class AudioModel: IAudioModel
    {
        #region Fields
        private Settings.AudioSettings audioSettings;
        #endregion

        #region Getters
        public Settings.AudioSettings AudioSettings => audioSettings;
        #endregion

        #region Core
        public void Initialize()
        {
            audioSettings = Resources.Load<Settings.AudioSettings>("Settings/AudioSettings");
        }
        #endregion
    }
}
