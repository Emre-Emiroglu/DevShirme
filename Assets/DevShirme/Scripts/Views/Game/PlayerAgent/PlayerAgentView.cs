using DevShirme.Utils.Enums;
using DevShirme.Utils.Structs;
using DevShirme.Views.PlayerAgent.AgentHandlers;
using System;
using UnityEngine;
using Zenject;

namespace DevShirme.Views.PlayerAgent
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerAgentView : MonoBehaviour, IInitializable, IDisposable, ITickable, IFixedTickable
    {
        #region Injects
        [Inject] private SignalBus signalBus;
        [Inject] private PCInputHandler inputHandler;
        [Inject] private MovementHandler movementHandler;
        [Inject] private RotationHandler rotationHandler;
        [Inject] private WeaponHandler weaponHandler;
        #endregion

        #region Fields
        [Header("Components")]
        private Rigidbody rb;
        private Transform _transform;
        [Header("Checks")]
        private bool isDead;
        private bool isGameStart = false;
        #endregion

        #region Core
        public void Initialize()
        {
            rb = GetComponent<Rigidbody>();
            _transform = transform;

            signalBus.Subscribe<Structs.OnChangeGameState>(x => OnChangeGameState(x.NewGameState));
        }
        public void Dispose()
        {
            signalBus.TryUnsubscribe<Structs.OnChangeGameState>(x => OnChangeGameState(x.NewGameState));
        }
        private void Reload()
        {
            isDead = false;

            inputHandler.Reload();
            movementHandler.Reload(_transform, rb);
            rotationHandler.Reload(_transform, rb);
            weaponHandler.Reload();
        }
        #endregion

        #region Receivers
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

            movementHandler.InputData = inputHandler.InputData;
            rotationHandler.InputData = inputHandler.InputData;
            weaponHandler.InputData = inputHandler.InputData;

            inputHandler.GameUpdate();
            movementHandler.GameUpdate(_transform);
            rotationHandler.GameUpdate(_transform);
            weaponHandler.GameUpdate();
        }
        public void FixedTick()
        {
            if (!isGameStart)
                return;

            movementHandler.GameFixedUpdate(rb);
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
