using DevShirme.Interfaces;
using DevShirme.Utils;
using strange.extensions.command.impl;
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
