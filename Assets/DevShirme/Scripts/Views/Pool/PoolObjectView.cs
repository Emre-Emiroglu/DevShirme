using DevShirme.Interfaces;
using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DevShirme.Views
{
    public class PoolObjectView : View, IPoolObject
    {
        #region Events
        public event Action OnSpawn;
        public event Action OnDeSpawn;
        #endregion

        #region Fields
        private bool inUse;
        protected GameObject obj;
        private Vector3 restartPos;
        private Vector3 restartScale;
        private Quaternion restartRot;
        private GameObject restartParent;
        #endregion

        #region Getters
        public bool InUse => inUse;
        #endregion

        #region Core
        public virtual void Initialize()
        {
            obj = gameObject;
            inUse = false;

            restartPos = obj.transform.position;
            restartRot = obj.transform.rotation;
            restartScale = obj.transform.localScale;
            restartParent = transform.parent.gameObject;
        }
        public virtual void Spawn(Vector3 pos, Quaternion rot, Vector3 scale, Transform parent, bool useRotation = false, bool useScale = false, bool setParent = false)
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
                obj.transform.SetParent(parent.transform);
            }
            obj.SetActive(true);

            OnSpawn?.Invoke();
        }
        public virtual void DeSpawn()
        {
            obj.transform.position = restartPos;
            obj.transform.rotation = restartRot;
            obj.transform.localScale = restartScale;
            obj.transform.SetParent(restartParent.transform);
            inUse = false;
            obj.SetActive(false);

            OnDeSpawn?.Invoke();
        }
        #endregion
    }
}
