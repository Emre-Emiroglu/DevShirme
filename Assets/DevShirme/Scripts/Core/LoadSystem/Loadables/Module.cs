using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class Module: ILoadable
    {
        #region Fields
        protected readonly ScriptableObject _settings;
        #endregion

        #region Core
        public Module(ScriptableObject _settings)
        {
            this._settings = _settings;
        }
        #endregion

        #region Updates
        public abstract void ExternalUpdate();
        public abstract void ExternalFixedUpdate();
        #endregion

        #region Subscriptions
        public abstract void SetSubscriptions(bool isSub);
        #endregion
    }
}
