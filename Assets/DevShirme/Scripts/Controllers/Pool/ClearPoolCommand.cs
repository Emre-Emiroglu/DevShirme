using DevShirme.Interfaces;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Controllers
{
    public class ClearPoolCommand : Command
    {
        #region Injects
        [Inject] public IPoolModel PoolModel { get; set; }
        [Inject] public bool IsAll { get; set; }
        [Inject] public string PoolName { get; set; }
        #endregion

        #region Executes
        public override void Execute()
        {
            if (IsAll)
                clearAllPools();
            else
                clear(PoolName);
        }
        #endregion

        #region Clears
        private void clear(string poolName)
        {
            for (int i = 0; i < PoolModel.ObjectPools.Length; i++)
            {
                if (PoolModel.ObjectPools[i].PoolName == poolName)
                    PoolModel.ObjectPools[i].Reload();
            }
        }
        public void clearAllPools()
        {
            for (int i = 0; i < PoolModel.ObjectPools.Length; i++)
                PoolModel.ObjectPools[i].Reload();
        }
        #endregion
    }
}
