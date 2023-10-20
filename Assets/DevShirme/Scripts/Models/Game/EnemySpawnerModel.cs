using DevShirme.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    [Serializable]
    public class EnemySpawnerModel : IEnemySpawnerModel
    {
        #region Fields
        [Header("Enemy Spawner Model Settings")]
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

        #region Core
        public void Initialize() { }
        #endregion
    }
}
