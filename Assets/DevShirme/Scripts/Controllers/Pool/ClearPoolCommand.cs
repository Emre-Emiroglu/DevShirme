using DevShirme.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Controllers
{
    public class ClearPoolCommand
    {
        #region Fields
        private readonly PoolModel poolModel;
        private readonly bool isAll;
        private readonly string poolName;
        #endregion

        #region Core
        public ClearPoolCommand(PoolModel poolModel, bool isAll, string poolName)
        {
            this.poolModel = poolModel;
            this.isAll = isAll;
            this.poolName = poolName;
        }
        #endregion

        #region ClearPool
        public void ClearPool()
        {
            if (isAll)
                ClearAllPools();
            else
                Clear(poolName);
        }
        #endregion

        #region Clears
        private void Clear(string poolName)
        {
            for (int i = 0; i < poolModel.ObjectPools.Length; i++)
            {
                if (poolModel.ObjectPools[i].PoolName == poolName)
                    poolModel.ObjectPools[i].Reload();
            }
        }
        private void ClearAllPools()
        {
            for (int i = 0; i < poolModel.ObjectPools.Length; i++)
                poolModel.ObjectPools[i].Reload();
        }
        #endregion
    }
}
