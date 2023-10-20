using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Interfaces
{
    public interface ICameraModel: IInitializable
    {
        public float AmplitudeGain { get; }
        public float FrequencyGain { get; }
        public float ShakeDuration { get; }
        public float ChangeFovDuration { get; }
    }
}

