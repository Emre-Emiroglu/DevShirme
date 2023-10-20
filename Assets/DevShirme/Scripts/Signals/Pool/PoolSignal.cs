using DevShirme.Controllers;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Signals
{
    public class PoolSignal: Installer<PoolSignal>
    {
        #region Bindings
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<Structs.OnClearPool>();

            Container.BindSignal<Structs.OnClearPool>().ToMethod<ClearPoolCommand>(x => x.ClearPool).FromNew();
        }
        #endregion
    }
}
