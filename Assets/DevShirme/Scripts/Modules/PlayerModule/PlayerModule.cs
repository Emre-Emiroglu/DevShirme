using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public class PlayerModule: Module
    {
        #region Fields
        private readonly PlayerSettings playerSettings;
        #endregion

        #region Core
        public PlayerModule(ScriptableObject _settings) : base(_settings)
        {
            playerSettings = _settings as PlayerSettings;
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
        public override void SetSubscriptions(bool isSub)
        {
        }
        #endregion
    }
}
