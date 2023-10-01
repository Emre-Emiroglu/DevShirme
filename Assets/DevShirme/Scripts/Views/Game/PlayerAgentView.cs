using DevShirme.Interfaces;
using DevShirme.Utils;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Views
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerAgentView : View
    {
        #region Fields
        [Header("Components")]
        private Rigidbody rb;
        [Header("Movement")]
        private Structs.MovementData movementData;
        private bool isRun;
        private bool isJump;
        [Header("Rotation")]
        private Structs.RotationData rotationData;
        private float rotY;
        [Header("Weapon")]
        private float fireRate;
        private float timer;
        [Header("PCInput")]
        private Structs.PCInputData pcInputData;
        private Camera mainCam;
        [Header("MobileInput")]
        private Structs.MobileInputData mobileInputData;
        private bool isPressing;
        private Vector2 outputRaw, outputNormal;
        private Vector2 beganPos, movedPos;
        private Vector2 prevPos, currPos;
        private Vector2 deltaPos, clampPos;
        [Header("Input")]
        private Vector2 movementInput;
        private Vector2 rotationInput;
        private Enums.MovementState keyCodeState;
        private bool leftClick;
        private bool isRunKeyPressed;
        private bool isJumpKeyPressed;
        #endregion

        #region Core
        public void Initialize(IPlayerModel playerModel, IInputModel inputModel)
        {
            rb = GetComponent<Rigidbody>();

            movementData = playerModel.PlayerSettings.MovementData;
            rotationData = playerModel.PlayerSettings.RotationData;

            pcInputData = inputModel.InputSettings.PCInputData;
            mobileInputData = inputModel.InputSettings.MobileInputData;
        }
        public void Reload()
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            clearPCInputs();
            clearMobileInputs();
        }
        #endregion

        #region Updates
        public void OnGameUpdate()
        {
        }
        #endregion

        #region Movements
        private void movement(Vector2 input, Enums.MovementState keyCodeState)
        {
            movementInput = input;

            isRun = keyCodeState == Enums.MovementState.Run;
            isJump = keyCodeState == Enums.MovementState.Jump;

            if (movementData.MovementType != Enums.MovementType.Rigidbody)
            {
                transformMovement();
                transformJump();
            }
            else
            {
                rigidbodyMovement();
                rigidbodyJump();
            }
        }
        private Vector3 getAcceleration()
        {
            float speedMultiplier = isRun ? movementData.RunSpeed : movementData.WalkSpeed;
            Vector3 input = new Vector3(movementInput.x, 0f, movementInput.y);
            Vector3 acc = input * speedMultiplier;
            return acc;
        }
        private void transformMovement()
        {
            transform.position += getAcceleration() * Time.deltaTime;
        }
        private void rigidbodyMovement()
        {
            rb.velocity += getAcceleration() * Time.fixedDeltaTime;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, isRun ? movementData.RunSpeed : movementData.WalkSpeed);
        }
        #endregion

        #region Jumps
        private void transformJump()
        {
            float jump = 0f;
            if (isJump)
            {
                jump = movementData.JumpPower;
            }
            else
            {
                jump = Mathf.Lerp(jump, 0f, Time.deltaTime);
            }
            transform.Translate(new Vector3(0f, jump, 0f) * Time.deltaTime);
        }
        private void rigidbodyJump()
        {
            if (isJump)
                rb.AddForce(Vector3.up * movementData.JumpPower * Time.fixedDeltaTime, movementData.JumpForceMode);
        }
        #endregion

        #region Rotations
        private void rotation(Vector2 input)
        {
            rotationInput = input;
            rotate();
        }
        private void rotate()
        {
            Vector3 diff = new Vector3(rotationInput.x, 0f, rotationInput.y) - transform.position;
            Quaternion targetRot = Quaternion.LookRotation(diff, Vector3.up);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * rotationData.RotationSpeed);
        }
        #endregion

        #region Shoot
        public void Shoot()
        {
            timer += Time.deltaTime;
            if (timer > fireRate)
            {
                timer = 0f;
                //weapon.Shoot();
            }
        }
        #endregion

        #region PCInput
        private void pcInput()
        {
            switch (pcInputData.PCInputBehavior)
            {
                case Enums.PCInputBehavior.Raw:
                    movementInput = new Vector2(Input.GetAxis(pcInputData.HorizontalAxis), Input.GetAxis(pcInputData.VerticalAxis));
                    break;
                case Enums.PCInputBehavior.NonRaw:
                    movementInput = new Vector2(Input.GetAxisRaw(pcInputData.HorizontalAxis), Input.GetAxisRaw(pcInputData.VerticalAxis));
                    break;
            }

            Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
            rotationInput = new Vector2(mouseWorldPos.x, mouseWorldPos.z);

            isRunKeyPressed = Input.GetKey(pcInputData.RunKey);
            isJumpKeyPressed = Input.GetKeyUp(pcInputData.JumpKey);

            keyCodeState = isRunKeyPressed ? Enums.MovementState.Run : isJumpKeyPressed ? Enums.MovementState.Jump : Enums.MovementState.Walk;

            leftClick = Input.GetMouseButton(0);
        }
        private void clearPCInputs()
        {
        }
        #endregion

        #region MobileInput
        private void mobileInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isPressing = true;
                beganPos = Input.mousePosition;
                currPos = beganPos;
                prevPos = beganPos;

                movementInput = Vector2.zero;
                keyCodeState = Enums.MovementState.Walk;
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

                movementInput = deltaPos;
                keyCodeState = Enums.MovementState.Walk;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isPressing = false;
                outputRaw = Vector3.zero;
                deltaPos = Vector3.zero;
                outputNormal = Vector2.zero;

                movementInput = Vector2.zero;
                keyCodeState = Enums.MovementState.Walk;
            }

            leftClick = isPressing;
        }
        private void clearMobileInputs()
        {
            outputNormal = Vector2.zero;
            beganPos = Vector2.zero;
            movedPos = Vector2.zero;
            deltaPos = Vector2.zero;
            outputRaw = Vector2.zero;
            isPressing = false;
        }
        #endregion

        #region Physic
        private void OnCollisionEnter(Collision collision)
        {
            //if (collision.gameObject.CompareTag("Enemy"))
        }
        #endregion
    }
}
