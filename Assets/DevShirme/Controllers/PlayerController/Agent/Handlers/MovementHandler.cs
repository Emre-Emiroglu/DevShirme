using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;

namespace DevShirme.PlayerModule
{
    public class MovementHandler : AgentHandler
    {
        #region Fields
        private Vector3 moveDir;
        private Rigidbody rb;
        #endregion

        #region Core
        public override void Initialize(PlayerSettings settings)
        {
            base.Initialize(settings);
            rb = GetComponent<Rigidbody>();
        }
        public override void Execute(Vector2 input)
        {
            classicMovement(input);
        }
        #endregion

        #region Movements
        private void classicMovement(Vector2 input)
        {
            moveDir = new Vector3(input.x, 0f, input.y);
            switch (settings.MovementType)
            {
                case Enums.MovementType.Transform:
                    transform.position += moveDir * settings.MovementSpeed * Time.deltaTime;
                    break;
                case Enums.MovementType.Rigidbody:
                    rb.velocity = moveDir * settings.MovementSpeed * Time.fixedDeltaTime;
                    break;
            }
        }
        #endregion
    }
}
