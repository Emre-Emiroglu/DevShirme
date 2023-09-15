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
        private readonly ADModule adModule;
        private readonly PlayerModule playerModule;
        private readonly CameraModule cameraModule;
        private readonly UIModule uiModule;
        private readonly Module[] modules;
        #endregion

        #region Core
        public GameManager(GameManagerSettings gmSettings, ADModule adModule, PlayerModule playerModule, CameraModule cameraModule, UIModule uiModule) : base()
        {
            this.gmSettings = gmSettings;
            this.adModule = adModule;
            this.playerModule = playerModule;
            this.cameraModule = cameraModule;
            this.uiModule = uiModule;

            modules = new Module[4];
            modules[((int)Enums.ModuleType.ADModule)] = adModule;
            modules[((int)Enums.ModuleType.PlayerModule)] = playerModule;
            modules[((int)Enums.ModuleType.CameraModule)] = cameraModule;
            modules[((int)Enums.ModuleType.UIModule)] = uiModule;

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
        public override void Tick()
        {
            for (int i = 0; i < modules.Length; i++)
                modules[i].Tick();
        }
        public override void FixedTick()
        {
            for (int i = 0; i < modules.Length; i++)
                modules[i].FixedTick();
        }
        public override void LateTick()
        {
            for (int i = 0; i < modules.Length; i++)
                modules[i].LateTick();
        }
        #endregion
    }
}
