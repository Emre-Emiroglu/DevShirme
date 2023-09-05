using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public class PCInputController : InputController
    {
        #region Fields
        private readonly Structs.PCInputData data;
        #endregion

        #region Getters
        #endregion

        #region Core
        public PCInputController(ScriptableObject _settings) : base(_settings)
        {
            this.data = _icSettings.PCInputData;
        }
        protected override void inputUpdate()
        {
        }
        public override void ClearInputs()
        {
        }
        #endregion

        #region Updates
        public override void ExternalUpdate()
        {
            base.ExternalUpdate();

            inputUpdate();
        }
        public override void ExternalFixedUpdate()
        {
            base.ExternalFixedUpdate();
        }
        #endregion

    }
}
