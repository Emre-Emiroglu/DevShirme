using DevShirme.Controllers;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Signals
{
    public class CoreSignals : Installer<CoreSignals>
    {
        #region Bindings
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<Structs.OnClearPool>();

            Container.DeclareSignal<Structs.OnPlaySound>();

            Container.DeclareSignal<Structs.OnChangeGameState>();
            Container.DeclareSignal<Structs.OnShowAD>();
            Container.DeclareSignal<Structs.OnShakeCam>();
            Container.DeclareSignal<Structs.OnChangeCamFov>();
            Container.DeclareSignal<Structs.OnWeaponCanShoot>();

            Container.BindSignal<Structs.OnClearPool>().ToMethod<ClearPoolCommand>(x => x.ClearPool).FromNew();

            Container.BindSignal<Structs.OnPlaySound>().ToMethod<PlaySoundCommand>(x => x.PlaySound).FromNew();

            Container.BindSignal<Structs.OnChangeGameState>().ToMethod<ChangeGameStateCommand>(x => x.ChangeGameState).FromNew();
            Container.BindSignal<Structs.OnShowAD>().ToMethod<ShowADCommand>(x => x.ShowAD).FromNew();
        }
        #endregion
    }
}
