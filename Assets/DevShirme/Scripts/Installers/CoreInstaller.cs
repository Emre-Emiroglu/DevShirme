using DevShirme.Signals;
using DevShirme.Utils;
using DevShirme.Views;
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
            Container.BindInterfacesAndSelfTo<EnemySpawnerView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerAgentView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<WeaponView>().FromComponentInHierarchy().AsSingle();

            Container.BindInterfacesAndSelfTo<CamView>().FromComponentsInHierarchy().AsTransient().NonLazy();
            Container.BindInterfacesAndSelfTo<UIPanelView>().FromComponentsInHierarchy().AsTransient().NonLazy();

            CoreSignals.Install(Container);
        }
        public override void Start()
        {
            Container.Resolve<SignalBus>().Fire(new Structs.OnChangeGameState { NewGameState = Enums.GameState.Init });
        }
        #endregion
    }
}
