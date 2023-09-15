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
        private readonly Camera mainCam;
        private bool isRunKeyPressed;
        private bool isJumpKeyPressed;
        #endregion

        #region Core
        public PCInputController(InputControllerSettings _icSettings) : base(_icSettings)
        {
            data = _icSettings.PCInputData;
            mainCam = Camera.main;
        }
        protected override void inputUpdate()
        {
            switch (data.PCInputBehavior)
            {
                case Enums.PCInputBehavior.Raw:
                    _movementInput = new Vector2(Input.GetAxis(data.HorizontalAxis), Input.GetAxis(data.VerticalAxis));
                    break;
                case Enums.PCInputBehavior.NonRaw:
                    _movementInput = new Vector2(Input.GetAxisRaw(data.HorizontalAxis), Input.GetAxisRaw(data.VerticalAxis));
                    break;
            }

            Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
            _rotationInput = new Vector2(mouseWorldPos.x, mouseWorldPos.z);

            isRunKeyPressed = Input.GetKey(data.RunKey);
            isJumpKeyPressed = Input.GetKeyUp(data.JumpKey);

            _keyCodeState = isRunKeyPressed ? Enums.KeyCodeState.Run : isJumpKeyPressed ? Enums.KeyCodeState.Jump : Enums.KeyCodeState.Walk;
        }
        public override void ClearInputs()
        {
        }
        #endregion

        #region Updates
        public override void Tick()
        {
            base.Tick();

            inputUpdate();
        }
        public override void FixedTick()
        {
            base.FixedTick();
        }
        public override void LateTick()
        {
            base.LateTick();
        }
        #endregion
    }
}
