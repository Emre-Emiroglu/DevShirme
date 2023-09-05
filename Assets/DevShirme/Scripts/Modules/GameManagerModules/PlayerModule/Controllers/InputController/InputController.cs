using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public abstract class InputController: Controller
    {
        #region Fields
        protected readonly InputControllerSettings _icSettings;
        #endregion

        #region Core
        public InputController(ScriptableObject _settings) : base(_settings)
        {
            _icSettings = _settings as InputControllerSettings;
        }
        public abstract void ClearInputs();
        protected abstract void inputUpdate();
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
