using DevShirme.Interfaces;
using DevShirme.Modules.ADModule;
using DevShirme.Modules.CameraModule;
using DevShirme.Modules.PlayerModule;
using DevShirme.Modules.UIModule;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Managers.GameManager
{
    public class GameManager : Manager
    {
        #region Fields
        private readonly GameManagerSettings gmSettings;
        private readonly ILoadable adModule;
        private readonly ILoadable playerModule;
        private readonly ILoadable cameraModule;
        private readonly ILoadable uiModule;
        private ILoadable[] modules;
        #endregion

        #region Core
        public GameManager(ScriptableObject _settings) : base(_settings)
        {
            gmSettings = _settings as GameManagerSettings;

            adModule = new ADModule(gmSettings.ModulesSettings[((int)Enums.ModuleType.ADModule)]);
            playerModule = new PlayerModule(gmSettings.ModulesSettings[((int)Enums.ModuleType.PlayerModule)]);
            cameraModule = new CameraModule(gmSettings.ModulesSettings[((int)Enums.ModuleType.CameraModule)]);
            uiModule = new UIModule(gmSettings.ModulesSettings[((int)Enums.ModuleType.UIModule)]);

            modules = new ILoadable[]
            {
                modules[0] = adModule,
                modules[1] = playerModule,
                modules[2] = cameraModule,
                modules[3] = uiModule
            };

            setFPS();
            setCursor();

            initGameEvents();
        }
        #endregion

        #region Setters
        private void setFPS()
        {
            Application.targetFrameRate = gmSettings.TargetFPS;
        }
        private void setCursor()
        {
            Cursor.visible = gmSettings.IsCursorActive;
            Cursor.lockState = gmSettings.CursorLockMode;
        }
        #endregion

        #region Inits
        private void initGameEvents()
        {
            for (int i = 0; i < gmSettings.GameEvents.Length; i++)
                gmSettings.GameEvents[i].Initialize();
        }
        #endregion

        #region Updates
        public override void ExternalUpdate()
        {
            for (int i = 0; i < modules.Length; i++)
                modules[i].ExternalUpdate();
        }
        public override void ExternalFixedUpdate()
        {
            for (int i = 0; i < modules.Length; i++)
                modules[i].ExternalFixedUpdate();
        }
        #endregion
    }
}
