using DevShirme.Interfaces;
using DevShirme.Utils;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Controllers
{
    public class SpawnCommand : Command
    {
        #region Injects
        [Inject] public IPoolModel PoolModel { get; set; }
        [Inject] public Structs.SpawnData SpawnData { get; set; }
        #endregion

        #region Executes
        public override void Execute()
        {
            spawn();
        }
        #endregion

        #region Spawn
        private void spawn()
        {
            for (int i = 0; i < PoolModel.ObjectPools.Length; i++)
            {
                if (PoolModel.ObjectPools[i].PoolName == SpawnData.PoolName)
                    PoolModel.ObjectPools[i].GetObj(SpawnData.Pos, SpawnData.Rot, SpawnData.Scale, SpawnData.Parent, SpawnData.UseRotation, SpawnData.UseScale, SpawnData.SetParent);
            }

            Debug.LogError(SpawnData.PoolName + " Cant Found");
        }
        #endregion
    }
}
