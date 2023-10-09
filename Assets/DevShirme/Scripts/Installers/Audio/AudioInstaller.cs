using DevShirme.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Contexts
{
    public class AudioInstaller : MonoInstaller<AudioInstaller>
    {
        #region Bindings
        public override void InstallBindings()
        {
            AudioSignal.Install(Container);
        }
        #endregion
    }
}
