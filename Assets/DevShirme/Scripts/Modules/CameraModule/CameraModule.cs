using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;

namespace DevShirme.CameraModule
{
    public class CameraModule : Module
    {
        #region Fields
        [Header("Camera Controller Fields")]
        [SerializeField] private Cam[] cams;
        private CameraSettings cameraSettings;
        private Cam activeCam;
        #endregion

        #region Core
        public override void Initialize()
        {
            base.Initialize();

            for (int i = 0; i < cams.Length; i++)
            {
                cams[i].Initialize();
            }
        }
        public override void Shutdown()
        {
            base.Shutdown();
        }
        protected override void setSubscriptions(bool isSub)
        {
            base.setSubscriptions(isSub);
        }
        #endregion

        #region Transations
        private void toNewCam(Enums.CamType newCam)
        {
            for (int i = 0; i < cams.Length; i++)
            {
                bool isActive = i == ((int)newCam);
                if (isActive)
                    cams[i].Show();
                else
                    cams[i].Hide();
                
                if (isActive)
                    activeCam = cams[i];
            }
        }
        #endregion

        #region Shake
        public void CamShake() => activeCam.CamShake(cameraSettings.AmplitudeGain, cameraSettings.FrequencyGain, cameraSettings.ShakeDuration);
        #endregion

        #region Fov
        public void FovChange(float addValue) => activeCam.FovChange(addValue, cameraSettings.FovChangeDuration);
        #endregion
    }
}
