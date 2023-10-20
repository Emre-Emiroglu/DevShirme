using DevShirme.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Installers
{
    public class CoreInstaller : MonoInstaller<CoreInstaller>
    {
        #region Bindings
        public override void InstallBindings()
        {
            CoreSignals.Install(Container);
        }
        public override void Start()
        {
        }
        #endregion
    }
}
