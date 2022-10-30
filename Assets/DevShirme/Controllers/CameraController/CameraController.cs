using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DevShirme.CameraModule
{
    public class CameraController : DevShirmeController
    {
        #region Fields
        [Header("Camera Module Fields")]
        [SerializeField] private List<Cam> cams;
        [SerializeField] private string startCamTag;
        private Coroutine toNewCam;
        #endregion

        #region Core
        public override void Initialize()
        {
            Cam startCam = GetCam(startCamTag);
            startCam.Activate();
        }
        #endregion

        #region Gets
        private Cam GetCam(string tag) => cams.FirstOrDefault(x => x.CamTag == tag);
        private Cam GetCurrentActiveCam()
        {
            Cam cam = cams.FirstOrDefault(x => x.IsActive == true);
            return cam;
        }
        #endregion

        #region Transations
        public void ToNewCam(string tag)
        {
            Cam oldCam = GetCurrentActiveCam();
            Cam newCam = GetCam(tag);

            if (toNewCam != null)
            {
                StopCoroutine(toNewCam);
            }
            toNewCam =  StartCoroutine(TransationExecute(((CameraSettings)settings).Duration, oldCam, newCam));
        }
        private IEnumerator TransationExecute(float duration, Cam oldCam, Cam newCam)
        {
            float t = 0f;
            Vector3 startPos = oldCam.transform.position;
            Vector3 endPos = newCam.transform.position;
            Quaternion startRot = oldCam.transform.rotation;
            Quaternion endRot = newCam.transform.rotation;
            while (t < duration)
            {
                t += Time.deltaTime;
                oldCam.transform.position = Vector3.Lerp(startPos, endPos, ((CameraSettings)settings).Curve.Evaluate(t / duration));
                oldCam.transform.rotation = Quaternion.Lerp(startRot, endRot, ((CameraSettings)settings).Curve.Evaluate(t / duration));
                yield return null;
            }
            oldCam.transform.position = endPos;
            oldCam.transform.rotation = endRot;
            oldCam.DisActivate();
            newCam.Activate();
        }
        #endregion

        #region Tests
        [ContextMenu("To Second Cam")]
        public void ToSecondCam()
        {
            ToNewCam("Second");
        }
        #endregion

    }

}
