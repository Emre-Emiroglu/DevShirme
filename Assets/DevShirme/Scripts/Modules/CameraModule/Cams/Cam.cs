using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DevShirme.Utils;

namespace DevShirme.Modules.CameraModule
{
    public class Cam : MonoBehaviour
    {
        #region Fields
        [Header("Cam Components")]
        [SerializeField] private Enums.CamType myType;
        [SerializeField] private CinemachineVirtualCamera myCam;
        private CinemachineBasicMultiChannelPerlin myPerlin;
        private Coroutine shake;
        private Coroutine fov;
        private float orgFov;
        #endregion

        #region Core
        public void Initialize()
        {
            myPerlin = myCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
        public void Show()
        {
            myCam.Priority = 99;
        }
        public void Hide()
        {
            myCam.Priority = 0;
        }
        #endregion

        #region Shake
        public void CamShake(float amplitudeGain, float frequencyGain, float shakeDuration)
        {
            stopShakeCoroutine();
            shake = StartCoroutine(processShake(amplitudeGain, frequencyGain, shakeDuration));
        }
        private void stopShakeCoroutine()
        {
            if (shake != null)
                StopCoroutine(shake);
        }
        private IEnumerator processShake(float amplitudeGain, float frequencyGain, float shakeDuration)
        {
            noise(amplitudeGain, frequencyGain);
            yield return new WaitForSeconds(shakeDuration);
            noise(0, 0);
        }
        private void noise(float amplitudeGain, float frequencyGain)
        {
            myPerlin.m_AmplitudeGain = amplitudeGain;
            myPerlin.m_FrequencyGain = frequencyGain;
        }
        #endregion

        #region Fov
        public void FovChange(float addValue, float duration)
        {
            myCam.m_Lens.FieldOfView = orgFov;

            stopFovCoroutine();

            fov = StartCoroutine(processFov(addValue, duration));
        }
        private void stopFovCoroutine()
        {
            if (fov != null)
                StopCoroutine(fov);
        }
        private IEnumerator processFov(float addValue, float duration)
        {
            float oldValue = myCam.m_Lens.FieldOfView;
            float targetValue = oldValue + addValue;
            float t = 0f;
            while (t < duration)
            {
                t += Time.deltaTime;
                myCam.m_Lens.FieldOfView = Mathf.Lerp(oldValue, targetValue, t / duration);

                yield return null;
            }

            myCam.m_Lens.FieldOfView = targetValue;
        }
        #endregion
    }
}
