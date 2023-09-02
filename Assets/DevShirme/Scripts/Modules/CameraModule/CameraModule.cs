using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;

namespace DevShirme.Modules.CameraModule
{
    public class CameraModule : Module
    {
        #region Fields
        private readonly CameraSettings cameraSettings;
        private readonly Cam[] cams;
        private Cam activeCam;
        #endregion

        #region Core
        public CameraModule(ScriptableObject _settings) : base(_settings)
        {
            cameraSettings = _settings as CameraSettings;

            cams = Object.FindObjectsOfType<Cam>();

            for (int i = 0; i < cams.Length; i++)
            {
                cams[i].Initialize();
            }
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

        #region Updates
        public override void ExternalUpdate()
        {
        }
        public override void ExternalFixedUpdate()
        {
        }
        #endregion

        #region Subscriptions
        public override void SetSubscriptions(bool isSub)
        {
        }
        #endregion
    }
}
