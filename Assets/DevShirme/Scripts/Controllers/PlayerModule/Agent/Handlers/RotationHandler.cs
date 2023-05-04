using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.PlayerModule
{
    public class RotationHandler : AgentHandler
    {
        #region Fields
        private float rotY;
        #endregion

        #region Core
        public RotationHandler(PlayerSettings settings, Transform obj) : base(settings, obj)
        {
        }
        public override void Execute(Vector2 input)
        {
            if (input.sqrMagnitude > 0.1)
            {
                rotY = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
                _obj.rotation = Quaternion.Lerp(_obj.rotation, Quaternion.Euler(new Vector3(0f, rotY, 0f)), Time.deltaTime * settings.RotationSpeed);
            }
        }
        #endregion
    }
}
