using DevShirme.DesignPatterns.Behaviorals;
using DevShirme.Interfaces;
using DevShirme.Modules.ADModule;
using DevShirme.Modules.CameraModule;
using DevShirme.Modules.EnemyModule;
using DevShirme.Modules.PlayerModule;
using DevShirme.Modules.UIModule;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Managers.GameManager
{
    public class GameManager : Manager, IObserver
    {
        #region Fields
        private readonly GameManagerSettings gmSettings;
        private readonly ADModule adModule;
        private readonly PlayerModule playerModule;
        private readonly CameraModule cameraModule;
        private readonly UIModule uiModule;
        private readonly EnemyModule enemyModule;
        private readonly Module[] modules;
        private GameEvent gameStartEvent;
        private GameEvent gameOverEvent;
        private GameEvent gameReloadEvent;
        #endregion

        #region Core
        public GameManager(GameManagerSettings gmSettings, ADModule adModule, PlayerModule playerModule, CameraModule cameraModule, UIModule uiModule, EnemyModule enemyModule) : base()
        {
            this.gmSettings = gmSettings;
            this.adModule = adModule;
            this.playerModule = playerModule;
            this.cameraModule = cameraModule;
            this.uiModule = uiModule;
            this.enemyModule = enemyModule;

            modules = new Module[5];
            modules[((int)Enums.ModuleType.ADModule)] = adModule;
            modules[((int)Enums.ModuleType.PlayerModule)] = playerModule;
            modules[((int)Enums.ModuleType.CameraModule)] = cameraModule;
            modules[((int)Enums.ModuleType.UIModule)] = uiModule;
            modules[((int)Enums.ModuleType.EnemyModule)] = enemyModule;

            setFPS();
            setCursor();

            initGameEvents();

            gameCycleConnections(true);
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

        #region GameEvents
        private void initGameEvents()
        {
            for (int i = 0; i < gmSettings.GameEvents.Length; i++)
                gmSettings.GameEvents[i].Initialize();

            gameStartEvent = gmSettings.GameEvents[((int)Enums.NotificationType.GameStart)];
            gameOverEvent = gmSettings.GameEvents[((int)Enums.NotificationType.GameOver)];
            gameReloadEvent = gmSettings.GameEvents[((int)Enums.NotificationType.GameReload)];
        }
        private void gameCycleConnections(bool isAttach)
        {
            setGameEventsConnections(isAttach, this);

            for (int i = 0; i < modules.Length; i++)
                setGameEventsConnections(isAttach, modules[i]);
        }
        private void setGameEventsConnections(bool isAttach, IObserver observer)
        {
            if (isAttach)
            {
                gameStartEvent.Attach(observer);
                gameOverEvent.Attach(observer);
                gameReloadEvent.Attach(observer);
            }
            else
            {
                gameStartEvent.DeAttach(observer);
                gameOverEvent.DeAttach(observer);
                gameReloadEvent.DeAttach(observer);
            }
        }
        #endregion

        #region Observer
        public void OnNotify(object value, Enums.NotificationType notificationType)
        {
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
