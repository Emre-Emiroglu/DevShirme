using DevShirme.Interfaces;
using DevShirme.Settings;
using DevShirme.Signals;
using DevShirme.Utils;
using DevShirme.Views;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Mediators
{
    public class CamMediator : Mediator
    {
        #region Injects
        [Inject] public CamView CamView { get; set; }
        [Inject] public ICameraModel CameraModel { get; set; }
        [Inject] public GameSignal GameSignal { get; set; }
        #endregion

        #region Core
        public override void PreRegister()
        {
        }
        public override void OnRegister()
        {
            CamView.Initialize();

            GameSignal.OnTransationToNewCam.AddListener(onTransationToNewCam);
            GameSignal.OnShakeCam.AddListener(onShakeCamCommand);
            GameSignal.OnChangeCamFov.AddListener(onChangeCamFov);
        }
        public override void OnRemove()
        {
            GameSignal.OnTransationToNewCam.RemoveListener(onTransationToNewCam);
            GameSignal.OnShakeCam.RemoveListener(onShakeCamCommand);
            GameSignal.OnChangeCamFov.RemoveListener(onChangeCamFov);
        }
        #endregion

        #region Receivers
        private void onTransationToNewCam(Enums.CamType camType)
        {
            bool isShow = camType == CamView.CameraType;
            if (isShow)
                CamView.Show();
            else
                CamView.Hide();
        }
        private void onShakeCamCommand(Enums.CamType camType)
        {
            if (camType != CamView.CameraType)
                return;

            CameraSettings cameraSettings = CameraModel.CameraSettings;

            CamView.Shake(cameraSettings.AmplitudeGain, cameraSettings.FrequencyGain, cameraSettings.ShakeDuration);
        }
        private void onChangeCamFov(Enums.CamType camType, float addValue)
        {
            if (camType != CamView.CameraType)
                return;

            CamView.ChangeFov(addValue, CameraModel.CameraSettings.ChangeFovDuration);
        }
        #endregion
    }
}
