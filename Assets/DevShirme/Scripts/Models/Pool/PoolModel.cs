using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class PoolModel : IPoolModel
    {
        private readonly PoolSettings poolSettings;
        private ObjectPool[] objectPools;

        public PoolSettings PoolSettings => poolSettings;
        public ObjectPool[] ObjectPools => objectPools;

        public PoolModel()
        {
            poolSettings = Resources.Load<PoolSettings>("Settings/PoolSettings");

            objectPools = new ObjectPool[poolSettings.Prefabs.Length];

            for (int i = 0; i < poolSettings.Prefabs.Length; i++)
            {
                ObjectPool pool = new ObjectPool(poolSettings.Prefabs[i], poolSettings.PoolNames[i], poolSettings.InitSize, poolSettings.MaxSize, PoolSettings.PoolsParent);
                objectPools[i] = pool;
            }
        }
    }
}
