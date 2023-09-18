using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface ICam: IInitializeable
    {
        public Enums.CamType CameraType { get; }
        public void Show();
        public void Hide();
        public void Shake(float amplitudeGain, float frequencyGain, float shakeDuration);
        public void ChangeFov(float addValue, float duration);
    }
}
