using DevShirme.Utils;
using strange.extensions.signal.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Signals
{
    public class PoolSignal
    {
        public Signal<Structs.SpawnData> OnSpawn = new Signal<Structs.SpawnData>();
        public Signal<bool, string> OnClearPool = new Signal<bool, string>();
    }
}
