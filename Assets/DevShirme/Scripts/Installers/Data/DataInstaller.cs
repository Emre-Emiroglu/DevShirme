using DevShirme.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Installers
{
    public class DataInstaller : MonoInstaller<DataInstaller>
    {
        #region Bindings
        public override void InstallBindings()
        {
            DataSignal.Install(Container);
        }
        #endregion  
    }
}
