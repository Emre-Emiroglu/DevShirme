using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Utils
{
    public class GameObj : MonoBehaviour
    {
        #region Fields
        [Header("Game Obj Settings")]
        [SerializeField] private bool drawGizmo = true;
        [SerializeField] private Color gizmoColor = Color.blue;
        [SerializeField] private float fov = 30f;
        [SerializeField] private float maxRange = 10f;
        [SerializeField] private float minRange = 0f;
        [SerializeField] private float aspect = 1f;
        #endregion

        #region Core
        private void OnDrawGizmosSelected()
        {
            if (!drawGizmo)
                return;

            var matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
            Gizmos.color = gizmoColor;
            Gizmos.matrix = matrix;
            Gizmos.DrawFrustum(transform.position, fov, maxRange, minRange, aspect);
        }
        #endregion
    }

}
