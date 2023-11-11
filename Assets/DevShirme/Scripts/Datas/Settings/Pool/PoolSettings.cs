using DevShirme.Models.Pool;
using UnityEngine;
using Zenject;

namespace DevShirme.Datas.Settings.Pool
{
    [CreateAssetMenu(fileName = "PoolSettings", menuName = "DevShirme/Datas/Settings/PoolSettings", order = 0)]
    public class PoolSettings : ScriptableObjectInstaller<PoolSettings>
    {
        #region Fields
        [Header("Pool Models")]
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
