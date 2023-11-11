using DevShirme.Signals;
using DevShirme.Utils.Enums;
using DevShirme.Utils.Structs;
using DevShirme.Views.Cam;
using DevShirme.Views.EnemySpawner;
using DevShirme.Views.PlayerAgent;
using DevShirme.Views.PlayerAgent.AgentHandlers;
using DevShirme.Views.UI;
using DevShirme.Views.Weapon;
using Zenject;

namespace DevShirme.Installers
{
    public class CoreInstaller : MonoInstaller<CoreInstaller>
    {
        #region Bindings
        public override void InstallBindings()
        {
            #region PlayerAgent
            Container.BindInterfacesAndSelfTo<PCInputHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<MovementHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<RotationHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<WeaponHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerAgentView>().FromComponentInHierarchy().AsSingle();
            #endregion

            Container.BindInterfacesAndSelfTo<EnemySpawnerView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<WeaponView>().FromComponentInHierarchy().AsSingle();

            Container.BindInterfacesAndSelfTo<CamView>().FromComponentsInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<UIPanelView>().FromComponentsInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<UIButtonView>().FromComponentsInHierarchy().AsSingle().NonLazy();

            CoreSignals.Install(Container);
        }
        public override void Start()
        {
            Container.Resolve<SignalBus>().Fire(new Structs.OnChangeGameState { NewGameState = Enums.GameState.Init });
        }
        #endregion
    }
}
