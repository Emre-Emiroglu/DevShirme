using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Helpers
{
    public class Wobble : MonoBehaviour
    {
        #region Fields
        [Header("Wobble Settings")]
        [SerializeField]private float maxWobble = 0.03f;
        [SerializeField] private float wobbleSpeed = 1f;
        [SerializeField] private float recovery = 1f;
        [SerializeField] private Renderer rend;
        private Vector3 lastPos;
        private Vector3 velocity;
        private Vector3 lastRot;
        private Vector3 angularVelocity;
        private float wobbleAmountX;
        private float wobbleAmountZ;
        private float wobbleAmountToAddX;
        private float wobbleAmountToAddZ;
        private float pulse;
        private float time = 0.5f;
        #endregion

        #region Executes
        public void ExternalUpdate()
        {
            time += Time.deltaTime;

            wobbleAmountToAddX = Mathf.Lerp(wobbleAmountToAddX, 0, Time.deltaTime * recovery);
            wobbleAmountToAddZ = Mathf.Lerp(wobbleAmountToAddZ, 0, Time.deltaTime * recovery);

            pulse = 2 * Mathf.PI * wobbleSpeed;
            wobbleAmountX = wobbleAmountToAddX * Mathf.Sin(pulse * time);
            wobbleAmountZ = wobbleAmountToAddZ * Mathf.Sin(pulse * time);

            rend.material.SetFloat("_WobbleX", wobbleAmountX);
            rend.material.SetFloat("_WobbleZ", wobbleAmountZ);

            velocity = (lastPos - transform.position) / Time.deltaTime;
            angularVelocity = transform.rotation.eulerAngles - lastRot;

            wobbleAmountToAddX += Mathf.Clamp((velocity.x + (angularVelocity.z * 0.2f)) * maxWobble, -maxWobble, maxWobble);
            wobbleAmountToAddZ += Mathf.Clamp((velocity.z + (angularVelocity.x * 0.2f)) * maxWobble, -maxWobble, maxWobble);

            lastPos = transform.position;
            lastRot = transform.rotation.eulerAngles;
        }
        #endregion
    }
}
