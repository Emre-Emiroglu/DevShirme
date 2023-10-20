using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Views
{
    public class MobileInputHandler : AgentInputHandler
    {
        #region Fields
        private readonly Structs.MobileInputData mobileInputData;
        private bool isPressing;
        private Vector2 outputRaw, outputNormal;
        private Vector2 beganPos, movedPos;
        private Vector2 prevPos, currPos;
        private Vector2 deltaPos, clampPos;
        #endregion

        #region Core
        public MobileInputHandler(Structs.MobileInputData mobileInputData, Transform obj, Rigidbody rb) : base(obj, rb)
        {
            this.mobileInputData = mobileInputData;
        }
        #endregion

        #region Executes
        public override void OnGameUpdate()
        {
            MobileInput();

            base.OnGameUpdate();
        }
        public override void Reload()
        {
            base.Reload();

            outputNormal = Vector2.zero;
            beganPos = Vector2.zero;
            movedPos = Vector2.zero;
            deltaPos = Vector2.zero;
            outputRaw = Vector2.zero;
            isPressing = false;
        }
        private void MobileInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isPressing = true;
                beganPos = Input.mousePosition;
                currPos = beganPos;
                prevPos = beganPos;

                _inputData.MovementInput = Vector2.zero;
                _inputData.MovementState = Enums.MovementState.Walk;
            }
            if (Input.GetMouseButton(0))
            {
                isPressing = true;
                currPos = Input.mousePosition;
                deltaPos = (currPos - prevPos) * mobileInputData.Sensitivity;

                if (mobileInputData.MobileInputBehavior == Enums.MobileInputBehavior.Clamped)
                    movedPos = beganPos + Vector2.ClampMagnitude(currPos - beganPos, mobileInputData.ClampDistance);
                else
                    movedPos = currPos;

                if (mobileInputData.Lerp)
                    outputRaw = Vector3.Lerp(outputRaw, (movedPos - beganPos).normalized, mobileInputData.LerpSpeed);
                else
                    outputRaw = (movedPos - beganPos);

                outputNormal = outputRaw.normalized;

                if (!mobileInputData.Swipe)
                    prevPos = currPos;

                _inputData.MovementInput = deltaPos;
                _inputData.MovementState = Enums.MovementState.Walk;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isPressing = false;
                outputRaw = Vector3.zero;
                deltaPos = Vector3.zero;
                outputNormal = Vector2.zero;

                _inputData.MovementInput = Vector2.zero;
                _inputData.MovementState = Enums.MovementState.Walk;
            }

            _inputData.LeftClick = isPressing;
        }
        #endregion
    }
}
