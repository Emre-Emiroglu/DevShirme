using DevShirme.Controllers;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Signals
{
    public class AudioSignal: Installer<AudioSignal>
    {
        #region Bindings
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<Structs.OnPlaySound>();

            Container.BindSignal<Structs.OnPlaySound>().ToMethod<PlaySoundCommand>(x => x.PlaySound);
        }
        #endregion
    }
}
