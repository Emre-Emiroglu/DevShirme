using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DevShirme.Utils;
using DevShirme.Interfaces;

namespace DevShirme.Modules.CameraModule
{
    public class Cam : MonoBehaviour, ICam
    {
        #region Fields
        [Header("Cam Components")]
        [SerializeField] private Enums.CamType camType;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        private CinemachineBasicMultiChannelPerlin perlin;
        private Coroutine shake;
        private Coroutine fov;
        private float orgFov;
        #endregion

        #region Getters
        public Enums.CamType CameraType => camType;
        #endregion

        #region Core
        public void Initialize()
        {
            perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
        public void Show()
        {
            virtualCamera.Priority = 99;
        }
        public void Hide()
        {
            virtualCamera.Priority = 0;
        }
        #endregion

        #region Shake
        public void Shake(float amplitudeGain, float frequencyGain, float shakeDuration)
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
            perlin.m_AmplitudeGain = amplitudeGain;
            perlin.m_FrequencyGain = frequencyGain;
        }
        #endregion

        #region Fov
        public void ChangeFov(float addValue, float duration)
        {
            virtualCamera.m_Lens.FieldOfView = orgFov;

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
            float oldValue = virtualCamera.m_Lens.FieldOfView;
            float targetValue = oldValue + addValue;
            float t = 0f;
            while (t < duration)
            {
                t += Time.deltaTime;
                virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(oldValue, targetValue, t / duration);

                yield return null;
            }

            virtualCamera.m_Lens.FieldOfView = targetValue;
        }
        #endregion
    }
}
