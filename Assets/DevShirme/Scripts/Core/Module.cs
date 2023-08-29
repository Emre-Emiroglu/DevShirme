using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class Module: IModule
    {
        #region Core
        public Module(ScriptableObject _settings)
        {
            SetSubscriptions(true);
        }
        public abstract void SetSubscriptions(bool isSub);
        #endregion

        #region Updates
        public abstract void ExternalUpdate();
        public abstract void ExternalFixedUpdate();
        #endregion
    }
}
