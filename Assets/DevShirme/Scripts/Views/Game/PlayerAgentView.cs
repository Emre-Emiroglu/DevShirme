using DevShirme.Models;
using DevShirme.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Views
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerAgentView : MonoBehaviour, IDisposable, ITickable, IFixedTickable
    {
        #region Injects
        private PlayerModel playerModel;
        private InputModel inputModel;
        private WeaponModel weaponModel;
        private SignalBus signalBus;
        #endregion

        #region Fields
        [Header("Components")]
        private Rigidbody rb;
        [Header("Handlers")]
        private AgentInputHandler pcInputHandler;
        private AgentHandler movementHandler;
        private AgentHandler rotationHandler;
        private AgentHandler weaponHandler;
        [Header("Checks")]
        private bool isDead;
        private bool isGameStart = false;
        #endregion

        #region Core
        [Inject]
        public void Construct(PlayerModel playerModel, InputModel inputModel, WeaponModel weaponModel, SignalBus signalBus)
        {
            this.playerModel = playerModel;
            this.inputModel = inputModel;
            this.weaponModel = weaponModel;
            this.signalBus = signalBus;

            rb = GetComponent<Rigidbody>();

            pcInputHandler = new PCInputHandler(this.inputModel.PCInputData, transform, rb);
            movementHandler = new MovementHandler(this.playerModel.MovementData, transform, rb);
            rotationHandler = new RotationHandler(this.playerModel.RotationData, transform, rb);
            weaponHandler = new WeaponHandler(this.weaponModel.FireRate, transform, rb);

            ((WeaponHandler)weaponHandler).OnWeaponCanShoot = OnWeaponCanShoot;

            this.signalBus.Subscribe<Structs.OnChangeGameState>(x => OnChangeGameState(x.NewGameState));
        }
        public void Dispose()
        {
            signalBus.TryUnsubscribe<Structs.OnChangeGameState>(x => OnChangeGameState(x.NewGameState));
        }
        private void Reload()
        {
            isDead = false;

            pcInputHandler.Reload();
            movementHandler.Reload();
            rotationHandler.Reload();
            weaponHandler.Reload();
        }
        #endregion

        #region Receivers
        private void OnWeaponCanShoot()
        {
            signalBus.Fire(new Structs.OnWeaponCanShoot { });
        }
        private void OnChangeGameState(Enums.GameState gameState)
        {
            isGameStart = gameState == Enums.GameState.Start;

            if (!isGameStart)
                Reload();
        }
        #endregion

        #region Ticks
        public void Tick()
        {
            if (!isGameStart)
                return;

            pcInputHandler.OnGameUpdate();

            movementHandler.InputData = pcInputHandler.InputData;
            rotationHandler.InputData = pcInputHandler.InputData;
            weaponHandler.InputData = pcInputHandler.InputData;

            movementHandler.OnGameUpdate();
            rotationHandler.OnGameUpdate();
            weaponHandler.OnGameUpdate();
        }
        public void FixedTick()
        {
            if (!isGameStart)
                return;

            movementHandler.OnGameFixedUpdate();
        }
        #endregion

        #region Physic
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && !isDead)
            {
                isDead = true;
                signalBus.Fire(new Structs.OnChangeGameState { NewGameState = Enums.GameState.Over });
            }
        }
        #endregion
    }
}
