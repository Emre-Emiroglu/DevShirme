using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DevShirme.EnemyModule
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "DevShirme/Settings/Enemy Settings", order = 1)]
    public class EnemySettings : DevSettings
    {
        #region Fields
        [Header("Enemy Settings")]
        [SerializeField] private float movementSpeed = 10f;
        [SerializeField] private float rotationSpeed = 10f;
        [SerializeField] private FowSensorData fowSensorData;
        #endregion

        #region Getters
        public float MovementSpeed => movementSpeed;
        public float RotationSpeed => rotationSpeed;
        public FowSensorData FowSensorData => fowSensorData;
        #endregion
    }
}

[Serializable]
public struct FowSensorData
{
    #region Fields
    [Header("Sensor Settings")]
    [SerializeField] private float viewRadius;
    [SerializeField] private float viewAngle;
    [SerializeField] private float searchDelay;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private LayerMask obstacleMask;
    #endregion

    #region Getters
    public float ViewRadius => viewRadius;
    public float ViewAngle => viewAngle;
    public float SearchDelay => searchDelay;
    public LayerMask TargetMask => targetMask;
    public LayerMask ObstacleMask => obstacleMask;
    #endregion
}