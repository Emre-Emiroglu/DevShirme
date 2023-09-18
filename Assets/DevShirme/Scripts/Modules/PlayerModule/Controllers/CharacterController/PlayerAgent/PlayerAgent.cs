using DevShirme.DesignPatterns.Behaviorals;
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
        [Header("Events")]
        [SerializeField] private GameEvent gameOverEvent;
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
            weaponHandler = new WeaponHandler(weapon, transform, rb);
        }
        public void Reload()
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
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

        #region Physic
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
                gameOverEvent?.Notify(null);
        }
        #endregion
    }
}
