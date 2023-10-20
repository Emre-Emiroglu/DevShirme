using DevShirme.Utils;
using DevShirme.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Mediators
{
    public class UIButtonMediator : MonoBehaviour, IDisposable
    {
        #region Fields
        private UIButtonView view;
        private SignalBus signalBus;
        #endregion

        #region Core
        [Zenject.Inject]
        public void Construct(UIButtonView view, SignalBus signalBus)
        {
            this.view = view;
            this.signalBus = signalBus;

            this.view.Setup();
            this.view.OnButtonPressed += onButtonPressed;
        }
        public void Dispose()
        {
            view.OnButtonPressed -= onButtonPressed;
        }
        #endregion

        #region Receivers
        private void onButtonPressed(Enums.UIButtonType uiButtonType)
        {
            Structs.OnChangeGameState onChangeGameState = new Structs.OnChangeGameState();

            switch (uiButtonType)
            {
                case Enums.UIButtonType.GameStart:
                    onChangeGameState.NewGameState = Enums.GameState.Start;
                    break;
                case Enums.UIButtonType.GameReload:
                    onChangeGameState.NewGameState = Enums.GameState.Reload;
                    break;
            }

            signalBus.Fire(onChangeGameState);
        }
        #endregion
    }
}
