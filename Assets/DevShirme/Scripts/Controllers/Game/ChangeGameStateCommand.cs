using DevShirme.Interfaces;
using DevShirme.Signals;
using DevShirme.Utils;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Controllers
{
    public class ChangeGameStateCommand : Command
    {
        #region Injects
        [Inject] public IGameModel GameModel { get; set; }
        [Inject] public Enums.GameState GameState { get; set; }
        [Inject] public PoolSignal PoolSignal { get; set; }
        [Inject] public GameSignal GameSignal { get; set; }
        #endregion

        #region Executes
        public override void Execute()
        {
            GameModel.GameState = GameState;

            switch (GameState)
            {
                case Enums.GameState.Init:
                    break;
                case Enums.GameState.Start:
                    break;
                case Enums.GameState.Over:
                    PoolSignal.OnClearPool?.Dispatch(true, "");
                    break;
                case Enums.GameState.Reload:
                    break;
            }

            message();
        }
        private void message()
        {
            Debug.Log("Current Game State: " + GameState.ToString());
        }
        #endregion
    }
}
