using DevShirme.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class Manager : ILoadable
    {
        #region Fields
        protected readonly ScriptableObject _settings;
        #endregion

        #region Core
        public Manager(ScriptableObject _settings)
        {
            this._settings = _settings;
        }
        #endregion

        #region Updates
        public abstract void ExternalUpdate();
        public abstract void ExternalFixedUpdate();
        #endregion
    }
}
