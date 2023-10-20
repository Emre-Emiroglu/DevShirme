using DevShirme.Utils;
using DevShirme.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Mediators
{
    public class UIPanelMediator : MonoBehaviour, IDisposable
    {
        #region Fields
        private UIPanelView uiPanelView;
        private SignalBus signalBus;
        #endregion

        #region Core
        [Zenject.Inject]
        public void Construct(UIPanelView uiPanelView, SignalBus signalBus)
        {
            this.uiPanelView = uiPanelView;
            this.signalBus = signalBus;

            this.uiPanelView.Initialize();

            signalBus.Subscribe<Structs.OnChangeGameState>(x => onChangeGameState(x.NewGameState));
        }
        public void Dispose()
        {
            signalBus.Unsubscribe<Structs.OnChangeGameState>(x => onChangeGameState(x.NewGameState));
        }
        #endregion

        #region Receivers
        private void onChangeGameState(Enums.GameState gameState)
        {
            Enums.UIPanelType panelType = Enums.UIPanelType.MainMenuPanel;

            switch (gameState)
            {
                case Enums.GameState.Init:
                    panelType = Enums.UIPanelType.MainMenuPanel;
                    break;
                case Enums.GameState.Start:
                    panelType = Enums.UIPanelType.InGamePanel;
                    break;
                case Enums.GameState.Over:
                    panelType = Enums.UIPanelType.EndGamePanel;
                    break;
                case Enums.GameState.Reload:
                    panelType = Enums.UIPanelType.MainMenuPanel;
                    break;
            }

            bool isShow = uiPanelView.PanelType == panelType;
            if (isShow)
                uiPanelView.Show();
            else
                uiPanelView.Hide();
        }
        #endregion
    }
}
