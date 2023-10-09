using DevShirme.Signals;
using DevShirme.Utils;
using DevShirme.Views;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Mediators
{
    public class UIPanelMediator : Mediator
    {
        #region Injects
        [Inject] public UIPanelView UIPanelView { get; set; }
        [Inject] public GameSignal GameSignal { get; set; }
        #endregion

        #region Core
        public override void PreRegister()
        {
        }
        public override void OnRegister()
        {
            UIPanelView.Initialize();

            GameSignal.OnChangeGameState.AddListener(onChangeGameState);
        }
        public override void OnRemove()
        {
            GameSignal.OnChangeGameState.RemoveListener(onChangeGameState);
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

            bool isShow = UIPanelView.PanelType == panelType;
            if (isShow)
                UIPanelView.Show();
            else
                UIPanelView.Hide();
        }
        #endregion
    }
}
