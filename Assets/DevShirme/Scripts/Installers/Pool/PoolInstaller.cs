using DevShirme.Mediators;
using DevShirme.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Installers
{
    public class PoolInstaller : MonoInstaller<PoolInstaller>
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PoolObjectMediator>().AsTransient();
            Container.BindInterfacesAndSelfTo<BulletMediator>().AsTransient();
            Container.BindInterfacesAndSelfTo<EnemyMediator>().AsTransient();

            PoolSignal.Install(Container);
        }
        #endregion  
    }
}
