using DevShirme.Models;
using DevShirme.Utils;
using DevShirme.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Mediators
{
    public class PlayerAgentMediator : MonoBehaviour, IDisposable, ITickable, IFixedTickable
    {
        #region Fields
        private PlayerAgentView view;
        private PlayerModel playerModel;
        private InputModel inputModel;
        private WeaponModel weaponModel;
        private SignalBus signalBus;
        private bool isGameStart = false;
        #endregion

        #region Core
        [Inject]
        public void Construct(PlayerAgentView view, PlayerModel playerModel, InputModel inputModel, WeaponModel weaponModel, SignalBus signalBus)
        {
            this.view = view;
            this.playerModel = playerModel;
            this.inputModel = inputModel;
            this.weaponModel = weaponModel;
            this.signalBus = signalBus;

            this.view.Initialize(this.playerModel, this.inputModel, this.weaponModel);

            this.view.OnDead += onPlayerDead;
            this.view.OnWeaponCanShoot += onWeaponCanShoot;

            signalBus.Subscribe<Structs.OnChangeGameState>(x => onChangeGameState(x.NewGameState));
        }
        public void Dispose()
        {
            view.OnDead -= onPlayerDead;
            view.OnWeaponCanShoot -= onWeaponCanShoot;

            signalBus.Unsubscribe<Structs.OnChangeGameState>(x => onChangeGameState(x.NewGameState));
        }
        #endregion

        #region Receivers
        private void onPlayerDead()
        {
            signalBus.Fire(new Structs.OnChangeGameState { NewGameState = Enums.GameState.Over });
        }
        private void onWeaponCanShoot()
        {
            signalBus.Fire(new Structs.OnWeaponCanShoot { });
        }
        private void onChangeGameState(Enums.GameState gameState)
        {
            isGameStart = gameState == Enums.GameState.Start;

            if (!isGameStart)
                view.Reload();
        }
        #endregion

        #region Updates
        public void Tick()
        {
            if (!isGameStart)
                return;

            view.OnGameUpdate();
        }
        public void FixedTick()
        {
            if (!isGameStart)
                return;

            view.OnGameFixedUpdate();
        }
        #endregion
    }
}
