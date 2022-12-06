using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.EnemyModule
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "DevShirme/Settings/Enemy Settings", order = 1)]
    public class EnemySettings : DevSettings
    {
        #region Fields
        [Header("Enemy Settings")]
        [SerializeField] private float movementSpeed = 10f;
        [SerializeField] private float rotationSpeed = 10f;
        #endregion

        #region Getters
        public float MovementSpeed => movementSpeed;
        public float RotationSpeed => rotationSpeed;
        #endregion
    }
}

