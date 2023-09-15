using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public class RotationHandler : AgentHandler
    {
        #region Fields
        private readonly Structs.RotationData rotationData;
        private Vector2 rotationInput;
        private float rotY;
        #endregion

        #region Core
        public RotationHandler(Structs.RotationData rotationData, Transform obj, Rigidbody rb) : base(obj, rb)
        {
            this.rotationData = rotationData;
        }
        #endregion

        #region Updates
        public override void Execute(Vector2 input, Enums.MovementState keyCodeState)
        {
            rotationInput = input;

            rotate();
        }
        #endregion

        #region Rotations
        private void rotate()
        {
            rotY = Mathf.Atan2(rotationInput.x, rotationInput.y) * Mathf.Rad2Deg;
            Quaternion targetRot = Quaternion.Euler(0f, rotY, 0f);
            _obj.rotation = Quaternion.Lerp(_obj.rotation, targetRot, Time.deltaTime * rotationData.RotationSpeed);
        }
        #endregion
    }
}
