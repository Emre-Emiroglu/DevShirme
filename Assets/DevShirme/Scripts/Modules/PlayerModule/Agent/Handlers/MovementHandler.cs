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
        private readonly Rigidbody rb;
        #endregion

        #region Core
        public MovementHandler(PlayerSettings settings, Transform obj, Rigidbody rb) : base(settings, obj)
        {
            this.rb = rb;
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
                    _obj.position += moveDir * settings.MovementSpeed * Time.deltaTime;
                    break;
                case Enums.MovementType.Rigidbody:
                    rb.velocity = moveDir * settings.MovementSpeed * Time.fixedDeltaTime;
                    break;
            }
        }
        #endregion
    }
}
