using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DevShirme.Utils;
using DevShirme.Helpers;

namespace DevShirme.CameraModule
{
    public class CameraController : Controller, IMainButtonListener
    {
        #region Fields
        [Header("Camera Controller Fields")]
        [SerializeField] private CinemachineVirtualCamera[] cams;
        private CameraSettings cameraSettings;
        private CinemachineVirtualCamera activeCam;
        private Coroutine shake;
        #endregion

        #region Core
        public override void Initialize()
        {
            cameraSettings = settings as CameraSettings;

            ActionContainer.Instance.OnMainButtonPressed += OnMainButtonPressed;
        }
        public override void GameStart()
        {
        }
        public override void Reload()
        {
        }
        public override void GameOver()
        {
        }
        public override void GameSuccess()
        {
        }
        public override void GameFail()
        {
        }
        private void OnDestroy()
        {
            ActionContainer.Instance.OnMainButtonPressed -= OnMainButtonPressed;
        }
        #endregion

        #region Transations
        private void toNewCam(Enums.CamType newCam)
        {
            for (int i = 0; i < cams.Length; i++)
            {
                bool isActive = i == ((int)newCam);
                cams[i].Priority = isActive ? 99 : 0;
                if (isActive)
                    activeCam = cams[i];
            }
        }
        #endregion

        #region IMainButtonListener
        public void OnMainButtonPressed(Enums.UIPanelType panelType)
        {
        }
        #endregion

        #region Shake
        public void CamShake()
        {
            if (shake != null)
            {
                StopCoroutine(shake);
            }
            shake = StartCoroutine(processShake());
        }
        private IEnumerator processShake()
        {
            Noise(cameraSettings.AmplitudeGain, cameraSettings.FrequencyGain);
            yield return new WaitForSeconds(cameraSettings.ShakeDuration);
            Noise(0, 0);
        }
        public void Noise(float amplitudeGain, float frequencyGain)
        {
            CinemachineBasicMultiChannelPerlin perlin = activeCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            perlin.m_AmplitudeGain = amplitudeGain;
            perlin.m_FrequencyGain = frequencyGain;
        }
        #endregion
    }
}
