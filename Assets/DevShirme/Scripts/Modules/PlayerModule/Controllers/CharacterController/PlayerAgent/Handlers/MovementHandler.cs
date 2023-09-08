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
        private bool isJump;
        private bool isSlide;
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
        }
        #endregion

        #region Updates
        public override void ExternalUpdate()
        {
            if (movementData.MovementType == Enums.MovementType.Rigidbody)
                return;

            transformMovement();
            transformSlide();
            transformJump();
        }
        public override void ExternalFixedUpdate()
        {
            if (movementData.MovementType == Enums.MovementType.Transform)
                return;

            rigidbodyMovement();
            rigidbodySlide();
            rigidbodyJump();
        }
        #endregion

        #region Movements
        private void transformMovement()
        {
            _obj.transform.position += new Vector3(movementInput.x, 0f, movementInput.y) * movementData.WalkSpeed * Time.deltaTime;
        }
        private void rigidbodyMovement()
        {
        }
        #endregion

        #region Slides
        private void transformSlide()
        {
        }
        private void rigidbodySlide()
        {
        }
        #endregion

        #region Jumps
        private void transformJump()
        {
        }
        private void rigidbodyJump()
        {
        }
        #endregion
    }
}
