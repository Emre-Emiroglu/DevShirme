using DevShirme.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class Manager: Loadable
    {
        #region Core
        public Manager(ScriptableObject _settings) : base(_settings)
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
