using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule.Controllers
{
    public class PlayerAgent : MonoBehaviour, IPlayerAgent
    {
        #region Fields
        private PlayerSettings playerSettings;
        private bool isActivated;
        #endregion

        #region Props
        public bool IsActived { get {  return isActivated; }  set { isActivated = value; } }
        #endregion

        #region Core
        public void Initialize(PlayerSettings playerSettings)
        {
            this.playerSettings = playerSettings;
        }
        #endregion

        #region Updates
        public void ExternalUpdate()
        {
            if (!isActivated)
                return;
        }
        public void ExternalFixedUpdate()
        {
            if (!isActivated)
                return;
        }
        #endregion
    }
}
