using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class Loadable: ILoadable
    {
        #region Fields
        protected readonly ScriptableObject _settings;
        #endregion

        #region Core
        public Loadable(ScriptableObject _settings)
        {
            this._settings = _settings;
        }
        #endregion

        #region Updates
        public virtual void ExternalUpdate() { }
        public virtual void ExternalFixedUpdate() { }
        #endregion
    }
}
