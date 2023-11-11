using UnityEngine;

namespace DevShirme.Interfaces.Audio
{
    public interface IAudioModel
    {
        public AudioSource PlayerAudioSource { get; }
        public AudioSource InGameAudioSource { get; }
        public AudioSource MusicAudioSource { get; }
        public AudioSource UIAudioSource { get; }
    }
}
