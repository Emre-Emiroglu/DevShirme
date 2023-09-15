using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public class MobileInputController : InputController
    {
        #region Fields
        private readonly Structs.MobileInputData data;
        private bool isPressing;
        private Vector2 outputRaw, outputNormal;
        private Vector2 beganPos, movedPos;
        private Vector2 prevPos, currPos;
        private Vector2 deltaPos, clampPos;
        #endregion

        #region Core
        public MobileInputController(InputControllerSettings _icSettings) : base(_icSettings)
        {
            data = _icSettings.MobileInputData;
        }
        protected override void inputUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isPressing = true;
                beganPos = Input.mousePosition;
                currPos = beganPos;
                prevPos = beganPos;

                _movementInput = Vector2.zero;
                _keyCodeState = Enums.MovementState.Walk;
            }
            if (Input.GetMouseButton(0))
            {
                isPressing = true;
                currPos = Input.mousePosition;
                deltaPos = (currPos - prevPos) * data.Sensitivity;

                if (data.MobileInputBehavior == Enums.MobileInputBehavior.Clamped)
                    movedPos = beganPos + Vector2.ClampMagnitude(currPos - beganPos, data.ClampDistance);
                else
                    movedPos = currPos;

                if (data.Lerp)
                    outputRaw = Vector3.Lerp(outputRaw, (movedPos - beganPos).normalized, data.LerpSpeed);
                else
                    outputRaw = (movedPos - beganPos);

                outputNormal = outputRaw.normalized;

                if (!data.Swipe)
                    prevPos = currPos;

                _movementInput = deltaPos;
                _keyCodeState = Enums.MovementState.Walk;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isPressing = false;
                outputRaw = Vector3.zero;
                deltaPos = Vector3.zero;
                outputNormal = Vector2.zero;

                _movementInput = Vector2.zero;
                _keyCodeState = Enums.MovementState.Walk;
            }

            _leftClick = isPressing;
        }
        public override void ClearInputs()
        {
            outputNormal = Vector2.zero;
            beganPos = Vector2.zero;
            movedPos = Vector2.zero;
            deltaPos = Vector2.zero;
            outputRaw = Vector2.zero;
            isPressing = false;
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
