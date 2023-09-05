using DevShirme.Interfaces;
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
        private readonly ILoader loader;
        private readonly List<ILoadable> controllers;
        #endregion

        #region Core
        public PlayerModule(ScriptableObject _settings) : base(_settings)
        {
            playerSettings = _settings as PlayerSettings;

            loader = new Loader();
            controllers = loader.LoadPlayerModuleControllers(playerSettings.Controllers, playerSettings.ControllersSettings);
        }
        #endregion

        #region Updates
        public override void ExternalUpdate()
        {
            for (int i = 0; i < controllers.Count; i++)
                controllers[i].ExternalUpdate();
        }
        public override void ExternalFixedUpdate()
        {
            for (int i = 0; i < controllers.Count; i++)
                controllers[i].ExternalFixedUpdate();
        }
        #endregion

        #region Subscriptions
        public override void SetSubscriptions(bool isSub)
        {
        }
        #endregion
    }
}
