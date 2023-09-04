using DevShirme.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class Manager: Loadable
    {
        #region Fields
        protected ILoader _loader;
        #endregion

        #region Core
        public Manager(ScriptableObject _settings) : base(_settings)
        {
        }
        #endregion

        #region Updates
        public override void ExternalUpdate()
        {
            base.ExternalUpdate();

            for (int i = 0; i < _loader.Loadeds.Count; i++)
                _loader.Loadeds[i].ExternalUpdate();
        }
        public override void ExternalFixedUpdate()
        {
            base.ExternalFixedUpdate();

            for (int i = 0; i < _loader.Loadeds.Count; i++)
                _loader.Loadeds[i].ExternalFixedUpdate();
        }
        #endregion
    }
}
