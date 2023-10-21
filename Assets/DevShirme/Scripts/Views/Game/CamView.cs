using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DevShirme.Utils;
using System;
using DevShirme.Models;
using Zenject;

namespace DevShirme.Views
{
    public class CamView : MonoBehaviour, IDisposable
    {
        #region Injects
        private CameraModel cameraModel;
        private SignalBus signalBus;
        #endregion

        #region Fields
        [Header("Cam Components")]
        [SerializeField] private Enums.CamType camType;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        private CinemachineBasicMultiChannelPerlin perlin;
        private Coroutine shake;
        private Coroutine fov;
        private float orgFov;
        #endregion

        #region Core
        [Inject]
        public void Construct(CameraModel cameraModel, SignalBus signalBus)
        {
            perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            this.cameraModel = cameraModel;
            this.signalBus = signalBus;

            signalBus.Subscribe<Structs.OnChangeGameState>(x => OnChangeGameState(x.NewGameState));
            signalBus.Subscribe<Structs.OnShakeCam>(x => OnShakeCam(x.TargetCam));
            signalBus.Subscribe<Structs.OnChangeCamFov>(x => OnChangeCamFov(x.TargetCam, x.NewFov));
        }
        public void Dispose()
        {
            Debug.Log("Disposed: " + camType.ToString());

            signalBus.TryUnsubscribe<Structs.OnChangeGameState>(x => OnChangeGameState(x.NewGameState));
            signalBus.TryUnsubscribe<Structs.OnShakeCam>(x => OnShakeCam(x.TargetCam));
            signalBus.TryUnsubscribe<Structs.OnChangeCamFov>(x => OnChangeCamFov(x.TargetCam, x.NewFov));
        }
        private void Show()
        {
            virtualCamera.Priority = 99;
        }
        private void Hide()
        {
            virtualCamera.Priority = 0;
        }
        #endregion

        #region Receivers
        private void OnChangeGameState(Enums.GameState gameState)
        {
            Enums.CamType camType = gameState == Enums.GameState.Start ? Enums.CamType.FollowCam : Enums.CamType.IdleCam;
            bool isShow = camType == this.camType;
            if (isShow)
                Show();
            else
                Hide();
        }
        private void OnShakeCam(Enums.CamType camType)
        {
            if (camType != this.camType)
                return;

            Shake(cameraModel.AmplitudeGain, cameraModel.FrequencyGain, cameraModel.ShakeDuration);
        }
        private void OnChangeCamFov(Enums.CamType camType, float addValue)
        {
            if (camType != this.camType)
                return;

            ChangeFov(addValue, cameraModel.ChangeFovDuration);
        }
        #endregion

        #region Shake
        private void Shake(float amplitudeGain, float frequencyGain, float shakeDuration)
        {
            StopShakeCoroutine();
            shake = StartCoroutine(ProcessShake(amplitudeGain, frequencyGain, shakeDuration));
        }
        private void StopShakeCoroutine()
        {
            if (shake != null)
                StopCoroutine(shake);
        }
        private IEnumerator ProcessShake(float amplitudeGain, float frequencyGain, float shakeDuration)
        {
            Noise(amplitudeGain, frequencyGain);
            yield return new WaitForSeconds(shakeDuration);
            Noise(0, 0);
        }
        private void Noise(float amplitudeGain, float frequencyGain)
        {
            perlin.m_AmplitudeGain = amplitudeGain;
            perlin.m_FrequencyGain = frequencyGain;
        }
        #endregion

        #region Fov
        private void ChangeFov(float addValue, float duration)
        {
            virtualCamera.m_Lens.FieldOfView = orgFov;

            StopFovCoroutine();

            fov = StartCoroutine(ProcessFov(addValue, duration));
        }
        private void StopFovCoroutine()
        {
            if (fov != null)
                StopCoroutine(fov);
        }
        private IEnumerator ProcessFov(float addValue, float duration)
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
