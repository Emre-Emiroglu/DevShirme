using DevShirme.Models;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Controllers
{
    public class ChangeGameStateCommand
    {
        #region Fields
        private readonly GameModel gameModel;
        private readonly SignalBus signalBus;
        #endregion

        #region Core
        public ChangeGameStateCommand(GameModel gameModel, SignalBus signalBus)
        {
            this.gameModel = gameModel;
            this.signalBus = signalBus;
        }
        #endregion

        #region Executes
        public void ChangeGameState(Enums.GameState gameState)
        {
            switch (gameState)
            {
                case Enums.GameState.Init:
                    setFPS();
                    setCursor();
                    break;
                case Enums.GameState.Start:
                    break;
                case Enums.GameState.Over:
                    Structs.OnClearPool onClearPool = new Structs.OnClearPool();
                    onClearPool.IsAll = true;
                    onClearPool.PoolName = "";
                    signalBus.Fire(onClearPool);
                    break;
                case Enums.GameState.Reload:
                    break;
            }

            message(gameState);
        }
        private void message(Enums.GameState gameState)
        {
            Debug.Log("Current Game State: " + gameState.ToString());
        }
        #endregion

        #region Setters
        private void setFPS()
        {
            Application.targetFrameRate = gameModel.TargetFPS;
        }
        private void setCursor()
        {
            Cursor.visible = gameModel.IsCursorActive;
            Cursor.lockState = gameModel.CursorLockMode;
        }
        #endregion
    }
}
