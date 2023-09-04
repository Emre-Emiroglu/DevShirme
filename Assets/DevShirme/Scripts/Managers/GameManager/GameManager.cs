using DevShirme.Utils;
using DevShirme.Modules.ADModule;
using DevShirme.Modules.CameraModule;
using DevShirme.Modules.PlayerModule;
using DevShirme.Modules.UIModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Interfaces;
using System.Reflection;

namespace DevShirme.Managers.GameManager
{
    public class GameManager : Manager
    {
        #region Fields
        private readonly GameManagerSettings gmSettings;
        private ILoader loader;
        #endregion

        #region Core
        public GameManager(ScriptableObject _settings) : base(_settings)
        {
            gmSettings = _settings as GameManagerSettings;

            setFPS();
            setCursor();

            loads();

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

        #region Loads
        private void loads()
        {
            loader = new Loader();

            bool hasAD = gmSettings.Modules.HasFlag(Enums.GameManagerModuleType.ADModule);
            bool hasPM = gmSettings.Modules.HasFlag(Enums.GameManagerModuleType.PlayerModule);
            bool hasCM = gmSettings.Modules.HasFlag(Enums.GameManagerModuleType.CameraModule);
            bool hasUM = gmSettings.Modules.HasFlag(Enums.GameManagerModuleType.UIModule);

            if (hasAD)
                singleLoad(Enums.GameManagerModuleType.ADModule);
            if (hasPM)
                singleLoad(Enums.GameManagerModuleType.PlayerModule);
            if (hasCM)
                singleLoad(Enums.GameManagerModuleType.CameraModule);
            if (hasUM)
                singleLoad(Enums.GameManagerModuleType.UIModule);
        }
        private void singleLoad(Enums.GameManagerModuleType moduleType)
        {
            int indexValue = Utilities.FlagsValueToIndex(((int)moduleType));
            ScriptableObject settings = gmSettings.ModulesSettings[indexValue];
            if (!loader.IsContain(indexValue))
            {
                Module module = null;
                switch (moduleType)
                {
                    case Enums.GameManagerModuleType.ADModule:
                        module = new ADModule(settings);
                        break;
                    case Enums.GameManagerModuleType.PlayerModule:
                        module = new PlayerModule(settings);
                        break;
                    case Enums.GameManagerModuleType.CameraModule:
                        module = new CameraModule(settings);
                        break;
                    case Enums.GameManagerModuleType.UIModule:
                        module = new UIModule(settings);
                        break;
                }
                loader.AddLoadable(indexValue, module);
            }
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
            base.ExternalUpdate();

            for (int i = 0; i < loader.Loadeds.Count; i++)
                loader.Loadeds[i].ExternalUpdate();
        }
        public override void ExternalFixedUpdate()
        {
            base.ExternalFixedUpdate();

            for (int i = 0; i < loader.Loadeds.Count; i++)
                loader.Loadeds[i].ExternalFixedUpdate();
        }
        #endregion
    }
}
