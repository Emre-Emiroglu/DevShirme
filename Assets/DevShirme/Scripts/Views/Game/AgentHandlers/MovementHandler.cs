using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Views
{
    public class MovementHandler: AgentHandler
    {
        #region Fields
        private readonly Structs.MovementData movementData;
        #endregion

        #region Core
        public MovementHandler(Structs.MovementData movementData, Transform obj, Rigidbody rb) : base(obj, rb)
        {
            this.movementData = movementData;
        }
        #endregion

        #region Executes
        public override void OnGameUpdate()
        {
            if (movementData.MovementType == Enums.MovementType.Transform)
            {
                TransformMovement();
                TransformJump();
            }
        }
        public override void OnGameFixedUpdate()
        {
            if (movementData.MovementType == Enums.MovementType.Rigidbody)
            {
                RigidbodyMovement();
                RigidbodyJump();
            }
        }
        public override void Reload()
        {
            _obj.position = Vector3.zero;
            _rb.velocity = Vector3.zero;
        }
        private Vector3 GetAcceleration()
        {
            float speedMultiplier = InputData.IsRunKeyPressed ? movementData.RunSpeed : movementData.WalkSpeed;
            Vector3 input = new Vector3(InputData.MovementInput.x, 0f, InputData.MovementInput.y);
            Vector3 acc = input * speedMultiplier;
            return acc;
        }
        private void TransformMovement()
        {
            _obj.position += GetAcceleration() * Time.deltaTime;
        }
        private void RigidbodyMovement()
        {
            _rb.velocity += GetAcceleration() * Time.fixedDeltaTime;
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, InputData.IsRunKeyPressed ? movementData.RunSpeed : movementData.WalkSpeed);
        }
        private void TransformJump()
        {
            float jump = 0f;
            if (InputData.IsJumpKeyPressed)
            {
                jump = movementData.JumpPower;
            }
            else
            {
                jump = Mathf.Lerp(jump, 0f, Time.deltaTime);
            }
            _obj.Translate(new Vector3(0f, jump, 0f) * Time.deltaTime);
        }
        private void RigidbodyJump()
        {
            if (InputData.IsJumpKeyPressed)
                _rb.AddForce(Vector3.up * movementData.JumpPower * Time.fixedDeltaTime, movementData.JumpForceMode);
        }
        #endregion
    }
}
