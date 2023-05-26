using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;

namespace DevShirme.PlayerModule
{
    public class InputController
    {
        #region Fields
        public event Action OnDown;
        public event Action OnDrag;
        public event Action OnUp;
        private bool lerp;
        private float lerpSpeed;
        private float sensitivity;
        private float clampDistance;
        private Enums.InputBehavior behavior;
        private bool swipe;
        Vector2 outputRaw, outputNormal;
        Vector2 beganPos, movedPos;
        Vector2 prevPos, currPos;
        Vector2 deltaPos, clampPos;
        bool isPressing;
        #endregion

        #region Constructor
        public InputController(bool lerp = false, float lerpSpeed = .1f, float sensitivity = 1f, float clampDistance = 80f, Enums.InputBehavior behavior = Enums.InputBehavior.Clamped, bool swipe = false)
        {
            this.lerp = lerp;
            this.lerpSpeed = lerpSpeed;
            this.sensitivity = sensitivity;
            this.clampDistance = clampDistance;
            this.behavior = behavior;
            this.swipe = swipe;
        }
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

        #region Executes
        public void RemoveInputs()
        {
            outputNormal = Vector2.zero;
            beganPos = Vector2.zero;
            movedPos = Vector2.zero;
            deltaPos = Vector2.zero;
            outputRaw = Vector2.zero;
            isPressing = false;
        }
        public void ExternaUpdate(bool down, bool drag, bool up) => inputUpdate(down, drag, up);
        private void inputUpdate(bool down, bool drag, bool up)
        {
            if (down)
            {
                isPressing = true;
                beganPos = Input.mousePosition;
                currPos = beganPos;
                prevPos = beganPos;

                OnDown?.Invoke();
            }
            if (drag)
            {
                isPressing = true;
                currPos = Input.mousePosition;
                deltaPos = (currPos - prevPos) * sensitivity;

                if (behavior == Enums.InputBehavior.Clamped)
                    movedPos = beganPos + Vector2.ClampMagnitude(currPos - beganPos, clampDistance);
                else
                    movedPos = currPos;

                if (lerp)
                    outputRaw = Vector3.Lerp(outputRaw, (movedPos - beganPos).normalized, lerpSpeed);
                else
                    outputRaw = (movedPos - beganPos);

                outputNormal = outputRaw.normalized;

                if (!swipe)
                    prevPos = currPos;

                OnDrag?.Invoke();
            }
            if (up)
            {
                isPressing = false;
                outputRaw = Vector3.zero;
                deltaPos = Vector3.zero;
                outputNormal = Vector2.zero;

                OnUp?.Invoke();
            }
        }
        #endregion
    }
}
