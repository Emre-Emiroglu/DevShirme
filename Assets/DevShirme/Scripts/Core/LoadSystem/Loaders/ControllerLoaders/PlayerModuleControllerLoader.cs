using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public class PlayerModuleControllerLoader : Loader
    {
        #region Fields
        private readonly Enums.PlayerModuleControllerType playerModuleControllerType;
        #endregion

        #region Core
        public PlayerModuleControllerLoader(Enums.PlayerModuleControllerType playerModuleControllerType, ScriptableObject[] scriptableObjects) : base(scriptableObjects)
        {
            this.playerModuleControllerType = playerModuleControllerType;
        }
        public override void Load()
        {
        }
        private void create(Enums.PlayerModuleControllerType playerModuleControllerType)
        {
        }
        #endregion
    }
}
