using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public class PCInputController : InputController
    {
        #region Fields
        private readonly Structs.PCInputData data;
        private bool isRunKeyPressed;
        private bool isJumpKeyPressed;
        #endregion

        #region Getters
        #endregion

        #region Core
        public PCInputController(ScriptableObject _settings) : base(_settings)
        {
            this.data = _icSettings.PCInputData;
        }
        protected override void inputUpdate()
        {
            switch (data.PCInputBehavior)
            {
                case Enums.PCInputBehavior.Raw:
                    _movementInput = new Vector2(Input.GetAxis(data.HorizontalAxis), Input.GetAxis(data.VerticalAxis));
                    _rotationInput = new Vector2(Input.GetAxis(data.MouseX), Input.GetAxis(data.MouseY));
                    break;
                case Enums.PCInputBehavior.NonRaw:
                    _movementInput = new Vector2(Input.GetAxisRaw(data.HorizontalAxis), Input.GetAxisRaw(data.VerticalAxis));
                    _rotationInput = new Vector2(Input.GetAxisRaw(data.MouseX), Input.GetAxisRaw(data.MouseY));
                    break;
            }

            isRunKeyPressed = Input.GetKey(data.RunKey);
            isJumpKeyPressed = Input.GetKeyUp(data.JumpKey);

            _keyCodeState = isRunKeyPressed ? Enums.KeyCodeState.Run : isJumpKeyPressed ? Enums.KeyCodeState.Jump : Enums.KeyCodeState.Walk;
        }
        public override void ClearInputs()
        {
        }
        #endregion

        #region Updates
        public override void ExternalUpdate()
        {
            base.ExternalUpdate();

            inputUpdate();
        }
        public override void ExternalFixedUpdate()
        {
            base.ExternalFixedUpdate();
        }
        #endregion
    }
}
