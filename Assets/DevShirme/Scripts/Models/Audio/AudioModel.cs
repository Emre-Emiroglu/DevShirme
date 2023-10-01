using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class AudioModel: IAudioModel
    {
        private readonly Settings.AudioSettings audioSettings;

        public Settings.AudioSettings AudioSettings => audioSettings;

        public AudioModel()
        {
            audioSettings = Resources.Load<Settings.AudioSettings>("Settings/AudioSettings");
        }
    }
}
