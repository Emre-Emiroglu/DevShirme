using DevShirme.Interfaces;
using DevShirme.Utils;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Controllers
{
    public class GameStateChangeCommand : Command
    {
        #region Injects
        [Inject] public Enums.GameState GameState { get; set; }
        [Inject] public IGameModel GameModel { get; set; }
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
                case Enums.GameState.Start:
                    break;
                case Enums.GameState.Over:
                    break;
                case Enums.GameState.Reload:
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
