using DevShirme.Interfaces;
using DevShirme.Signals;
using DevShirme.Utils;
using DevShirme.Views;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Mediators
{
    public class PlayerAgentMediator : Mediator
    {
        #region Injects
        [Inject] public IPlayerModel PlayerModel { get; set; }
        [Inject] public IInputModel InputModel { get; set; }
        [Inject] public PlayerAgentView View { get; set; }
        [Inject] public GameSignal GameSignal { get; set; }
        #endregion

        #region Fields
        private bool isGameStart = false;
        #endregion

        #region Core
        public override void PreRegister()
        {
        }
        public override void OnRegister()
        {
            View.Initialize(PlayerModel, InputModel);

            GameSignal.OnChangeGameState.AddListener(onChangeGameState);
            GameSignal.OnGameUpdate.AddListener(onGameUpdate);
        }
        public override void OnRemove()
        {
            GameSignal.OnChangeGameState.RemoveListener(onChangeGameState);
            GameSignal.OnGameUpdate.RemoveListener(onGameUpdate);
        }
        #endregion

        #region Receivers
        private void onChangeGameState(Enums.GameState gameState) { }
        private void onGameUpdate() { }
        #endregion

    }
}
