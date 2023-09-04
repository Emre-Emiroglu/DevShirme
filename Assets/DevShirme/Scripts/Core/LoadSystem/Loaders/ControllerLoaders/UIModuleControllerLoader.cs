using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public class UIModuleControllerLoader : Loader
    {
        #region Fields
        private readonly Enums.UIModuleControllerType uiModuleControllerType;
        #endregion

        #region Core
        public UIModuleControllerLoader(Enums.UIModuleControllerType uiModuleControllerType, ScriptableObject[] scriptableObjects) : base(scriptableObjects)
        {
            this.uiModuleControllerType = uiModuleControllerType;
        }
        public override void Load()
        {
        }
        private void create(Enums.UIModuleControllerType uiModuleControllerType)
        {
        }
        #endregion
    }
}
