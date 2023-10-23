using DevShirme.Models;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Controllers
{
    public class ClearPoolCommand
    {
        #region Fields
        private readonly PoolModel poolModel;
        #endregion

        #region Core
        public ClearPoolCommand(PoolModel poolModel)
        {
            this.poolModel = poolModel;
        }
        #endregion

        #region ClearPool
        public void ClearPool(Structs.OnClearPool onClearPool)
        {
            if (onClearPool.IsAll)
                ClearAllPools();
            else
                Clear(onClearPool.PoolName);
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
