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
        #endregion

        #region Core
        public MovementHandler(Structs.MovementData movementData)
        {
            this.movementData = movementData;
        }
        #endregion

        #region Updates
        public override void ExternalUpdate(Vector2 input)
        {
            if (movementData.MovementType == Enums.MovementType.Rigidbody)
                return;

            transformMovement();
            transformSlide();
            transformJump();
        }
        public override void ExternalFixedUpdate(Vector2 input)
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
