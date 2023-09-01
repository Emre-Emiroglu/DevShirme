using DevShirme.Interfaces;
using DevShirme.Utils;
using DevShirme.Modules.ADModule;
using DevShirme.Modules.CameraModule;
using DevShirme.Modules.PlayerModule;
using DevShirme.Modules.UIModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Managers.GameManager
{
    public class GameManager : Manager
    {
        #region Fields
        private readonly GameManagerSettings gmSettings;
        private Dictionary<int, IModule> modules;
        private List<IModule> loadedModules;
        #endregion

        #region Core
        public GameManager(ScriptableObject _settings) : base(_settings)
        {
            gmSettings = _settings as GameManagerSettings;

            setFPS();
            setCursor();

            createModules();

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

        #region Creates
        private void createModules()
        {
            modules = new Dictionary<int, IModule>();
            loadedModules = new List<IModule>();

            bool hasAD = gmSettings.Modules.HasFlag(Enums.ModuleType.ADModule);
            bool hasPM = gmSettings.Modules.HasFlag(Enums.ModuleType.PlayerModule);
            bool hasCM = gmSettings.Modules.HasFlag(Enums.ModuleType.CameraModule);
            bool hasUM = gmSettings.Modules.HasFlag(Enums.ModuleType.UIModule);

            if (hasAD)
                createModule(Enums.ModuleType.ADModule);
            if (hasPM)
                createModule(Enums.ModuleType.PlayerModule);
            if (hasCM)
                createModule(Enums.ModuleType.CameraModule);
            if (hasUM)
                createModule(Enums.ModuleType.UIModule);
        }
        private void createModule(Enums.ModuleType moduleType)
        {
            int indexValue = Utilities.FlagsValueToIndex(((int)moduleType));
            bool contain = modules.ContainsKey(indexValue);
            IModule module = null;
            if (!contain)
            {
                ScriptableObject settings = gmSettings.ModulesSettings[indexValue];
                switch (moduleType)
                {
                    case Enums.ModuleType.ADModule:
                        module = new ADModule(settings);
                        break;
                    case Enums.ModuleType.PlayerModule:
                        module = new PlayerModule(settings);
                        break;
                    case Enums.ModuleType.CameraModule:
                        module = new CameraModule(settings);
                        break;
                    case Enums.ModuleType.UIModule:
                        module = new UIModule(settings);
                        break;
                }
                modules.Add(indexValue, module);
                loadedModules.Add(module);
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
            for (int i = 0; i < loadedModules.Count; i++)
                loadedModules[i].ExternalUpdate();
        }
        public override void ExternalFixedUpdate()
        {
            for (int i = 0; i < loadedModules.Count; i++)
                loadedModules[i].ExternalFixedUpdate();
        }
        #endregion
    }
}
