using DevShirme.Interfaces;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public class MovementHandler : AgentHandler
    {
        #region Fields
        private readonly Structs.MovementData movementData;
        private Vector2 movementInput;
        private bool isRun;
        private bool isJump;
        #endregion

        #region Core
        public MovementHandler(Structs.MovementData movementData, ISubject subject, Transform obj, Rigidbody rb) : base(subject, obj, rb)
        {
            this.movementData = movementData;
        }
        #endregion

        #region Observer
        public override void OnNotify(object value, Enums.NotificationType notificationType)
        {
            movementInput = (Vector2)value;

            isRun = notificationType == Enums.NotificationType.Run;
            isJump = notificationType == Enums.NotificationType.Jump;
        }
        #endregion

        #region Updates
        public override void ExternalUpdate()
        {
            if (movementData.MovementType == Enums.MovementType.Rigidbody)
                return;

            transformMovement();
            transformJump();
        }
        public override void ExternalFixedUpdate()
        {
            if (movementData.MovementType == Enums.MovementType.Transform)
                return;

            rigidbodyMovement();
            rigidbodyJump();
        }
        #endregion

        #region Movements
        private Vector3 getAcceleration()
        {
            float speedMultiplier = isRun ? movementData.RunSpeed : movementData.WalkSpeed;
            Vector3 input = new Vector3(movementInput.x, 0f, movementInput.y);
            Vector3 acc = input * speedMultiplier;
            return acc;
        }
        private void transformMovement()
        {
            _obj.transform.position += getAcceleration() * Time.deltaTime;
        }
        private void rigidbodyMovement()
        {
            _rb.velocity += getAcceleration() * Time.fixedDeltaTime;
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, isRun ? movementData.RunSpeed : movementData.WalkSpeed);
        }
        #endregion

        #region Jumps
        private void transformJump()
        {
            float jump = 0f;
            if (isJump)
            {
                jump = movementData.JumpPower;
            }
            else
            {
                jump = Mathf.Lerp(jump, 0f, Time.deltaTime);
            }
            _obj.transform.Translate(new Vector3(0f, jump, 0f) * Time.deltaTime);
        }
        private void rigidbodyJump()
        {
            if (isJump)
                _rb.AddForce(Vector3.up * movementData.JumpPower * Time.fixedDeltaTime, movementData.JumpForceMode);
        }
        #endregion
    }
}
