using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Views
{
    public class AgentInputHandler : AgentHandler
    {
        #region Fields
        protected Structs.InputData _inputData;
        #endregion

        #region Getters
        #endregion

        #region Core
        protected AgentInputHandler(Transform obj, Rigidbody rb): base(obj, rb)
        {
        }
        #endregion

        #region Executes
        public override void OnGameUpdate()
        {
            InputData = _inputData;
        }
        public override void Reload()
        {
            _inputData.MovementInput = Vector2.zero;
            _inputData.RotationInput = Vector2.zero;
            _inputData.MovementState = Enums.MovementState.Walk;
            _inputData.LeftClick = false;
            _inputData.IsRunKeyPressed = false;
            _inputData.IsJumpKeyPressed = false;
        }
        #endregion
    }
}
