using System.Collections;
using System.Collections.Generic;
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

            _loader = new PlayerModuleControllerLoader(playerSettings.Controllers, playerSettings.ControllersSettings);
            _loader.Load();
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
