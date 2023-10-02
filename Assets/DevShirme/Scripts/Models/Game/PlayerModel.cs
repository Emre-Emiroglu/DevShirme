using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class PlayerModel : IPlayerModel
    {
        #region Fields
        private PlayerSettings playerSettings;
        #endregion

        #region Getters
        public PlayerSettings PlayerSettings => playerSettings;
        #endregion

        #region Core
        public void Initialize()
        {
            playerSettings = Resources.Load<PlayerSettings>("Settings/PlayerSettings");
        }
        #endregion
    }
}
