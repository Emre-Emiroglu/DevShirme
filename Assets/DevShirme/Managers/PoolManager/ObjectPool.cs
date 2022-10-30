using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.PoolModule
{
    public class ObjectPool: MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private GameObject ObjPref;
        [SerializeField] private string poolName;
        [SerializeField] private int initSize;
        [SerializeField] private int maxPoolSize;
        [SerializeField] private List<PoolObject> items;
        #endregion

        #region Getters
        public string PoolName => poolName;
        #endregion

        #region Pool Core
        public void Initilaze()
        {
            for (int i = 0; i < initSize; ++i)
            {
                AddPool();
            }
        }
        public void Reload()
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].DespawnObj();
            }
        }
        #endregion

        #region Pool Getters
        public PoolObject GetObj(Transform pos, bool useRotation, bool useScale = false)
        {
            return GetObj(pos.position, useRotation, pos.rotation, useScale, pos.localScale);
        }
        public PoolObject GetObj(Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale, bool setParent = false, GameObject obj = null)
        {
            int i = 0;
            for (; i < items.Count; i++)
            {
                if (!items[i].InUse)
                {
                    items[i].SpawnObj(pos, useRotation, rot, useScale, scale, setParent, obj);
                    return items[i];
                }
            }
            if (IncreasePool())
            {
                for (; i < items.Count; ++i)
                {
                    if (!items[i].InUse)
                    {
                        items[i].SpawnObj(pos, useRotation, rot, useScale, scale, setParent, obj);
                        return items[i];
                    }
                }
            }
            return null;
        }
        #endregion

        #region Pool Setup
        private void AddPool()
        {
            GameObject obj = Instantiate(ObjPref, transform);
            PoolObject tmp = obj.GetComponent<PoolObject>();

            tmp.initilaze();
            tmp.DespawnObj();
            items.Add(tmp);
        }
        private bool IncreasePool()
        {
            if (items.Count >= maxPoolSize)
            {
                return false;
            }
            int newSize = items.Count * 2;
            if (newSize >= maxPoolSize)
            {
                newSize = maxPoolSize;
            }
            for (int i = items.Count; i < newSize; i++)
            {
                AddPool();
            }
            return true;
        }
        #endregion
    }
}