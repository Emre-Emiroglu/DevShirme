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
        [Inject] public IWeaponModel WeaponModel { get; set; }
        [Inject] public PlayerAgentView PlayerAgentView { get; set; }
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
            PlayerAgentView.Initialize(PlayerModel, InputModel, WeaponModel);

            PlayerAgentView.OnDead += onPlayerDead;
            PlayerAgentView.OnWeaponCanShoot += onWeaponCanShoot;

            GameSignal.OnChangeGameState.AddListener(onChangeGameState);
        }
        public override void OnRemove()
        {
            PlayerAgentView.OnDead -= onPlayerDead;
            PlayerAgentView.OnWeaponCanShoot -= onWeaponCanShoot;

            GameSignal.OnChangeGameState.RemoveListener(onChangeGameState);
        }
        #endregion

        #region Receivers
        private void onPlayerDead()
        {
            GameSignal.OnChangeGameState?.Dispatch(Enums.GameState.Over);
        }
        private void onWeaponCanShoot()
        {
            GameSignal.OnWeaponCanShoot?.Dispatch();
        }
        private void onChangeGameState(Enums.GameState gameState)
        {
            isGameStart = gameState == Enums.GameState.Start;

            if (!isGameStart)
                PlayerAgentView.Reload();
        }
        #endregion

        #region Updates
        private void Update()
        {
            if (!isGameStart)
                return;

            PlayerAgentView.OnGameUpdate();
        }
        private void FixedUpdate()
        {
            if (!isGameStart)
                return;

            PlayerAgentView.OnGameFixedUpdate();
        }
        #endregion

    }
}
