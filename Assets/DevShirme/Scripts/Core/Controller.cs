using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class Controller
    {
        #region Fields
        protected readonly ScriptableObject _settings;
        #endregion

        #region Core
        public Controller(ScriptableObject _settings)
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
