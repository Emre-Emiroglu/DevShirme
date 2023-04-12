using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController
{
    #region Fields
    private bool Lerp;
    private float LerpSpeed;
    private float Sensitivity;
    private float ClampDistance;
    private InputBehavior Behavior;
    Vector2 outputRaw, outputNormal;
    Vector2 beganPos, movedPos;
    Vector2 prevPos, currPos;
    Vector2 deltaPos, clampPos;
    bool isPressing;
    #endregion


    #region Constructor
    public InputController(bool lerp = false, float lerpSpeed = .1f, float sensitivity = 1f, float clampDistance = 80f, InputBehavior behavior = InputBehavior.Clamped)
    {
        Lerp = lerp;
        LerpSpeed = lerpSpeed;
        Sensitivity = sensitivity;
        ClampDistance = clampDistance;
        Behavior = behavior;
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
    public void ExternaUpdate() => inputUpdate();
    private void inputUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPressing = true;
            beganPos = Input.mousePosition;
            currPos = beganPos;
            prevPos = beganPos;
        }

        if (Input.GetMouseButton(0))
        {
            isPressing = true;
            currPos = Input.mousePosition;
            deltaPos = (currPos - prevPos) * Sensitivity;

            if (Behavior == InputBehavior.Clamped)
                movedPos = beganPos + Vector2.ClampMagnitude(currPos - beganPos, ClampDistance);
            else
                movedPos = currPos;

            if (Lerp)
                outputRaw = Vector3.Lerp(outputRaw, (movedPos - beganPos).normalized, LerpSpeed);
            else
                outputRaw = (movedPos - beganPos);

            outputNormal = outputRaw.normalized;
            prevPos = currPos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isPressing = false;
            outputRaw = Vector3.zero;
            deltaPos = Vector3.zero;
            outputNormal = Vector2.zero;
        }
    }
    #endregion
}
public enum InputBehavior
{
    Unclamped,
    Clamped
}