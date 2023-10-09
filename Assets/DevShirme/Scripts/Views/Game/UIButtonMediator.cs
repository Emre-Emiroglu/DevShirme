using DevShirme.Signals;
using DevShirme.Utils;
using DevShirme.Views;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Mediators
{
    public class UIButtonMediator : Mediator
    {
        #region Injects
        [Inject] public UIButtonView UIButtonView { get; set; }
        [Inject] public GameSignal GameSignal { get; set; }
        #endregion

        #region Core
        public override void PreRegister()
        {
        }
        public override void OnRegister()
        {
            UIButtonView.Setup();
            UIButtonView.OnButtonPressed += onButtonPressed;
        }
        public override void OnRemove()
        {
            UIButtonView.OnButtonPressed -= onButtonPressed;
        }
        #endregion

        #region Receivers
        private void onButtonPressed(Enums.UIButtonType uiButtonType)
        {
            switch (uiButtonType)
            {
                case Enums.UIButtonType.GameStart:
                    GameSignal.OnChangeGameState?.Dispatch(Enums.GameState.Start);
                    break;
                case Enums.UIButtonType.GameReload:
                    GameSignal.OnChangeGameState?.Dispatch(Enums.GameState.Reload);
                    break;
            }
        }
        #endregion
    }
}
