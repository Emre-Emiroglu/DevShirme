using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.EnemyModule
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "DevShirme/Settings/ModuleSettings/EnemySettings", order = 1)]
    public class EnemySettings : ScriptableObject
    {
        #region Fields
        [Header("Controllers Settings")]
        [SerializeField] private ScriptableObject[] controllersSettings;
        [Header("Follow Settings")]
        [SerializeField] private float followSpeed;
        [SerializeField] private float turnSpeed;
        #endregion

        #region Getters
        public ScriptableObject[] ControllersSettings => controllersSettings;
        public float FollowSpeed => followSpeed;
        public float TurnSpeed => turnSpeed;
        #endregion
    }
}
