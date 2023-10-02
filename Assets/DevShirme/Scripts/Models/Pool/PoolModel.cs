using DevShirme.Interfaces;
using DevShirme.Settings;
using strange.extensions.context.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class PoolModel : IPoolModel
    {
        #region Injects
        [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextView { get; set; }
        #endregion

        #region Fields
        private readonly PoolSettings poolSettings;
        private ObjectPool[] objectPools;
        #endregion

        #region Getters
        public PoolSettings PoolSettings => poolSettings;
        public ObjectPool[] ObjectPools => objectPools;
        #endregion

        #region Core
        public PoolModel()
        {
            poolSettings = Resources.Load<PoolSettings>("Settings/PoolSettings");

            objectPools = new ObjectPool[poolSettings.Prefabs.Length];
        }
        [PostConstruct]
        public void PostConstruct()
        {
            for (int i = 0; i < poolSettings.Prefabs.Length; i++)
            {
                ObjectPool pool = new ObjectPool(poolSettings.Prefabs[i], poolSettings.PoolNames[i], poolSettings.InitSize, poolSettings.MaxSize, ContextView.transform);
                objectPools[i] = pool;
            }
        }
        #endregion
    }
}
