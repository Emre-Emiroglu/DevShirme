using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Settings
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "DevShirme/Settings/EnemySettings", order = 1)]
    public class EnemySettings : ScriptableObject
    {
        #region Fields
        [Header("Follow Settings")]
        [SerializeField] private float followSpeed;
        [SerializeField] private float turnSpeed;
        #endregion

        #region Getters
        public float FollowSpeed => followSpeed;
        public float TurnSpeed => turnSpeed;
        #endregion
    }
}
