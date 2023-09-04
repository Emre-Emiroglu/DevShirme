using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class Module: Loadable
    {
        #region Fields
        protected ILoader _loader;
        #endregion

        #region Core
        public Module(ScriptableObject _settings) : base(_settings)
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

        #region Subscriptions
        public abstract void SetSubscriptions(bool isSub);
        #endregion
    }
}
