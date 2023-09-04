using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public class DataManagerModuleLoader : Loader
    {
        #region Fields
        private readonly Enums.DataManagerModuleType dataManagerModuleType;
        #endregion

        #region Core
        public DataManagerModuleLoader(Enums.DataManagerModuleType dataManagerModuleType, ScriptableObject[] scriptableObjects) : base(scriptableObjects)
        {
            this.dataManagerModuleType = dataManagerModuleType;
        }
        public override void Load()
        {
        }
        private void create(Enums.DataManagerModuleType dataManagerModuleType)
        {
        }
        #endregion
    }
}
