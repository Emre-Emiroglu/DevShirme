﻿using DevShirme.Interfaces.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models.Pool
{
    public class ObjectPool
    {
        #region Fields
        private readonly GameObject prefab;
        private readonly Transform parent;
        private readonly string poolName;
        private readonly int initSize;
        private readonly int maxSize;
        private List<IPoolObject> items;
        #endregion

        #region Getters
        public string PoolName => poolName;
        public IPoolObject GetObj(Vector3 pos, Quaternion rot, Vector3 scale, Transform parent, bool useRotation = false, bool useScale = false, bool setParent = false)
        {
            CheckIsPoolFull();

            for (int i = 0; i < items.Count; i++)
            {
                if (!items[i].InUse)
                {
                    items[i].Spawn(pos, rot, scale, parent, useRotation, useScale, setParent);
                    return items[i];
                }
            }

            return null;
        }
        #endregion

        #region Core
        public ObjectPool(GameObject prefab, string poolName, int initSize, int maxSize, Transform parent)
        {
            this.prefab = prefab;
            this.poolName = poolName;
            this.initSize = initSize;
            this.maxSize = maxSize;
            this.parent = parent;

            items = new List<IPoolObject>();

            FillPool();
        }
        #endregion

        #region Executes
        private void FillPool()
        {
            for (int i = 0; i < initSize; ++i)
                Spawn();
        }
        private void Spawn()
        {
            GameObject obj = Object.Instantiate(prefab, parent);
            IPoolObject tmp = obj.GetComponent<IPoolObject>();

            ((MonoBehaviour)tmp).enabled = true;
            tmp.Initialize();
            tmp.DeSpawn();

            items.Add(tmp);
        }
        private bool CheckIsPoolFull()
        {
            if (items.Count >= maxSize)
            {
                return false;
            }
            else
            {
                int newSize = items.Count * 2;
                newSize = newSize > maxSize ? newSize : maxSize;

                for (int i = items.Count; i < newSize; i++)
                    Spawn();

                return true;
            }
        }
        public void Reload()
        {
            for (int i = 0; i < items.Count; i++)
                items[i].DeSpawn();
        }
        #endregion
    }
}