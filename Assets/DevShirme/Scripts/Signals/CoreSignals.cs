using DevShirme.Controllers.Audio;
using DevShirme.Controllers.Game;
using DevShirme.Controllers.Pool;
using DevShirme.Utils.Structs;
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
            Container.DeclareSignal<Structs.OnShakeCam>();
            Container.DeclareSignal<Structs.OnChangeCamFov>();
            Container.DeclareSignal<Structs.OnWeaponCanShoot>();

            Container.BindSignal<Structs.OnClearPool>().ToMethod<ClearPoolCommand>(x => x.ClearPool).FromNew();

            Container.BindSignal<Structs.OnPlaySound>().ToMethod<PlaySoundCommand>(x => x.PlaySound).FromNew();

            Container.BindSignal<Structs.OnChangeGameState>().ToMethod<ChangeGameStateCommand>(x => x.ChangeGameState).FromNew();
        }
        #endregion
    }
}
