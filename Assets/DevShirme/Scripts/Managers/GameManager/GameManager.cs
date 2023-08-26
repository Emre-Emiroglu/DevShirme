using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public class GameManager : Manager
    {
        #region Fields
        private readonly GameManagerSettings gmSettings;
        private IModule[] modules;
        #endregion

        #region Core
        public GameManager(ScriptableObject _settings) : base(_settings)
        {
            gmSettings = _settings as GameManagerSettings;

            setFPS();
            setCursor();

            findModules();
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

        #region Finds
        private void findModules()
        {
            modules = Object.FindObjectsOfType<Module>();

            for (int i = 0; i < modules.Length; i++)
            {
                modules[i].Initialize();
            }
        }
        #endregion
    }
}
