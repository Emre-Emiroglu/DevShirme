using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public class PoolManagerModuleLoader : Loader
    {
        #region Fields
        private readonly Enums.PoolManagerModuleType poolManagerModuleType;
        #endregion

        #region Core
        public PoolManagerModuleLoader(Enums.PoolManagerModuleType poolManagerModuleType, ScriptableObject[] scriptableObjects) : base(scriptableObjects)
        {
            this.poolManagerModuleType = poolManagerModuleType;
        }
        public override void Load()
        {
        }
        private void create(Enums.PoolManagerModuleType poolManagerModuleType)
        {
        }
        #endregion
    }
}
