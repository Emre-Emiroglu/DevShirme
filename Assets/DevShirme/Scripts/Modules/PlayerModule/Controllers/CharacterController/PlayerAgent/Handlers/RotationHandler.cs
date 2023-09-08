using DevShirme.Interfaces;
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
        #endregion

        #region Core
        public RotationHandler(Structs.RotationData rotationData, ISubject subject, Transform obj, Rigidbody rb) : base(subject, obj, rb)
        {
            this.rotationData = rotationData;
        }
        #endregion

        #region Observer
        public override void OnNotify(object value, Enums.NotificationType notificationType)
        {
        }
        #endregion

        #region Updates
        public override void ExternalUpdate()
        {
            rotate();
        }
        public override void ExternalFixedUpdate()
        {
        }
        #endregion

        #region Rotations
        private void rotate()
        {
        }
        #endregion
    }
}
