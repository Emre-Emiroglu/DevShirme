using DevShirme.Interfaces;
using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Views
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerAgentView : View
    {
        #region Events
        public Action OnDead;
        public Action OnWeaponCanShoot;
        #endregion

        #region Fields
        [Header("Components")]
        private Rigidbody rb;
        [Header("Handlers")]
        private AgentInputHandler pcInputHandler;
        private AgentHandler movementHandler;
        private AgentHandler rotationHandler;
        private AgentHandler weaponHandler;
        #endregion

        #region Core
        public void Initialize(IPlayerModel playerModel, IInputModel inputModel, IWeaponModel weaponModel)
        {
            rb = GetComponent<Rigidbody>();

            pcInputHandler = new PCInputHandler(inputModel.InputSettings.PCInputData, transform, rb);
            movementHandler = new MovementHandler(playerModel.PlayerSettings.MovementData, transform, rb);
            rotationHandler = new RotationHandler(playerModel.PlayerSettings.RotationData, transform, rb);
            weaponHandler = new WeaponHandler(weaponModel.WeaponSettings.FireRate, transform, rb);

            ((WeaponHandler)weaponHandler).OnWeaponCanShoot = onWeaponCanShoot;
        }
        public void Reload()
        {
            pcInputHandler.Reload();
            movementHandler.Reload();
            rotationHandler.Reload();
            weaponHandler.Reload();
        }
        #endregion

        #region Receivers
        private void onWeaponCanShoot() => OnWeaponCanShoot?.Invoke();
        #endregion

        #region Updates
        public void OnGameUpdate()
        {
            pcInputHandler.OnGameUpdate();

            movementHandler.InputData = pcInputHandler.InputData;
            rotationHandler.InputData = pcInputHandler.InputData;
            weaponHandler.InputData = pcInputHandler.InputData;

            movementHandler.OnGameUpdate();
            rotationHandler.OnGameUpdate();
            weaponHandler.OnGameUpdate();
        }
        public void OnGameFixedUpdate()
        {
            movementHandler.OnGameFixedUpdate();
        }
        #endregion

        #region Physic
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
                OnDead?.Invoke();
        }
        #endregion
    }
}
