using DevShirme.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public class MobileInputController : InputController
    {
        #region Fields
        public event Action OnDown;
        public event Action OnDrag;
        public event Action OnUp;
        private readonly Structs.MobileInputData data;
        private bool isPressing;
        private Vector2 outputRaw, outputNormal;
        private Vector2 beganPos, movedPos;
        private Vector2 prevPos, currPos;
        private Vector2 deltaPos, clampPos;
        #endregion

        #region Getters
        public bool IsPressing => isPressing;
        public float OutputNormaMagnitude => outputNormal.magnitude;
        public float OutputRawMagnitude => outputRaw.magnitude;
        public Vector2 OutputNormal => outputNormal;
        public Vector2 DeltaPos => deltaPos;
        public Vector2 BeganPos => beganPos;
        public Vector2 MovedPos => movedPos;
        #endregion

        #region Core
        public MobileInputController(ScriptableObject _settings) : base(_settings)
        {
            this.data = _icSettings.MobileInputData;
        }
        protected override void inputUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isPressing = true;
                beganPos = Input.mousePosition;
                currPos = beganPos;
                prevPos = beganPos;

                OnDown?.Invoke();
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

                OnDrag?.Invoke();
            }
            if (Input.GetMouseButtonUp(0))
            {
                isPressing = false;
                outputRaw = Vector3.zero;
                deltaPos = Vector3.zero;
                outputNormal = Vector2.zero;

                OnUp?.Invoke();
            }
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
