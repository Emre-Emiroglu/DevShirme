using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Interfaces
{
    public interface IAudioModel: IInitializable
    {
        public AudioSource AudioSource { get; }
    }
}
