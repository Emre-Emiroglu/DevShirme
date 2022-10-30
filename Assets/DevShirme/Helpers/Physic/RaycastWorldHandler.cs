using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Helpers
{
    public class RaycastWorldHandler : MonoBehaviour
    {
        #region Fields
        public Action<bool, Transform, Vector3> HitCallback;
        [Header("Physic Settings")]
        [SerializeField] private LayerMask layer;
        [SerializeField] private float maxDistance = 50;
        [SerializeField] private string compareTag = "";
        [Header("Other Settings")]
        [SerializeField] private bool autoUpdate = false;
        [SerializeField] private bool drawDebug = false;
        [Header("Game")]
        public Vector3 Direction;
        Vector3 debugPos, debugDir;
        bool onDebugHit;
        #endregion

        #region Unity
        private void Update()
        {
            if (autoUpdate)
            {
                internalUpdate();
            }
        }
        private void OnDrawGizmos()
        {
            if (drawDebug)
            {
                if (onDebugHit)
                    Gizmos.color = Color.green;
                else
                    Gizmos.color = Color.red;

                Gizmos.DrawRay(debugPos, debugDir);
            }
        }
        #endregion

        #region Executes
        public void SendRay()
        {
            raycastAction(transform.position, Direction);
        }
        public void SendRay(Vector3 dir)
        {
            raycastAction(transform.position, dir);
        }
        public void SendRay(Vector3 origin, Vector3 dir)
        {
            raycastAction(origin, dir);
        }
        private void raycastAction(Vector3 o, Vector3 dir)
        {
            RaycastHit hit;

            if (drawDebug)
            {
                debugPos = o;
                debugDir = dir * maxDistance;
                onDebugHit = false;
            }

            if (Physics.Raycast(o, dir, out hit, maxDistance, layer.value))
            {
                if (drawDebug)
                {
                    onDebugHit = true;
                }

                if (hit.transform.tag == compareTag || compareTag == "")
                {
                    if (HitCallback != null) HitCallback(true, hit.transform, hit.point);
                }
                else
                {
                    if (HitCallback != null) HitCallback(false, hit.transform, hit.point);
                }
            }
            else
            {
                if (HitCallback != null) HitCallback(false, null, Vector3.zero);
            }
        }
        #endregion

        #region Updates
        public void UpdateHandler()
        {
            if (!autoUpdate)
            {
                internalUpdate();
            }
        }
        private void internalUpdate()
        {
            worldUpdate();
        }
        private void worldUpdate()
        {
            raycastAction(transform.position, Direction);
        }
        #endregion

    }
}
