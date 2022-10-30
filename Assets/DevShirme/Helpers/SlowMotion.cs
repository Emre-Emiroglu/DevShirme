using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Helpers
{
    public class SlowMotion : MonoBehaviour
    {
        [Header("Slow Motion Settings")]
        [SerializeField] private float slowDownFactor;
        [SerializeField] private float slowDownLength;
        private bool slowMoActivate;

        #region SlowMotion Process
        public void ActivateToSlowMotion()
        {
            slowMoActivate = true;
            Time.timeScale = slowDownFactor;
            Time.fixedDeltaTime = Time.fixedDeltaTime * slowDownFactor;
        }
        private void Update()
        {
            if (slowMoActivate)
            {
                Time.timeScale += (1f / slowDownLength) * Time.unscaledDeltaTime;
                Time.fixedDeltaTime += (0.01f / slowDownLength) * Time.unscaledDeltaTime;
                Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
                Time.fixedDeltaTime = Mathf.Clamp(Time.fixedDeltaTime, 0f, 0.01f);
                if (Time.timeScale == 1f)
                {
                    slowMoActivate = false;
                }
            }
        }
        #endregion
    }
}
