using DevShirme.Interfaces;
using DevShirme.Utils;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Controllers
{
    public class InitializeGameCommand : Command
    {
        #region Injects
        [Inject] public IADModel ADModel { get; set; }
        [Inject] public IPlayerModel PlayerModel { get; set; }
        [Inject] public ICameraModel CameraModel { get; set; }
        [Inject] public IWeaponModel WeaponModel { get; set; }
        [Inject] public IEnemyModel EnemyModel { get; set; }
        [Inject] public IInputModel InputModel { get; set; }
        [Inject] public IGameModel GameModel { get; set; }
        [Inject] public Enums.GameState GameState { get; set; }
        #endregion

        #region Executes
        public override void Execute()
        {
            switch (GameState)
            {
                case Enums.GameState.Init:
                    setFPS();
                    setCursor();
                    break;
            }
        }
        #endregion

        #region Setters
        private void setFPS()
        {
            Application.targetFrameRate = GameModel.GameSettings.TargetFPS;
        }
        private void setCursor()
        {
            Cursor.visible = GameModel.GameSettings.IsCursorActive;
            Cursor.lockState = GameModel.GameSettings.CursorLockMode;
        }
        #endregion

    }
}
