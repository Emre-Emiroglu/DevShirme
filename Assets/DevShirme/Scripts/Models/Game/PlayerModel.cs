using DevShirme.Interfaces.Game;
using DevShirme.Utils.Structs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models.Game
{
    [Serializable]
    public class PlayerModel : IPlayerModel
    {
        #region Fields
        [Header("Player Model Settings")]
        [SerializeField] private Structs.MovementData movementData;
        [SerializeField] private Structs.RotationData rotationData;
        private Transform playerTransform;
        #endregion

        #region Getters
        public Structs.MovementData MovementData => movementData;
        public Structs.RotationData RotationData => rotationData;
        public Transform PlayerTransform => playerTransform;
        #endregion

        #region Core
        public void Initialize()
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        #endregion
    }
}
