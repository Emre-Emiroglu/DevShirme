using DevShirme.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Settings
{
    [CreateAssetMenu(fileName = "PoolSettings", menuName = "DevShirme/Settings/PoolSettings", order = 0)]
    public class PoolSettings : ScriptableObjectInstaller<PoolSettings>
    {
        #region Fields
        [Header("Pool Settings")]
        [SerializeField] private PoolModel poolModel;
        [SerializeField] private BulletModel bulletModel;
        [SerializeField] private EnemyModel enemyModel;
        #endregion

        #region Bindings
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PoolModel>().FromInstance(poolModel).AsSingle();
            Container.BindInterfacesAndSelfTo<BulletModel>().FromInstance(bulletModel).AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyModel>().FromInstance(enemyModel).AsSingle();
        }
        #endregion
    }
}