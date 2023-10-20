using DevShirme.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    [Serializable]
    public class PoolModel : IPoolModel
    {
        #region Fields
        [Header("Pool Model Settings")]
        [SerializeField] private GameObject[] prefabs;
        [SerializeField] private string[] poolNames;
        [Range(0, 1000)][SerializeField] private int initSize = 100;
        [Range(0, 1000)][SerializeField] private int maxSize = 500;
        private ObjectPool[] objectPools;
        private Transform parent;
        #endregion

        #region Getters
        public ObjectPool[] ObjectPools => objectPools;
        #endregion

        #region Core
        public void Initialize()
        {
            parent = GameObject.Find("PoolInstaller").GetComponent<Transform>();
            objectPools = new ObjectPool[prefabs.Length];
            for (int i = 0; i < prefabs.Length; i++)
            {
                ObjectPool pool = new ObjectPool(prefabs[i], poolNames[i], initSize, maxSize, parent);
                objectPools[i] = pool;
            }
        }
        public IPoolObject GetPoolObject(string poolName, Vector3 pos, Quaternion rot, Vector3 scale, Transform parent, bool useRotation = false, bool useScale = false, bool setParent = false)
        {
            for (int i = 0; i < objectPools.Length; i++)
            {
                if (objectPools[i].PoolName == poolName)
                    return objectPools[i].GetObj(pos, rot, scale, parent, useRotation, useScale, setParent);
            }

            Debug.LogError(poolName + " Cant Found");
            return null;
        }
        #endregion
    }
}
