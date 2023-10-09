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
        private readonly PlayerSettings playerSettings;
        private readonly Transform playerTransform;
        #endregion

        #region Getters
        public PlayerSettings PlayerSettings => playerSettings;
        public Transform PlayerTransform => playerTransform;
        #endregion

        #region Core
        public PlayerModel()
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            playerSettings = Resources.Load<PlayerSettings>("Settings/PlayerSettings");
        }
        #endregion
    }
}
