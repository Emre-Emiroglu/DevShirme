using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public class ADModuleControllerLoader : Loader
    {
        #region Fields
        private readonly Enums.ADModuleControllerType adModuleControllerType;
        #endregion

        #region Core
        public ADModuleControllerLoader(Enums.ADModuleControllerType adModuleControllerType, ScriptableObject[] scriptableObjects) : base(scriptableObjects)
        {
            this.adModuleControllerType = adModuleControllerType;
        }
        public override void Load()
        {
        }
        private void create(Enums.ADModuleControllerType adModuleControllerType)
        {
        }
        #endregion
    }
}
