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
        #endregion

        #region Getters
        private ScriptableObject getSettings(int indexValue)
        {
            ScriptableObject settings = gmSettings.ModulesSettings[indexValue];
            return settings;
        }
        private int getIndexValue(int baseValue)
        {
            return baseValue == 1 ? 0 : baseValue / 2;
        }
        private bool checkIsCreated(int keyValue)
        {
            return modules.ContainsKey(keyValue);
        }
        #endregion

        #region Core
        public GameManager(ScriptableObject _settings) : base(_settings)
        {
            gmSettings = _settings as GameManagerSettings;

            setFPS();
            setCursor();

            createModules();
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

            bool hasAD = gmSettings.Modules.HasFlag(Enums.ModuleType.ADModule);
            bool hasPM = gmSettings.Modules.HasFlag(Enums.ModuleType.PlayerModule);
            bool hasCM = gmSettings.Modules.HasFlag(Enums.ModuleType.CameraModule);
            bool hasUM = gmSettings.Modules.HasFlag(Enums.ModuleType.UIModule);

            if (hasAD)
            {
                int indexValue = getIndexValue(((int)Enums.ModuleType.ADModule));
                if (!checkIsCreated(indexValue))
                {
                    ScriptableObject settings = getSettings(indexValue);
                    IModule module = new ADModule(settings);
                    modules.Add(indexValue, module);
                }
            }
            if (hasPM)
            {
                int indexValue = getIndexValue(((int)Enums.ModuleType.PlayerModule));
                if (!checkIsCreated(indexValue))
                {
                    ScriptableObject settings = getSettings(indexValue);
                    IModule module = new PlayerModule(settings);
                    modules.Add(indexValue, module);
                }
            }
            if (hasCM)
            {
                int indexValue = getIndexValue(((int)Enums.ModuleType.CameraModule));
                if (!checkIsCreated(indexValue))
                {
                    ScriptableObject settings = getSettings(indexValue);
                    IModule module = new CameraModule(settings);
                    modules.Add(indexValue, module);
                }
            }
            if (hasUM)
            {
                int indexValue = getIndexValue(((int)Enums.ModuleType.UIModule));
                if (!checkIsCreated(indexValue))
                {
                    //ScriptableObject settings = getSettings(indexValue);
                    IModule module = new UIModule(null);
                    modules.Add(indexValue, module);
                }
            }
        }
        #endregion

        #region Updates
        public override void ExternalUpdate()
        {
        }
        public override void ExternalFixedUpdate()
        {
        }
        #endregion
    }
}
