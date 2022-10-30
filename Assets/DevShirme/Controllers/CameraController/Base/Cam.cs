using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.CameraModule
{
    [RequireComponent(typeof(Camera))]
    public class Cam : MonoBehaviour
    {
        #region Fields
        [Header("Cam Fields")]
        [SerializeField] protected UpdateBehavior UpdateBehavior = UpdateBehavior.Late;
        [SerializeField] private string camTag;
        [SerializeField] private Camera myCam;
        private int priorty;
        private bool isActive;
        #endregion

        #region Getters
        public string CamTag => camTag;
        public bool IsActive => isActive;
        public int Priorty => priorty;
        #endregion

        #region Executes
        public void Activate()
        {
            priorty = 99;
            isActive = true;
            SetMyCam();
        }
        public void DisActivate()
        {
            priorty = 0;
            isActive = false;
            SetMyCam();
        }
        private void SetMyCam() => myCam.enabled = isActive;
        #endregion

    }

}
public enum UpdateBehavior
{
    Update,
    Fixed,
    Late
}
public enum LookType
{
    LookTarget,
    LookFixed,
}