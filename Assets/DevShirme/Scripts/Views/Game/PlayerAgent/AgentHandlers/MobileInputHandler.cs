using DevShirme.Interfaces.Game;
using DevShirme.Utils.Enums;
using DevShirme.Utils.Structs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Views.PlayerAgent.AgentHandlers
{
    public class MobileInputHandler
    {
        #region Fields
        private readonly IInputModel inputModel;
        private readonly Structs.MobileInputData mobileInputData;
        private Structs.InputData inputData;
        private bool isPressing;
        private Vector2 outputRaw, outputNormal;
        private Vector2 beganPos, movedPos;
        private Vector2 prevPos, currPos;
        private Vector2 deltaPos, clampPos;
        #endregion

        #region Getters
        public Structs.InputData InputData => inputData;
        #endregion

        #region Core
        public MobileInputHandler(IInputModel inputModel)
        {
            this.inputModel = inputModel;
            mobileInputData = this.inputModel.MobileInputData;
        }
        #endregion

        #region Executes
        public void Reload()
        {
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

                inputData.MovementInput = Vector2.zero;
                inputData.MovementState = Enums.MovementState.Walk;
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

                inputData.MovementInput = deltaPos;
                inputData.MovementState = Enums.MovementState.Walk;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isPressing = false;
                outputRaw = Vector3.zero;
                deltaPos = Vector3.zero;
                outputNormal = Vector2.zero;

                inputData.MovementInput = Vector2.zero;
                inputData.MovementState = Enums.MovementState.Walk;
            }

            inputData.LeftClick = isPressing;
        }
        #endregion

        #region GameUpdates
        public void GameUpdate() => MobileInput();
        #endregion
    }
}
