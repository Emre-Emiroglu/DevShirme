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
        #endregion

        #region Core
        public RotationHandler(Structs.RotationData rotationData)
        {
            this.rotationData = rotationData;
        }
        #endregion

        #region Updates
        public override void ExternalUpdate(Vector2 input)
        {
            rotate(input);
        }
        public override void ExternalFixedUpdate(Vector2 input)
        {
        }
        #endregion

        #region Rotations
        private void rotate(Vector2 input)
        {
        }
        #endregion
    }
}
