using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Settings
{
    [CreateAssetMenu(fileName = "EnemySpawnerSettings", menuName = "DevShirme/Settings/EnemySpawnerSettings", order = 0)]
    public class EnemySpawnerSettings : ScriptableObject
    {
        #region Fields
        [Header("Enemy Spawner Settings")]
        [SerializeField] private float duration;
        [SerializeField] private float radius;
        [SerializeField] private bool useGizmo;
        [SerializeField] private Color gizmoColor;
        #endregion

        #region Getters
        public float Duration => duration;
        public float Radius => radius;
        public bool UseGizmo => useGizmo;
        public Color GizmoColor => gizmoColor;
        #endregion
    }
}
