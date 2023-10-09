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
        public IPoolObject GetPoolObject(string poolName, Vector3 pos, Quaternion rot, Vector3 scale, Transform parent, bool useRotation = false, bool useScale = false, bool setParent = false)
        {
            for (int i = 0; i < objectPools.Length; i++)
            {
                if (objectPools[i].PoolName == poolName)
                    return objectPools[i].GetObj(pos, rot, scale, parent, useRotation, useScale, setParent);
            }

            Debug.LogError(poolName + " Cant Found");
            return null;
        }
        #endregion
    }
}
