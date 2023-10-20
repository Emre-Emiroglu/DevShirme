using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Views
{
    public class PCInputHandler : AgentInputHandler
    {
        #region Fields
        private readonly Structs.PCInputData pcInputData;
        #endregion

        #region Core
        public PCInputHandler(Structs.PCInputData pcInputData, Transform obj, Rigidbody rb) : base(obj, rb)
        {
            this.pcInputData = pcInputData;
        }
        #endregion

        #region Executes
        public override void OnGameUpdate()
        {
            PcInput();

            base.OnGameUpdate();
        }
        public override void Reload()
        {
            base.Reload();
        }
        private void PcInput()
        {
            switch (pcInputData.PCInputBehavior)
            {
                case Enums.PCInputBehavior.Raw:
                    _inputData.MovementInput = new Vector2(Input.GetAxis(pcInputData.HorizontalAxis), Input.GetAxis(pcInputData.VerticalAxis));
                    break;
                case Enums.PCInputBehavior.NonRaw:
                    _inputData.MovementInput = new Vector2(Input.GetAxisRaw(pcInputData.HorizontalAxis), Input.GetAxisRaw(pcInputData.VerticalAxis));
                    break;
            }

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
            _inputData.RotationInput = new Vector2(mouseWorldPos.x, mouseWorldPos.z);

            _inputData.IsRunKeyPressed = Input.GetKey(pcInputData.RunKey);
            _inputData.IsJumpKeyPressed = Input.GetKeyUp(pcInputData.JumpKey);

            _inputData.MovementState = _inputData.IsRunKeyPressed ? Enums.MovementState.Run : _inputData.IsJumpKeyPressed ? Enums.MovementState.Jump : Enums.MovementState.Walk;

            _inputData.LeftClick = Input.GetMouseButton(0);
        }
        #endregion
    }
}
