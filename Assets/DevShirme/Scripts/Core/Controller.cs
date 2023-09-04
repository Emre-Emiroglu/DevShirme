using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class Controller: Loadable
    {
        #region Core
        public Controller(ScriptableObject _settings) : base(_settings)
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
    }
}
