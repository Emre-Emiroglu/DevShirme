using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputBehavior
{
    Unclamped,
    Clamped
}

public class InputController
{
    public bool Lerp = false;
    public float LerpSpeed = 0.1f;
    public float Sensitivity = 1f;
    public float ClampDistance = 80f;
    public InputBehavior Behavior = InputBehavior.Clamped;

    Vector2 outputRaw, outputNormal;
    Vector2 beganPos, movedPos;
    Vector2 prevPos, currPos;
    Vector2 deltaPos, clampPos;
    bool isPressing;

    public bool IsPressing
    {
        get
        {
            return isPressing;
        }
    }

    public float Severity
    {
        get
        {
            return outputNormal.magnitude;
        }
    }

    public float Magnitude
    {
        get
        {
            return outputRaw.magnitude;
        }
    }

    public Vector2 Value
    {
        get
        {
            return outputNormal;
        }
    }

    public Vector2 DeltaPos
    {
        get
        {
            return deltaPos;
        }
    }

    public Vector2 BeganPos
    {
        get
        {
            return beganPos;
        }
    }

    public Vector2 MovedPos
    {
        get
        {
            return movedPos;
        }
    }

    public void RemoveInputs()
    {
        outputNormal = Vector2.zero;
        beganPos = Vector2.zero;
        movedPos = Vector2.zero;
        deltaPos = Vector2.zero;
        outputRaw = Vector2.zero;
        isPressing = false;
    }

    public void Update()
    {
        inputUpdate();
    }

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

}