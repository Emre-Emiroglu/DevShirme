using strange.extensions.signal.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Signals
{
    public class PoolSignal
    {
        public Signal OnInitializePool = new Signal();
        public Signal<bool, string> OnClearPool = new Signal<bool, string>();
    }
}
