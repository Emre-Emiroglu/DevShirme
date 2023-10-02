using DevShirme.Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IAudioModel: IInitializable
    {
        public Settings.AudioSettings AudioSettings { get; }
    }
}
