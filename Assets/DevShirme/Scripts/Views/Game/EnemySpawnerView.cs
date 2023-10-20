using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Views
{
    public class EnemySpawnerView : MonoBehaviour
    {
        #region Fields
        [Header("Components")]
        [SerializeField] private Transform playerTransform;
        private float radius;
        private bool useGizmo;
        private Color gizmoColor;
        #endregion

        #region Core
        public void Initialize(float radius, bool useGizmo, Color gizmoColor)
        {
            this.radius = radius;
            this.useGizmo = useGizmo;
            this.gizmoColor = gizmoColor;
        }
        #endregion

        #region Updates
        public void OnGameUpdate()
        {
            transform.position = playerTransform.position;
        }
        #endregion

        #region Gizmo
        private void OnDrawGizmosSelected()
        {
            if (useGizmo)
            {
                Gizmos.color = gizmoColor;
                Gizmos.DrawWireSphere(transform.position, radius);
            }
        }
        #endregion
    }
}
