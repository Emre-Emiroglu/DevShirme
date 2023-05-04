using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Helpers
{
    public class Follower : MonoBehaviour
    {
        #region Fields
        [Header("Follow Settings")]
        [SerializeField] private bool position = true;
        [SerializeField] private bool rotation = true;
        [SerializeField] private bool positionLerp = false;
        [SerializeField] private bool rotationLerp = false;
        [SerializeField] private bool positionLocal = false;
        [SerializeField] private bool rotationLocal = false;
        [SerializeField] private bool targetPositiontLocal = false;
        [SerializeField] private bool targetRotationLocal = false;
        [SerializeField] private float positionLerpSpeed = .25f;
        [SerializeField] private float rotationLerpSpeed = .25f;
        private Transform target;
        #endregion

        #region Props
        public bool CanFollow { get; set; }
        #endregion

        #region Getters
        private Vector3 getTargetPos => targetPositiontLocal ? target.localPosition : target.position;
        private Quaternion getTargetRot => targetRotationLocal ? target.localRotation : target.rotation;
        #endregion

        #region Core
        public void Setup(Transform target)
        {
            this.target = target;

            if (positionLocal)
                transform.localPosition = getTargetPos;
            else
                transform.position = getTargetPos;

            if (rotationLocal)
                transform.localRotation = getTargetRot;
            else
                transform.rotation = getTargetRot;
        }
        #endregion

        #region Executes
        private void posExecute()
        {
            Vector3 targetPos = getTargetPos;

            if (positionLocal)
                transform.localPosition = positionLerp ? Vector3.Lerp(transform.localPosition, targetPos, Time.deltaTime * positionLerpSpeed) : targetPos;
            else
                transform.position = positionLerp ? Vector3.Lerp(transform.position, targetPos, Time.deltaTime * positionLerpSpeed) : targetPos;
        }
        private void rotExecute()
        {
            Quaternion targetRot = getTargetRot;

            if (rotationLocal)
                transform.localRotation = rotationLerp ? Quaternion.Lerp(transform.localRotation, targetRot, Time.deltaTime * rotationLerpSpeed) : targetRot;
            else
                transform.rotation = rotationLerp ? Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * rotationLerpSpeed) : targetRot;
        }
        private void LateUpdate()
        {
            if (CanFollow)
            {
                if (position)
                    posExecute();
                if (rotation)
                    rotExecute();
            }
        }
        #endregion
    }
}