using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public class CameraModuleControllerLoader : Loader
    {
        #region Fields
        private readonly Enums.CameraModuleControllerType cameraModuleControllerType;
        #endregion

        #region Core
        public CameraModuleControllerLoader(Enums.CameraModuleControllerType cameraModuleControllerType, ScriptableObject[] scriptableObjects) : base(scriptableObjects)
        {
            this.cameraModuleControllerType = cameraModuleControllerType;
        }
        public override void Load()
        {
        }
        private void create(Enums.CameraModuleControllerType cameraModuleControllerType)
        {
        }
        #endregion
    }
}
