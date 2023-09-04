using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class Module: Loadable
    {
        #region Core
        public Module(ScriptableObject _settings) : base(_settings)
        {
        }
        #endregion

        #region Updates
        public override void ExternalUpdate()
        {
            base.ExternalUpdate();
        }
        public override void ExternalFixedUpdate()
        {
            base.ExternalFixedUpdate();
        }
        #endregion

        #region Subscriptions
        public abstract void SetSubscriptions(bool isSub);
        #endregion
    }
}
