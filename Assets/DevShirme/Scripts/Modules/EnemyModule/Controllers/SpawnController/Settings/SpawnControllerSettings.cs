using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnControllerSettings", menuName = "DevShirme/Settings/ControllerSettings/SpawnControllerSettings", order = 1)]
public class SpawnControllerSettings : ScriptableObject
{
    #region Fields
    [Header("Spawn Settings")]
    [SerializeField] private string poolName;
    [SerializeField] private float spawnDuration;
    [SerializeField] private float radius;
    #endregion

    #region Getters
    public string PoolName => poolName;
    public float SpawnDuration => spawnDuration;
    public float Radius => radius;
    #endregion
}