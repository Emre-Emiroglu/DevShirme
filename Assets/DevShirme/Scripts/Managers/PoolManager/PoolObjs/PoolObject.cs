using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.PoolModule
{
    public class PoolObject : MonoBehaviour
    {
        #region Fields
        [Header("Pool Object Fields")]
        [SerializeField] private string objName;
        private bool inUse;
        protected GameObject obj;
        private Vector3 restartPos;
        private Vector3 restartScale;
        private Quaternion restartRot;
        private GameObject restartParent;
        #endregion

        #region Getters
        public string ObjName => objName;
        public bool InUse => inUse;
        #endregion

        #region Obj Core
        public virtual void initilaze()
        {
            obj = gameObject;
            inUse = false;

            restartPos = obj.transform.position;
            restartRot = obj.transform.rotation;
            restartScale = obj.transform.localScale;
            restartParent = transform.parent.gameObject;
        }
        public virtual void SpawnObj(Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale, bool setParent = false, GameObject p = null)
        {
            inUse = true;
            obj.transform.position = pos;
            if (useRotation)
            {
                obj.transform.rotation = rot;
            }
            if (useScale)
            {
                obj.transform.localScale = scale;
            }
            if (setParent)
            {
                obj.transform.SetParent(p.transform);
            }
            obj.SetActive(true);
        }
        public virtual void DespawnObj()
        {
            DespawnObjProcess();
        }
        private void DespawnObjProcess()
        {
            obj.transform.position = restartPos;
            obj.transform.rotation = restartRot;
            obj.transform.localScale = restartScale;
            RestartParent();
            inUse = false;
            obj.SetActive(false);
        }
        private void RestartParent()
        {
            obj.transform.SetParent(restartParent.transform);
        }
        #endregion
    }
}
