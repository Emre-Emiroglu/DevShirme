using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Helpers
{
    public class RaycastScreenHandler : MonoBehaviour
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
        public Camera ViewCamera;
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
        public void SendRayFromScreen(Vector2 screenPoint)
        {
            raycastAction(screenPoint);
        }
        private void raycastAction(Vector2 ipos)
        {
            Ray ray = ViewCamera.ScreenPointToRay(ipos);
            RaycastHit hit;

            if (drawDebug)
            {
                debugPos = ray.origin;
                debugDir = ray.direction * maxDistance;
                onDebugHit = false;
            }

            if (Physics.Raycast(ray, out hit, maxDistance, layer.value))
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
            mouseUpdate();
        }
        private void mouseUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                raycastAction(Input.mousePosition);
            }
        }
        private void touchUpdate()
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    raycastAction(Input.GetTouch(0).position);
                }
            }
        }
        #endregion

    }
}

