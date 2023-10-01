using strange.extensions.signal.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Signals
{
    public class AudioSignal
    {
        public Signal<AudioClip> OnPlaySound = new Signal<AudioClip>();
    }
}
