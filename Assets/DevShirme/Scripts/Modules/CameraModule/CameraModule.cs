using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;
using DevShirme.Interfaces;

namespace DevShirme.Modules.CameraModule
{
    public class CameraModule : Module
    {
        #region Fields
        private readonly CameraSettings cameraSettings;
        private readonly ICam[] cams;
        private ICam activeCam;
        #endregion

        #region Core
        public CameraModule(CameraSettings cameraSettings, ICam[] cams) : base()
        {
            this.cameraSettings = cameraSettings;
            this.cams = cams;

            for (int i = 0; i < this.cams.Length; i++)
                cams[i].Initialize();

            toNewCam(Enums.CamType.IdleCam);
        }
        #endregion

        #region Observer
        public override void OnNotify(object value, Enums.NotificationType notificationType)
        {
            switch (notificationType)
            {
                case Enums.NotificationType.GameStart:
                    toNewCam(Enums.CamType.FollowCam);
                    break;
                case Enums.NotificationType.GameReload:
                    toNewCam(Enums.CamType.IdleCam);
                    break;
            }
        }
        #endregion

        #region Transations
        private void toNewCam(Enums.CamType newCam)
        {
            for (int i = 0; i < cams.Length; i++)
            {
                bool isActive = cams[i].CameraType == newCam;
                if (isActive)
                {
                    activeCam = cams[i];
                    cams[i].Show();
                }
                else
                    cams[i].Hide();
            }
        }
        #endregion

        #region Shake
        public void Shake() => activeCam.Shake(cameraSettings.AmplitudeGain, cameraSettings.FrequencyGain, cameraSettings.ShakeDuration);
        #endregion

        #region Fov
        public void ChangeFov(float addValue) => activeCam.ChangeFov(addValue, cameraSettings.FovChangeDuration);
        #endregion

        #region Updates
        public override void Tick()
        {
        }
        public override void FixedTick()
        {
        }
        public override void LateTick()
        {
        }
        #endregion
    }
}
