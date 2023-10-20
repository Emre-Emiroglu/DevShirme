using DevShirme.Models;
using DevShirme.Utils;
using DevShirme.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Mediators
{
    public class CamMediator : MonoBehaviour, IDisposable
    {
        #region Fields
        private CamView view;
        private CameraModel cameraModel;
        private SignalBus signalBus;
        #endregion

        #region Core
        [Zenject.Inject]
        public void Construct(CamView view, CameraModel cameraModel, SignalBus signalBus)
        {
            this.view = view;
            this.cameraModel = cameraModel;
            this.signalBus = signalBus;

            this.view.Initialize();

            signalBus.Subscribe<Structs.OnChangeGameState>(x => onChangeGameState(x.NewGameState));
            signalBus.Subscribe<Structs.OnShakeCam>(x => onShakeCam(x.TargetCam));
            signalBus.Subscribe<Structs.OnChangeCamFov>(x => onChangeCamFov(x.TargetCam, x.NewFov));
        }
        public void Dispose()
        {
            signalBus.Unsubscribe<Structs.OnChangeGameState>(x => onChangeGameState(x.NewGameState));
            signalBus.Unsubscribe<Structs.OnShakeCam>(x => onShakeCam(x.TargetCam));
            signalBus.Unsubscribe<Structs.OnChangeCamFov>(x => onChangeCamFov(x.TargetCam, x.NewFov));
        }
        #endregion

        #region Receivers
        private void onChangeGameState(Enums.GameState gameState)
        {
            Enums.CamType camType = gameState == Enums.GameState.Start ? Enums.CamType.FollowCam : Enums.CamType.IdleCam;
            bool isShow = camType == view.CameraType;
            if (isShow)
                view.Show();
            else
                view.Hide();
        }
        private void onShakeCam(Enums.CamType camType)
        {
            if (camType != view.CameraType)
                return;

            view.Shake(cameraModel.AmplitudeGain, cameraModel.FrequencyGain, cameraModel.ShakeDuration);
        }
        private void onChangeCamFov(Enums.CamType camType, float addValue)
        {
            if (camType != view.CameraType)
                return;

            view.ChangeFov(addValue, cameraModel.ChangeFovDuration);
        }
        #endregion
    }
}
