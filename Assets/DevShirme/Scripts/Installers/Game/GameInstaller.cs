using DevShirme.Mediators;
using DevShirme.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UIPanelMediator>().AsTransient();
            Container.BindInterfacesAndSelfTo<UIButtonMediator>().AsTransient();
            Container.BindInterfacesAndSelfTo<PlayerAgentMediator>().AsSingle();
            Container.BindInterfacesAndSelfTo<WeaponMediator>().AsSingle();
            Container.BindInterfacesAndSelfTo<CamMediator>().AsTransient();
            Container.BindInterfacesAndSelfTo<EnemySpawnerMediator>().AsSingle();

            GameSignal.Install(Container);
        }
        #endregion
    }
}
