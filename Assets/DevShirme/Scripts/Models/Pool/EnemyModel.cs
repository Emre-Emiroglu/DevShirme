using DevShirme.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    [Serializable]
    public class EnemyModel : IEnemyModel
    {
        #region Fields
        [Header("Enemy Model Settings")]
        [SerializeField] private float followSpeed;
        [SerializeField] private float turnSpeed;
        #endregion

        #region Getters
        public float FollowSpeed => followSpeed;
        public float TurnSpeed => turnSpeed;
        #endregion

        #region Core
        public void Initialize() { }
        #endregion
    }
}
