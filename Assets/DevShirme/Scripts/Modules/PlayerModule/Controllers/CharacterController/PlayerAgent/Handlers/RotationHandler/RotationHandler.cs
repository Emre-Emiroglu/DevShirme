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
            Vector3 diff = new Vector3(rotationInput.x, 0f, rotationInput.y) - _obj.position;
            Quaternion targetRot = Quaternion.LookRotation(diff, Vector3.up);

            _obj.rotation = Quaternion.Lerp(_obj.rotation, targetRot, Time.deltaTime * rotationData.RotationSpeed);
        }
        #endregion
    }
}
