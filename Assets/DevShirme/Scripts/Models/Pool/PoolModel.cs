using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class PoolModel : IPoolModel
    {
        #region Fields
        private PoolSettings poolSettings;
        private ObjectPool[] objectPools;
        #endregion

        #region Getters
        public PoolSettings PoolSettings => poolSettings;
        public ObjectPool[] ObjectPools => objectPools;
        #endregion

        #region Core
        public void Initialize()
        {
            poolSettings = Resources.Load<PoolSettings>("Settings/PoolSettings");

            objectPools = new ObjectPool[poolSettings.Prefabs.Length];

            for (int i = 0; i < poolSettings.Prefabs.Length; i++)
            {
                ObjectPool pool = new ObjectPool(poolSettings.Prefabs[i], poolSettings.PoolNames[i], poolSettings.InitSize, poolSettings.MaxSize, PoolSettings.PoolsParent);
                objectPools[i] = pool;
            }
        }
        #endregion
    }
}
