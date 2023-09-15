using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Managers.PoolManager
{
    public class PoolManager : Manager
    {
        #region Fields
        private readonly PoolManagerSettings pmSettings;
        private readonly Transform poolsParent;
        private ObjectPool[] pools;
        #endregion

        #region Getters
        public IPoolObject GetObj(string poolName, Vector3 pos, Quaternion rot, Vector3 scale, Transform parent, bool useRotation = false, bool useScale = false, bool setParent = false)
        {
            for (int i = 0; i < pools.Length; i++)
            {
                if (pools[i].PoolName == poolName)
                    return pools[i].GetObj(pos, rot, scale, parent, useRotation, useScale, setParent);
            }

            Debug.LogError(poolName + " Cant Found");
            return null;
        }
        #endregion

        #region Core
        public PoolManager(PoolManagerSettings pmSettings, Transform poolsParent) : base()
        {
            this.pmSettings = pmSettings;
            this.poolsParent = poolsParent;

            pools = new ObjectPool[pmSettings.Prefabs.Length];

            for (int i = 0; i < pmSettings.Prefabs.Length; i++)
            {
                ObjectPool pool = new ObjectPool(pmSettings.Prefabs[i], pmSettings.PoolNames[i], pmSettings.InitSize, pmSettings.MaxSize, this.poolsParent);
                pools[i] = pool;
            }
        }
        #endregion

        #region Clears
        public void ClearPool(string objName)
        {
            for (int i = 0; i < pools.Length; i++)
            {
                if (pools[i].PoolName == objName)
                    pools[i].Reload();
            }
        }
        public void ClearAllPools()
        {
            for (int i = 0; i < pools.Length; i++)
                pools[i].Reload();
        }
        #endregion

        #region Updates
        public override void Tick()
        {
        }
        public override void FixedTick()
        {
        }
        public override void LateTick()
        {
        }
        #endregion
    }
}
