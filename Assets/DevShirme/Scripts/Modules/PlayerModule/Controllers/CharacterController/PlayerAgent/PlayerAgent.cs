using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerAgent : MonoBehaviour
    {
        #region Fields
        [Header("Components")]
        [SerializeField] private Weapon weapon;
        private Rigidbody rb;
        [Header("Handlers")]
        private AgentHandler movementHandler;
        private AgentHandler rotationHandler;
        private WeaponHandler weaponHandler;
        #endregion

        #region Core
        public void Initialize(CharacterControllerSettings ccSettings)
        {
            rb = GetComponent<Rigidbody>();

            movementHandler = new MovementHandler(ccSettings.MovementData, transform, rb);
            rotationHandler = new RotationHandler(ccSettings.RotationData, transform, rb);
            weaponHandler = new WeaponHandler(weapon, .5f, transform, rb);
        }
        #endregion

        #region Handlers
        public void Movement(Vector2 input, Enums.MovementState keyCodeState)
        {
            movementHandler.Execute(input, keyCodeState);
        }
        public void Rotation(Vector2 input, Enums.MovementState keyCodeState)
        {
            rotationHandler.Execute(input, keyCodeState);
        }
        public void Weapon(bool leftClick, Enums.MovementState keyCodeState)
        {
            if (leftClick)
                weaponHandler.Execute(Vector2.zero, keyCodeState);
        }
        #endregion
    }
}
