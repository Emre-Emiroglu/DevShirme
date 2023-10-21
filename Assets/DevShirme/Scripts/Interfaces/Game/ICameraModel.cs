using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface ICameraModel
    {
        public float AmplitudeGain { get; }
        public float FrequencyGain { get; }
        public float ShakeDuration { get; }
        public float ChangeFovDuration { get; }
    }
}

