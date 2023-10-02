using DevShirme.Signals;
using DevShirme.Utils;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Controllers
{
    public class TransationToNewPanelCommand : Command
    {
        #region Injects
        [Inject] public UISignal UISignal { get; set; }
        [Inject] public Enums.GameState GameState { get; set; }
        #endregion

        #region Executes
        public override void Execute()
        {
            switch (GameState)
            {
                case Enums.GameState.Init:
                    UISignal.OnTransationToNewPanel?.Dispatch(Enums.UIPanelType.MainMenuPanel);
                    break;
                case Enums.GameState.Start:
                    UISignal.OnTransationToNewPanel?.Dispatch(Enums.UIPanelType.InGamePanel);
                    break;
                case Enums.GameState.Over:
                    UISignal.OnTransationToNewPanel?.Dispatch(Enums.UIPanelType.EndGamePanel);
                    break;
                case Enums.GameState.Reload:
                    UISignal.OnTransationToNewPanel?.Dispatch(Enums.UIPanelType.MainMenuPanel);
                    break;
            }
        }
        #endregion
    }
}
