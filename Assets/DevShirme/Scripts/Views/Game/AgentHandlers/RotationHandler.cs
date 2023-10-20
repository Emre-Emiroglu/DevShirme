using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Views
{
    public class RotationHandler : AgentHandler
    {
        #region Fields
        private readonly Structs.RotationData rotationData;
        #endregion

        #region Core
        public RotationHandler(Structs.RotationData rotationData, Transform obj, Rigidbody rb) : base(obj, rb)
        {
            this.rotationData = rotationData;
        }
        #endregion

        #region Executes
        public override void OnGameUpdate()
        {
            Rotate();
        }
        public override void Reload()
        {
            _obj.rotation = Quaternion.identity;
            _rb.angularVelocity = Vector3.zero;
        }
        private void Rotate()
        {
            Vector3 diff = new Vector3(InputData.RotationInput.x, 0f, InputData.RotationInput.y) - _obj.position;

            if (diff.magnitude > .1f)
            {
                Quaternion targetRot = Quaternion.LookRotation(diff, Vector3.up);

                _obj.rotation = Quaternion.Lerp(_obj.rotation, targetRot, Time.deltaTime * rotationData.RotationSpeed);
            }
        }
        #endregion
    }
}
